namespace AAA_WTA_BeThis {
    partial class WorksetMakeOMatic {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.buttonQuit2 = new System.Windows.Forms.Button();
            this.toolTipReporter = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewWSNames = new System.Windows.Forms.DataGridView();
            this.WSNameN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewExisting = new System.Windows.Forms.DataGridView();
            this.WSNameE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDoIt = new System.Windows.Forms.Button();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.splitContainerReports = new System.Windows.Forms.SplitContainer();
            this.splitContainerBottomSplits = new System.Windows.Forms.SplitContainer();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.textBoxWSFile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWSNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExisting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReports)).BeginInit();
            this.splitContainerReports.Panel1.SuspendLayout();
            this.splitContainerReports.Panel2.SuspendLayout();
            this.splitContainerReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottomSplits)).BeginInit();
            this.splitContainerBottomSplits.Panel1.SuspendLayout();
            this.splitContainerBottomSplits.Panel2.SuspendLayout();
            this.splitContainerBottomSplits.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQuit2
            // 
            this.buttonQuit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit2.BackColor = System.Drawing.Color.Red;
            this.buttonQuit2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit2.Location = new System.Drawing.Point(751, 12);
            this.buttonQuit2.Name = "buttonQuit2";
            this.buttonQuit2.Size = new System.Drawing.Size(71, 23);
            this.buttonQuit2.TabIndex = 49;
            this.buttonQuit2.Text = "Quit";
            this.buttonQuit2.UseVisualStyleBackColor = false;
            this.buttonQuit2.Click += new System.EventHandler(this.buttonQuit2_Click);
            // 
            // dataGridViewWSNames
            // 
            this.dataGridViewWSNames.AllowDrop = true;
            this.dataGridViewWSNames.AllowUserToResizeRows = false;
            this.dataGridViewWSNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWSNames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WSNameN});
            this.dataGridViewWSNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWSNames.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewWSNames.MultiSelect = false;
            this.dataGridViewWSNames.Name = "dataGridViewWSNames";
            this.dataGridViewWSNames.RowHeadersVisible = false;
            this.dataGridViewWSNames.Size = new System.Drawing.Size(422, 301);
            this.dataGridViewWSNames.TabIndex = 0;
            this.toolTipReporter.SetToolTip(this.dataGridViewWSNames, "Green  = To be Added\r\nBlue  =  Existing\r\n\r\nAdding and deleting rows is possible.\r" +
        "\n\r\nAll text you enter will be forced to be\r\nuppercase.");
            this.dataGridViewWSNames.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWSNames_CellEndEdit);
            this.dataGridViewWSNames.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewWSNames_EditingControlShowing);
            this.dataGridViewWSNames.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewWSNames_DragDrop);
            this.dataGridViewWSNames.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewWSNames_DragEnter);
            // 
            // WSNameN
            // 
            this.WSNameN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WSNameN.DataPropertyName = "WSNameN";
            this.WSNameN.HeaderText = "Proposed Worksets To Add";
            this.WSNameN.Name = "WSNameN";
            // 
            // dataGridViewExisting
            // 
            this.dataGridViewExisting.AllowDrop = true;
            this.dataGridViewExisting.AllowUserToAddRows = false;
            this.dataGridViewExisting.AllowUserToDeleteRows = false;
            this.dataGridViewExisting.AllowUserToResizeRows = false;
            this.dataGridViewExisting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExisting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WSNameE});
            this.dataGridViewExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExisting.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewExisting.MultiSelect = false;
            this.dataGridViewExisting.Name = "dataGridViewExisting";
            this.dataGridViewExisting.RowHeadersVisible = false;
            this.dataGridViewExisting.Size = new System.Drawing.Size(386, 301);
            this.dataGridViewExisting.TabIndex = 1;
            this.dataGridViewExisting.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewExisting_DragDrop);
            this.dataGridViewExisting.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewExisting_DragEnter);
            // 
            // WSNameE
            // 
            this.WSNameE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WSNameE.DataPropertyName = "WSNameE";
            this.WSNameE.HeaderText = "Existing Worksets";
            this.WSNameE.Name = "WSNameE";
            // 
            // buttonDoIt
            // 
            this.buttonDoIt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDoIt.BackColor = System.Drawing.Color.LawnGreen;
            this.buttonDoIt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDoIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDoIt.Location = new System.Drawing.Point(635, 12);
            this.buttonDoIt.Name = "buttonDoIt";
            this.buttonDoIt.Size = new System.Drawing.Size(113, 23);
            this.buttonDoIt.TabIndex = 51;
            this.buttonDoIt.Text = "Add The Worksets";
            this.buttonDoIt.UseVisualStyleBackColor = false;
            this.buttonDoIt.Click += new System.EventHandler(this.buttonDoIt_Click);
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.AllowDrop = true;
            this.listBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.ItemHeight = 20;
            this.listBoxStatus.Location = new System.Drawing.Point(3, 22);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxStatus.Size = new System.Drawing.Size(810, 242);
            this.listBoxStatus.TabIndex = 0;
            this.listBoxStatus.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxStatus_DragDrop);
            this.listBoxStatus.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxStatus_DragEnter);
            // 
            // splitContainerReports
            // 
            this.splitContainerReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerReports.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerReports.Location = new System.Drawing.Point(2, 50);
            this.splitContainerReports.Name = "splitContainerReports";
            this.splitContainerReports.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerReports.Panel1
            // 
            this.splitContainerReports.Panel1.Controls.Add(this.splitContainerBottomSplits);
            this.splitContainerReports.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainerReports.Panel2
            // 
            this.splitContainerReports.Panel2.Controls.Add(this.groupBoxStatus);
            this.splitContainerReports.Panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerReports.Size = new System.Drawing.Size(820, 580);
            this.splitContainerReports.SplitterDistance = 305;
            this.splitContainerReports.TabIndex = 53;
            // 
            // splitContainerBottomSplits
            // 
            this.splitContainerBottomSplits.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerBottomSplits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBottomSplits.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBottomSplits.Name = "splitContainerBottomSplits";
            // 
            // splitContainerBottomSplits.Panel1
            // 
            this.splitContainerBottomSplits.Panel1.Controls.Add(this.dataGridViewExisting);
            // 
            // splitContainerBottomSplits.Panel2
            // 
            this.splitContainerBottomSplits.Panel2.Controls.Add(this.dataGridViewWSNames);
            this.splitContainerBottomSplits.Size = new System.Drawing.Size(820, 305);
            this.splitContainerBottomSplits.SplitterDistance = 390;
            this.splitContainerBottomSplits.TabIndex = 1;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.listBoxStatus);
            this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(816, 267);
            this.groupBoxStatus.TabIndex = 1;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status Console";
            // 
            // textBoxWSFile
            // 
            this.textBoxWSFile.AllowDrop = true;
            this.textBoxWSFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWSFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AAA_WTA_BeThis.Properties.Settings.Default, "DefFilePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxWSFile.Location = new System.Drawing.Point(2, 14);
            this.textBoxWSFile.Name = "textBoxWSFile";
            this.textBoxWSFile.Size = new System.Drawing.Size(627, 20);
            this.textBoxWSFile.TabIndex = 52;
            this.textBoxWSFile.Text = global::AAA_WTA_BeThis.Properties.Settings.Default.DefFilePath;
            this.toolTipReporter.SetToolTip(this.textBoxWSFile, "The simple text file listing what worksets to add.\r\n\r\nDrag a file name from Explo" +
        "rer to here.\r\n\r\nDouble clicking will open the location for viewing the\r\navailabl" +
        "e files at that spot.");
            this.textBoxWSFile.TextChanged += new System.EventHandler(this.textBoxWSFile_TextChanged);
            this.textBoxWSFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxWSFile_DragDrop);
            this.textBoxWSFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxWSFile_DragEnter);
            this.textBoxWSFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxWSFile_MouseDoubleClick);
            // 
            // WorksetMakeOMatic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(827, 632);
            this.Controls.Add(this.splitContainerReports);
            this.Controls.Add(this.textBoxWSFile);
            this.Controls.Add(this.buttonDoIt);
            this.Controls.Add(this.buttonQuit2);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::AAA_WTA_BeThis.Properties.Settings.Default, "PrefMLoc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::AAA_WTA_BeThis.Properties.Settings.Default.PrefMLoc;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(715, 500);
            this.Name = "WorksetMakeOMatic";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "WorksetMake-O-Matic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorksetMakeOMatic_FormClosing);
            this.Load += new System.EventHandler(this.WorksetMakeOMatic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWSNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExisting)).EndInit();
            this.splitContainerReports.Panel1.ResumeLayout(false);
            this.splitContainerReports.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReports)).EndInit();
            this.splitContainerReports.ResumeLayout(false);
            this.splitContainerBottomSplits.Panel1.ResumeLayout(false);
            this.splitContainerBottomSplits.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottomSplits)).EndInit();
            this.splitContainerBottomSplits.ResumeLayout(false);
            this.groupBoxStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonQuit2;
        private System.Windows.Forms.ToolTip toolTipReporter;
        private System.Windows.Forms.Button buttonDoIt;
        private System.Windows.Forms.TextBox textBoxWSFile;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.SplitContainer splitContainerReports;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.DataGridView dataGridViewWSNames;
        private System.Windows.Forms.SplitContainer splitContainerBottomSplits;
        private System.Windows.Forms.DataGridView dataGridViewExisting;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSNameE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSNameN;
    }
}