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
    public class NewsLetterDB:BaseDB,INewsLetterDB
    {
        public NewsLetterDB(IConfiguration configuration) : base(configuration)
        {

        }

        public long Add(NewsLetterModel newsLetterModel)
        {
            try
            {
                return connection.Execute("proc_newsletterinsert", this.SetParameters(newsLetterModel), commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                BlogLogger.Error(ex);
                throw ;
            }
        }
        private object SetParameters(NewsLetterModel newsLetterModel)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@name", newsLetterModel.Name);
            parameters.Add("@emailid", newsLetterModel.EmailId);
            

            return parameters;
        }


        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetterModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public NewsLetterModel GetBy(long Id)
        {
            throw new NotImplementedException();
        }

        public long Update(NewsLetterModel Obj)
        {
            throw new NotImplementedException();
        }
    }
}
