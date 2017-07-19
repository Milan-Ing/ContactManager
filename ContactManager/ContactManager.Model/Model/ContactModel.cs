using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Data;

namespace ContactManager.Model.Model
{
    public class ContactModel
    {
        public int ContactID { get; set; }
        public int ContactTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public System.DateTime InsertDate { get; set; }
    }
}
