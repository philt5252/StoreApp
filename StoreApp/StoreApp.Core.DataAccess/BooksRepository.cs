using System.Collections.Generic;
using StoreApp.Foundation.DataAccess;
using StoreApp.Foundation.Models;

namespace StoreApp.Core.DataAccess
{
    public class BooksRepository : IBooksRepository
    {
        private List<IBook> books = new List<IBook>();

        public BooksRepository()
        {
            
        }

        public IBook[] All()
        {
            return null;
        }
    }
}