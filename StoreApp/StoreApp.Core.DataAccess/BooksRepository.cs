using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;
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
                book.Image = new BitmapImage(new Uri("Images/pridePrejudice.jpg", UriKind.Relative));
                book.Name = "Book" + i;
                book.Description = "Description!!!!! " + i;
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