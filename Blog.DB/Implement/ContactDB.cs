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
using static Blog.Common.Helpers.Enum;

namespace Blog.DB.Implement
{
    public class ContactDB : BaseDB, IContactDB
    {
        public ContactDB(IConfiguration configuration):base(configuration)
        {

        }
        public long Add(ContactModel contactModel)
        {
            try
            {
                return connection.Execute("proc_insertcontact", this.SetParameters(contactModel), commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                BlogLogger.Error(ex);
                throw;
            }
        }

        private object SetParameters(ContactModel contactModel)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@name", contactModel.Name);
            parameters.Add("@emailId", contactModel.EmailId);
            //parameters.Add("@subject", contactModel.Subject);
            parameters.Add("@message", contactModel.Message);
            parameters.Add("@isactive", Status.IsActive);

            return parameters;
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public List<ContactModel> GetAll()
        {
            try
            {
                string query = string.Format(@"Select * from vw_selectcontact");
                var result = connection.Query<ContactModel>(query).ToList();
                return result;
            }
            catch (Exception ex)
            {
                BlogLogger.Error(ex);
                throw;
            }
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
