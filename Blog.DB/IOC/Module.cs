using Blog.DB.Implement;
using Blog.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DB.IOC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>()
            {
                { typeof(IContactDB),typeof(ContactDB)},
                {typeof(INewsLetterDB),typeof(NewsLetterDB) },
            {typeof(IUserDB),typeof(UserDB) }

            };
            return dic;
        }
    }
}
