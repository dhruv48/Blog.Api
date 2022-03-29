using Blog.Manager.Implement;
using Blog.Manager.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Manager.IOC
{
    public static class Module
    {
        public static Dictionary<Type,Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>
            {
                   { typeof(IContactManager),typeof(ContactManager)},
                    { typeof(INewsLetterMamager),typeof(NewsLetterMamager)},
                    { typeof(IUserManager),typeof(UserManager)}
            };
            return dic;
            
        }
    }
}
