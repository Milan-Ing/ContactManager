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
                    var contactType = "";
                    if (c.ContactTypeID == 1) contactType = "Family";
                    if (c.ContactTypeID == 2) contactType = "Friends";
                    if (c.ContactTypeID == 3) contactType = "Work";

                    contacts.Add(new ContactModel
                    {
                        Phone = c.Phone,
                        Address = c.Address,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        InsertDate = c.InsertDate,
                        ContactID = c.ContactID,
                        ContactTypeID = c.ContactTypeID,
                        ContactType = contactType
                    });
                }

                return contacts;
            }
        }

        public static void DeleteContact(ContactModel c)
        {
            using (var context = new ContactManagerDBEntities())
            {
                var toDelete = context.Contacts.Where(x => x.ContactID == c.ContactID).First();
                context.Contacts.Remove(toDelete);

                context.SaveChanges();
            }
        }
    }
}
