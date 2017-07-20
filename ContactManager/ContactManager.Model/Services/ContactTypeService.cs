using ContactManager.Data;
using ContactManager.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Model.Services
{
    public class ContactTypeService
    {
        public static List<ContactTypeModel> GetContactTypes()
        {
            using (var context = new ContactManagerDBEntities())
            {
                List<ContactTypeModel> types = new List<ContactTypeModel>();

                foreach (var c in context.ConactTypes)
                {
                    types.Add(new ContactTypeModel
                    {
                        TypeID = c.ContactTypeID,
                        Caption = c.Caption
                    });
                }

                return types;
            }
        }
    }
}
