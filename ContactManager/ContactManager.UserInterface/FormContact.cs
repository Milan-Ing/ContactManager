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
    public partial class FormContact : Form
    {
        #region Properties
        private bool AddOrUpdate { get; set; }

        public ContactModel Contact { get; set; }

        public List<ContactTypeModel> Types { get; set; }
        #endregion

        public FormContact()
        {
            InitializeComponent();
            AddOrUpdate = false;
            btnSubmit.Text = "Add";
            FillComboBox();
        }

        public FormContact(ContactModel c)
        {
            InitializeComponent();
            Contact = c;
            FillComboBox();
            FillTextBoxes();
            AddOrUpdate = true;
            btnSubmit.Text = "Submit";
        }

        #region EventHandlers
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!AddOrUpdate)
            {
                AddContact();
            }
            else
            {
                UpdateContact();
            }
        }
        #endregion

        #region Functions
        public void FillTextBoxes()
        {
            txtFName.Text = Contact.FirstName;
            txtLName.Text = Contact.LastName;
            txtAdr.Text = Contact.Address;
            dateTime.Value = Contact.InsertDate;
            txtPhone.Text = Contact.Phone;
            cmbTypes.Text = Contact.ContactType;
        }

        public void FillComboBox()
        {
            Types = new List<ContactTypeModel>();
            Types = ContactTypeService.GetContactTypes();
            cmbTypes.DataSource = Types;
            cmbTypes.DisplayMember = "Caption";
            cmbTypes.ValueMember = "TypeID";
        }

        private void AddContact()
        {
            Contact = new ContactModel
            {
                FirstName = txtFName.Text,
                LastName = txtLName.Text,
                Address = txtAdr.Text,
                Phone = txtPhone.Text,
                InsertDate = dateTime.Value,
                ContactTypeID = (int)cmbTypes.SelectedValue
            };
            ContactsService.AddContact(Contact);
        }

        private void UpdateContact()
        {
            ContactModel updated = new ContactModel
            {
                FirstName = txtFName.Text,
                LastName = txtLName.Text,
                Address = txtAdr.Text,
                Phone = txtPhone.Text,
                InsertDate = dateTime.Value,
                ContactTypeID = (int)cmbTypes.SelectedValue,
                ContactID = Contact.ContactID
            };
            ContactsService.UpdateContact(updated);
        }
        #endregion        
    }
}
