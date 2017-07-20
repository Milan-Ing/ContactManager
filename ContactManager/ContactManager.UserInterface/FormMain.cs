using ContactManager.Model.Model;
using ContactManager.Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UserInterface
{
    public partial class FormMain : Form
    {
        #region Properties
        public List<ContactModel> Contacts { get; set; }
        #endregion

        public FormMain()
        {
            InitializeComponent();
            SetDataGridOptions();
        }

        #region EventHandlers
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridContacts.SelectedRows.Count != 1)
                return;
            var frm = new FormContact((ContactModel)dataGridContacts.CurrentRow.DataBoundItem);
            if (DialogResult.OK == frm.ShowDialog())
            {
                dataGridContacts.DataSource = null;
                dataGridContacts.Update();
                dataGridContacts.Refresh();
                SetDataGridOptions();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridContacts.SelectedRows.Count != 1)
                return;
            var contact = (ContactModel)dataGridContacts.CurrentRow.DataBoundItem;
            ContactsService.DeleteContact(contact);
            dataGridContacts.DataSource = null;
            dataGridContacts.Update();
            dataGridContacts.Refresh();
            SetDataGridOptions();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FormContact();
            if (DialogResult.OK == frm.ShowDialog())
            {
                dataGridContacts.DataSource = null;
                dataGridContacts.Update();
                dataGridContacts.Refresh();
                SetDataGridOptions();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ContactsService.DeleteAllContacts();
            Contacts = null;
            dataGridContacts.DataSource = null;
            dataGridContacts.Update();
            dataGridContacts.Refresh();
            MessageBox.Show("Successfully deleted all contacts!", "Delete status", MessageBoxButtons.OKCancel);
        }
        #endregion


        #region Functions
        public void Export()
        {
            using (StreamWriter sw = new StreamWriter("Export.txt"))
            {
                foreach (var c in Contacts)
                {
                    string toWrite = c.FirstName + ";" + c.LastName + ";" + c.Address + ";" + c.Phone + ";" + c.InsertDate.ToString() + ";" + c.ContactTypeID;
                    sw.WriteLine(toWrite);
                }

                MessageBox.Show("Successfully exported to file!", "Export status", MessageBoxButtons.OKCancel);
            }
        }

        public void SetDataGridOptions()
        {
            Contacts = ContactsService.GetContacts();
            dataGridContacts.DataSource = Contacts;
            dataGridContacts.Columns["ContactID"].Visible = false;
            dataGridContacts.Columns["ContactTypeID"].Visible = false;
            dataGridContacts.Columns["ContactType"].Name = "Contact type";
        }

        public void Import()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sw = new StreamReader(ofd.FileName))
                {
                    string line = "";

                    Contacts = new List<ContactModel>();

                    while ((line = sw.ReadLine()) != null)
                    {
                        var importData = line.Split(';');
                        ContactModel newContact = new ContactModel
                        {
                            FirstName = importData[0],
                            LastName = importData[1],
                            Address = importData[2],
                            Phone = importData[3],
                            InsertDate = DateTime.Parse(importData[4]),
                            ContactTypeID = Int32.Parse(importData[5])
                        };
                        Contacts.Add(newContact);
                    }

                    ContactsService.ImportContacts(Contacts);
                    dataGridContacts.DataSource = null;
                    dataGridContacts.Update();
                    dataGridContacts.Refresh();
                    SetDataGridOptions();
                    MessageBox.Show("Successfully imported from file!", "Import status", MessageBoxButtons.OKCancel);
                }
            }
        }
        #endregion
    }
}
