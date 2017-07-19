using ContactManager.Model.Model;
using ContactManager.Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UserInterface
{
    public partial class FormMain : Form
    {
        public List<ContactModel> Contacts { get; set; }

        public FormMain()
        {
            InitializeComponent();
            Contacts = ContactsService.GetContacts();
            dataGridContacts.DataSource = Contacts;
            dataGridContacts.Columns["ContactID"].Visible = false;
            dataGridContacts.Columns["ContactTypeID"].Visible = false;
            dataGridContacts.Columns["ContactType"].Name = "Contact type";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridContacts.SelectedRows.Count != 1)
                return;
            var frm = new FormContact();
            frm.Contact = (ContactModel)dataGridContacts.CurrentRow.DataBoundItem;
            frm.FillTextBoxes();
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridContacts.SelectedRows.Count != 1)
                return;
            var contact = (ContactModel)dataGridContacts.CurrentRow.DataBoundItem;
            Contacts.Remove(contact);
            dataGridContacts.DataSource = Contacts;
            ContactsService.DeleteContact(contact);
        }
    }
}
