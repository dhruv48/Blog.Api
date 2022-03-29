using Blog.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Manager.Inteface
{
    public interface IUserManager:IBaseManager<UserModel>
    {
        public UserModel FindByUserNameAsync(string username);
        public long AddUser(UserModel userModel, string password);
        bool CheckPassword(UserModel userModel, string password);
        //Task<User> AddUser(User user, string password);
    }
}
