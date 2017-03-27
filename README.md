# WTA_BeThis     ![BeThis](WTA_BeThis/BeThis.PNG)
Revit Add-in in c# &mdash; This add-in combines a number of Revit workset related tasks of which the primary is to automatically switch a document's current workset to whatever the user has set to be the prefered workset. This happens using the DocumentOpened event.  The user setting is saved as an application setting. That is the **BeThis** function.

The secondary workset related items are:

* **Workset Picker**     ![BeThis](WTA_BeThis/WsP.png)
    - A tool that allows one to select an item to:
      - See what workset it is.
      - Change the active workset to what the picked item workset is.
      - Change the picked item's workset to what the current workset is.


* **Workset Make-O-Matic**
  - An application that makes all the house standard worksets in one shot. This is to make sure all worksets are correctly named. The house standard worksets are defined in an external text file.


* A custom **ribbon tab visibilty controller** to affect an affect similar to AutoCAD's workspace setting. The user selects which custom ribbon tabs to be visible. This is stored as an application setting. A function subscribing to the DocumentOpened event reads that setting and sets the ribbon tab visibilty.


The name for this add-in is actually AAA_WTA_BeThis to use the telephone book trick that causes the ribbon panel to load first and therefore be at the ribbon tab left side. Revit loads add-ins in the order the disk operating system hands them to Revit, which is in alphabetical order.

Since this add-in is location specific there will be some tinkering required to compile. There are also some post compile commands that will fail.

Much of the code is by others. Its mangling and ignorant misuse is my ongoing doing. Much thanks to the professionals like Jeremy Tammik who provided the means directly or by mention one way or another for probably all the code needed.  
