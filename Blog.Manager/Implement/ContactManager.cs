using Blog.Common.Models;
using Blog.DB.Interface;
using Blog.Manager.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Manager.Implement
{
    public class ContactManager : IContactManager
    {
        protected readonly IContactDB _contactDB;
        public ContactManager(IContactDB contactDB)
        {
            _contactDB = contactDB;
        }
        public long Add(ContactModel contactModel)
        {
            return _contactDB.Add(contactModel);
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public List<ContactModel> GetAll()
        {
            return _contactDB.GetAll();
        }

        public ContactModel GetBy(long Id)
        {
            throw new NotImplementedException();
        }

        public long Update(ContactModel Obj)
        {
            throw new NotImplementedException();
        }
    }
}
