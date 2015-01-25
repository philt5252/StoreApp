using System.Collections.Generic;
using System.Xml.Linq;
using StoreApp.Foundation.DataAccess;
using StoreApp.Foundation.Factories.Models;
using StoreApp.Foundation.Models;

namespace StoreApp.Core.DataAccess
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IBookFactory bookFactory;
        private List<IBook> books = new List<IBook>();

        public BooksRepository(IBookFactory bookFactory)
        {
            this.bookFactory = bookFactory;

            for (int i = 0; i < 20; i++)
            {
                var book = bookFactory.Create();

                book.Id = i;
                book.Name = "Book" + i;
                book.Price = i;

                books.Add(book);
            }
        }

        public IBook[] All()
        {
            return books.ToArray();
        }

        public void Save(IBook book)
        {
            if (!books.Contains(book))
                books.Add(book);
        }

        public void Delete(IBook book)
        {
            books.Remove(book);
        }
    }
}