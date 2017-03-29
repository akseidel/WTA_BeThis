using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace AAA_WTA_BeThis {
    public partial class WorksetMakeOMatic : System.Windows.Forms.Form {
        String DefTitle = "WorksetMake-O-Matic";
        UIDocument _thisuidoc;
        Document _thisDoc;
        String AWS_Def_FileName = string.Empty;
        DataTable dtWSNamesProposed = new DataTable();
        BindingSource bsWSNamesProposed = new BindingSource();
        DataTable dtWSNamesExisting = new DataTable();
        BindingSource bsWSNamesExisting = new BindingSource();

        public WorksetMakeOMatic(UIDocument thisUIDoc) {
            InitializeComponent();
            _thisuidoc = thisUIDoc;
            _thisDoc = thisUIDoc.Document;
        }

        private void WorksetMakeOMatic_Load(object sender, EventArgs e) {
            Properties.Settings.Default.Reload();
            if (!AreWeGoodWithWorkSharing()) {
                MessageBox.Show("Quitting now, no point in proceeding.", "Worksharing No Enabled");
                Close();
            }
            SetUpdtWSNamesColumns();
            GetExistingWSNames();
            ReadTheSetup();
            // MarkNamesInGrid();
        }

        // ReadASetup is also being used to set defaults for either the sub disc or view use parameters.
        // A defaults file will be loaded and read in either mode if it exists at the defaults setup folder.
        private void ReadTheSetup() {
            bool didReadSomething = false;
            AWS_Def_FileName = textBoxWSFile.Text;
            dtWSNamesProposed.Clear();
            listBoxStatus.Items.Clear();
            string line;
            if (AWS_Def_FileName == String.Empty) {
                listBoxStatus.Items.Add("A setup file is needed.");
                listBoxStatus.Items.Add("In the textbox line above enter or drag in a setup file.");
                return;
            }
            if (!File.Exists(AWS_Def_FileName)) {
                listBoxStatus.Items.Add("No Such File.");
                return;
            }
            this.Text = DefTitle;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(AWS_Def_FileName);
            while ((line = file.ReadLine()) != null) {
                if (line.ToUpper().Left(3) == "WS:") {
                    dtWSNamesProposed.Rows.Add(new object[] { line.Substring(3).Trim() });
                    listBoxStatus.Items.Add(line);
                    didReadSomething = true;
                }
            }
            file.Close();
            bsWSNamesProposed.DataSource = dtWSNamesProposed;
            dataGridViewWSNames.DataSource = bsWSNamesProposed;
            dataGridViewWSNames.Sort(dataGridViewWSNames.Columns[0], ListSortDirection.Ascending);
            MarkNamesInGrid();
            if (!didReadSomething) {
                listBoxStatus.Items.Add("Nothing in that file was a WS: name!");
            }
        }

        private void GetExistingWSNames() {
            dtWSNamesExisting.Clear();
            FilteredWorksetCollector collWS = new FilteredWorksetCollector(_thisDoc).OfKind(WorksetKind.UserWorkset);
            foreach (Workset ws in collWS) {
                dtWSNamesExisting.Rows.Add(new object[] { ws.Name });
            }
            bsWSNamesExisting.DataSource = dtWSNamesExisting;
            dataGridViewExisting.DataSource = bsWSNamesExisting;
            dataGridViewExisting.Sort(dataGridViewExisting.Columns[0], ListSortDirection.Ascending);
        }

        private void buttonQuit2_Click(object sender, EventArgs e) {
            Close();
        }

        private bool AreWeGoodWithWorkSharing() {
            if (!_thisDoc.IsWorkshared) {
                DialogResult res = MessageBox.Show("Worksets only exist in worksharing Revit files. Shall we enable worksharing for this file?", "Wait A Minute Chester", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (res == System.Windows.Forms.DialogResult.OK) {
                    if (_thisDoc.CanEnableWorksharing()) {
                        using (Transaction worksetTransaction = new Transaction(_thisDoc, "WorksetMake-O-Matic")) {
                            try {
                                _thisDoc.EnableWorksharing("Shared Levels and Grids", "Workset1");
                            } catch (Autodesk.Revit.Exceptions.ApplicationException Ex) {
                                MessageBox.Show("Well that did not work!\n" + Ex.Message, "Worksharing Failed");
                            }
                        }
                    }
                } else {
                    buttonDoIt.Enabled = false;
                }
            }
            return _thisDoc.IsWorkshared;
        }

        public List<string> RunWorksetMakeOMaticProcess() {
            string msgS = string.Empty;
            string msgF = string.Empty;
            string msgT = string.Empty;
            List<string> reports = new List<string> { };
            foreach (DataRow dtRow in dtWSNamesProposed.Rows) {
                string strWSName = dtRow["WSNameN"].ToString().Trim();
                if (strWSName != null && strWSName != string.Empty) {
                    if (CreateWorkset(_thisDoc, strWSName) != null) {
                        reports.Add("Created workset:  " + strWSName);
                    } else {
                        string probReason = (WorksetTable.IsWorksetNameUnique(_thisDoc, strWSName)) ? "    Reason: unknown!" : "    Reason: It is already exists.";
                        reports.Add("Failed creating workset:  " + strWSName + probReason);
                    }
                }
            }
            return reports;
        }

        private void SetUpdtWSNamesColumns() {
            dtWSNamesProposed.Columns.Add("WSNameN", typeof(string));
            dtWSNamesExisting.Columns.Add("WSNameE", typeof(string));
        }

        public Workset CreateWorkset(Document document, string workSetName) {
            Workset newWorkset = null;
            // Worksets can only be created in a document with worksharing enabled 
            if (document.IsWorkshared) {
                // Workset name must not be in use by another workset 
                if (WorksetTable.IsWorksetNameUnique(document, workSetName)) {
                    using (Transaction worksetTransaction = new Transaction(document, "WorksetMake-O-Matic")) {
                        worksetTransaction.Start();
                        newWorkset = Workset.Create(document, workSetName);
                        worksetTransaction.Commit();
                    }
                }
            }
            return newWorkset;
        }

        private void buttonDoIt_Click(object sender, EventArgs e) {
            listBoxStatus.Items.Clear();
            foreach (string rept in RunWorksetMakeOMaticProcess()) {
                listBoxStatus.Items.Add(rept);
            }
            GetExistingWSNames();
            MarkNamesInGrid();
        }

        private void MarkNamesInGrid() {
            foreach (DataGridViewRow dgvR in dataGridViewWSNames.Rows) {
                if (dgvR.Cells[0].Value != null) {
                    string wsn = dgvR.Cells[0].Value.ToString();
                    if (!WorksetTable.IsWorksetNameUnique(_thisDoc, wsn)) {
                        dgvR.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                    } else {
                        dgvR.DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            foreach (DataGridViewRow dgvRE in dataGridViewExisting.Rows) {
                if (dgvRE.Cells[0].Value != null) {
                    foreach (DataGridViewRow dgvR in dataGridViewWSNames.Rows) {
                        if (dgvR.Cells[0].Value != null) {
                            string wsn = dgvR.Cells[0].Value.ToString();
                            string wse = dgvRE.Cells[0].Value.ToString();
                            if (wsn.Equals(wse, StringComparison.CurrentCultureIgnoreCase)) {
                                dgvRE.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                    }
                }
            }
        }

        private void textBoxWSFile_DragEnter(object sender, DragEventArgs e) {
            DragEnterMode(e);
        }

        private void textBoxWSFile_DragDrop(object sender, DragEventArgs e) {
            GetWSDrag(e);
        }

        private void DragEnterMode(DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) { e.Effect = DragDropEffects.All; } else { e.Effect = DragDropEffects.None; }
        }

        private void listBoxStatus_DragDrop(object sender, DragEventArgs e) {
            GetWSDrag(e);
        }

        private void GetWSDrag(DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (File.Exists(files[0])) {
                    if (Path.GetExtension(files[0]) == ".txt") {
                        textBoxWSFile.Text = files[0];
                        AWS_Def_FileName = textBoxWSFile.Text;
                        ReadTheSetup();
                    }
                }
            }
        }

        private void listBoxStatus_DragEnter(object sender, DragEventArgs e) {
            DragEnterMode(e);
        }

        private void dataGridViewWSNames_DragDrop(object sender, DragEventArgs e) {
            GetWSDrag(e);
        }

        private void dataGridViewWSNames_DragEnter(object sender, DragEventArgs e) {
            DragEnterMode(e);
        }

        private void dataGridViewWSNames_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            MarkNamesInGrid();
        }

        private void dataGridViewWSNames_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if (dataGridViewWSNames.EditingControl.GetType() == typeof(DataGridViewTextBoxEditingControl)) {
                ((DataGridViewTextBoxEditingControl)dataGridViewWSNames.EditingControl).CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void dataGridViewExisting_DragDrop(object sender, DragEventArgs e) {
            GetWSDrag(e);
        }

        private void dataGridViewExisting_DragEnter(object sender, DragEventArgs e) {
            DragEnterMode(e);
        }

        private void WorksetMakeOMatic_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.Save();
        }

        private void textBoxWSFile_TextChanged(object sender, EventArgs e) {
            ReadTheSetup();
        }

        private void textBoxWSFile_MouseDoubleClick(object sender, MouseEventArgs e) {
            string thisFile = textBoxWSFile.Text;
            try {
                string thisPath = Path.GetDirectoryName(thisFile);
                System.Diagnostics.Process.Start("explorer.exe", thisPath);
            } catch (System.ArgumentException) {
            }
        }

    } // 
    public static class Utils {
        // An implementation of the Left string function
        public static string Left(this string str, int length) {
            return str.Substring(0, Math.Min(length, str.Length));
        }

        // Get substring of specified number of characters on the right.
        public static string Right(this string value, int length) {
            if (String.IsNullOrEmpty(value)) return string.Empty;
            return value.Length <= length ? value : value.Substring(value.Length - length);
        }
    }
}
