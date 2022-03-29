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
    public class NewsLetterMamager:INewsLetterMamager
    {
        protected readonly INewsLetterDB _newsLetterDB;
        public NewsLetterMamager(INewsLetterDB newsLetterDB)
        {
            _newsLetterDB = newsLetterDB;
        }

        public long Add(NewsLetterModel newsLetterModel)
        {
            return _newsLetterDB.Add(newsLetterModel);
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
