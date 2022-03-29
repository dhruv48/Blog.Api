using Blog.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DB.Interface
{
    public interface IUserDB:IBaseDB<UserModel>
    {
        public UserModel FindByUserNameAsync(string username);


        public long AddUser(UserModel userModel);
    }
}
