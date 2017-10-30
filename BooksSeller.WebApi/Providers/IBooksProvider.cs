using BooksSeller.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksSeller.WebApi.Providers
{
    public interface IBooksProvider
    {
        Book Create();

        Book GetBook(string id);

        IEnumerable<Book> Filter(string title);

        List<Book> GetBooks();

        void SaveBook(Book book);

        void SaveBook(string id, Book book);

        void DeleteBook(string id);


    }
}