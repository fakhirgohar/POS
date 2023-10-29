using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_POS.Classes
{
    internal class MyControls
    {

        public static void UpdateButtonStates(ToolStripButton btnNew, ToolStripButton btnEdit, ToolStripButton btnDelete, ToolStripButton btnPrint, ToolStripButton btnSearch, ToolStripButton btnSave, ToolStripButton btnCancel, Event EventType)
        {
            btnNew.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnPrint.Enabled = btnSearch.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
            switch (EventType)
            {
                case Event.New:
                case Event.Edit:
                    btnSave.Enabled = btnCancel.Enabled = true;
                    btnDelete.Enabled = btnNew.Enabled = btnEdit.Enabled = false;
                    break;
                case Event.Save:
                case Event.Cancel:
                case Event.Load:
                    btnSave.Enabled = btnCancel.Enabled = false;
                    btnNew.Enabled = btnDelete.Enabled = btnEdit.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        public enum Event
        {
            New = 0,
            Edit = 1,
            Save = 2,
            Cancel = 3,
            Load = 4
        }
    }
}
