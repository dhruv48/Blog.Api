using Blog.Common.Models;
using Blog.DB.Interface;
using Blog.Manager.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blog.Manager.Implement
{
    public class UserManager : IUserManager
    {
        protected readonly IUserDB _userDB;
        public UserManager(IUserDB userDB)
        {
            _userDB = userDB;
        }
        public long Add(UserModel obj)
        {
            throw new NotImplementedException();
        }

        public bool CheckPassword(UserModel userModel, string password)
        {
            if (password != null)
            {
                return VerifyPassword(password, userModel.PasswordHash, userModel.PasswordSalt);

            }
            else
            {
                return false;
            }
        }


        public long AddUser(UserModel userModel, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            userModel.PasswordHash = passwordHash;
            userModel.PasswordSalt = passwordSalt;

           return _userDB.AddUser(userModel);
            //save user to db

            
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); // Create hash using password salt.
                for (int i = 0; i < computedHash.Length; i++)
                { // Loop through the byte array
                    if (computedHash[i] != passwordHash[i]) return false; // if mismatch
                }
            }
            return true; //if no mismatches.
        }
        public string Base64Decode(string password)
        {
            password = password.Replace('-', '+');
            password = password.Replace('_', '/');
            password = password.PadRight(password.Length + (4 - password.Length % 4) % 4, '=');

            var data = Convert.FromBase64String(password);
            return Encoding.UTF8.GetString(data);
        }

        public bool IsBase64String(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        public UserModel FindByUserNameAsync(string username)
        {
            return _userDB.FindByUserNameAsync(username);
        }

        public List<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetBy(long Id)
        {
            throw new NotImplementedException();
        }

        public long Update(UserModel Obj)
        {
            throw new NotImplementedException();
        }
    }
}
