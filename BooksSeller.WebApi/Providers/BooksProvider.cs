using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BooksSeller.WebApi.Models;

namespace BooksSeller.WebApi.Providers
{
    public class BooksProvider : IBooksProvider
    {
        // TODO: Create the implementation for IBooksProvider
        public Book Create()
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(string id)
        {
            string bookCode = id.ToString();

            using (var ctx = new BookSellerContext())
            {
                var bookFound = (from b in ctx.Books
                                 where b.Code == bookCode
                                 select b).FirstOrDefault();

                if (bookFound == null)
                {
                    throw new Exception("O livro pesquisado não foi encontrado");
                }
                else
                {
                    ctx.Books.Remove(bookFound);
                    ctx.SaveChanges();
                }
            }
        }

        public Book GetBook(string id)
        {
            using (var ctx = new BookSellerContext())
            {
                var bookFound = (from b in ctx.Books
                                 where b.Code == id
                                 select b).FirstOrDefault();

                return bookFound;
            }

        }

        public IEnumerable<Book> Filter(string title)
        {
            using (var ctx = new BookSellerContext())
            {
                var bookFound = (from b in ctx.Books
                                 where b.Title.Contains(title)
                                 select b);

                return bookFound.ToArray();
            }
        }

        public List<Book> GetBooks()
        {
            using (var ctx = new BookSellerContext())
            {
                return ctx.Books.ToList();
            }
        }

        public void SaveBook(Book book)
        {
            using (var ctx = new BookSellerContext())
            {
                ctx.Books.Add(book);
                ctx.SaveChanges();
            }
        }

        public void SaveBook(string id, Book book)
        {
            using (var ctx = new BookSellerContext())
            {
                var found = ctx.Books.FirstOrDefault(filter => filter.Code == id);

                if (found == null)
                    throw new Exception("Nenhum livro encontrado com o código mencionado");
                else
                {
                    ctx.Entry(found).CurrentValues.SetValues(book);
                    ctx.SaveChanges();
                }
            }
        }

    }
}