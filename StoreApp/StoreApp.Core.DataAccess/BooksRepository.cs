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
            int j = 1;
            for (int i = 0; i < 20; i++)
            {
                var book = bookFactory.Create();

                book.Id = i;
                if (j == 1)
                {
                    book.Image = new BitmapImage(new Uri("Images/Books/pridePrejudice.jpg", UriKind.Relative));
                    book.Name = "Pride and Prejudice By Jane Austen";
                }
                else if (j == 2)
                {
                    book.Image = new BitmapImage(new Uri("Images/Books/lotr.jpg", UriKind.Relative));
                    book.Name = "The Lord of the Rings By J.R.R Tolkien";
                }
                else if (j == 3)
                {
                    book.Image = new BitmapImage(new Uri("Images/Books/scottish.jpg", UriKind.Relative));
                    book.Name = "Scottish Cheifs By Jane Porter";
                }
                else if (j == 4)
                {
                    book.Image = new BitmapImage(new Uri("Images/Books/inferno.jpg", UriKind.Relative));
                    book.Name = "The Inferno By Dante";
                }
                else if (j == 5)
                {
                    book.Image = new BitmapImage(new Uri("Images/Books/crimePunish.jpg", UriKind.Relative));
                    book.Name = "Crime and Punishment by Fyodor Dostoyevsky";
                    j = 0;
                }
                j++;
               
                book.Price = i;
                book.Description =
                    "Lorem ipsum dolor sit amet, ius modus harum hendrerit te, dicta viris vocent est an, ad delenit officiis mel. Modus volutpat eos ex. Adhuc accumsan electram at sit. Partem dignissim argumentum ex pri. Corpora vulputate in eos, quo ad impedit consequat. Ex consul insolens sit.";
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