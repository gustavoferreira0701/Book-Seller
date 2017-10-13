using BooksSeller.WebApi.Models;
using BooksSeller.WebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksSeller.WebApi.Controllers
{
    public class BooksController : ApiController
    {
        IBooksProvider _booksProvider;

        // GET: api/Books
        public IEnumerable<Book> Get()
        {
            return _booksProvider.GetBooks();
        }

        // GET: api/Books/5
        public Book Get(int id)
        {
            return _booksProvider.GetBook(id);
        }

        // POST: api/Books
        public void Post([FromBody]Book value)
        {
            _booksProvider.SaveBook(value);
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]Book value)
        {
            _booksProvider.SaveBook(id, value);
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
            _booksProvider.DeleteBook(id);
        }
    }
}
