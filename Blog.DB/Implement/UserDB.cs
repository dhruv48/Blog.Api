using Blog.Common.Helpers;
using Blog.Common.Models;
using Blog.DB.Infrastructure;
using Blog.DB.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DB.Implement
{
    public class UserDB : BaseDB, IUserDB
    {
        public UserDB(IConfiguration configuration) : base(configuration)
        {

        }
        public long Add(UserModel obj)
        {
            throw new NotImplementedException();
        }

        public long AddUser(UserModel userModel)
        {
            try
            {
                return connection.Execute("proc_userinsert", this.SetParameters(userModel), commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                BlogLogger.Error(ex);
                throw;
            }
        }

        private object SetParameters(UserModel userModel)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@name", userModel.Name);
            parameters.Add("@email", userModel.Email);
            parameters.Add("@username", userModel.Email);
            parameters.Add("@passwordsalt", userModel.PasswordSalt);
            parameters.Add("@passwordhash", userModel.PasswordHash);

            return parameters;
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public UserModel FindByUserNameAsync(string username)
        {
            //string query = string.Format(@"Select  from user where username=@username");
            //var result = await connection.QueryAsync<UserModel>(
            // query, new { username });
            //return result.FirstOrDefault();
            //return await connection.QueryFirstOrDefaultAsync<User>(query, new { username  }).Result;

            try
            {
                string query = string.Format(@"SELECT * FROM [user] where username=@username");
                return connection.Query<UserModel>(query, new { username = username }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                BlogLogger.Error(ex);
                throw;
            }

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
