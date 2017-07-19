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
            dataGridContacts.Columns[0].Visible = false;
            dataGridContacts.Columns[1].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
