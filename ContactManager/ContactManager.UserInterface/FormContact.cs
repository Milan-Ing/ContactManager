using ContactManager.Model.Model;
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
        public FormContact()
        {
            InitializeComponent();
        }

        public ContactModel Contact { get; set; }

        public void FillTextBoxes()
        {
            txtFName.Text = Contact.FirstName;
            txtLName.Text = Contact.LastName;
            txtAdr.Text = Contact.Address;
            txtDate.Text = Contact.InsertDate.ToString();
            txtPhone.Text = Contact.Phone;
        }
    }
}
