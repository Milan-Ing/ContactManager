using ContactManager.Data;
using ContactManager.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Model.Services
{
    public class ContactsService
    {
        public static List<ContactModel> GetContacts()
        {
            using (var context = new ContactManagerDBEntities())
            {
                List<ContactModel> contacts = new List<ContactModel>();

                foreach (var c in context.Contacts)
                {
                    contacts.Add(new ContactModel
                    {
                        Phone = c.Phone,
                        Address = c.Address,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        InsertDate = c.InsertDate
                    });
                }

                return contacts;
            }
        }
    }
}
