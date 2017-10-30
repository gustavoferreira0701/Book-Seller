using BooksSeller.WebApi.Models;
using BooksSeller.WebApi.Providers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksSeller.WebApi.Controllers
{
    public class BooksController : ApiController
    {
        IBooksProvider _booksProvider;

        public BooksController(IBooksProvider booksProvider)
        {
            _booksProvider = booksProvider;
        }

        // GET: api/Books
        public IHttpActionResult Get()
        {
            try
            {
                var books = _booksProvider.GetBooks();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Books/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var book = _booksProvider.GetBook(id);

                if (book == null)
                    return NotFound();
                else
                    return Ok(book);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult Filter(string title)
        {
            try
            {
                var result = _booksProvider.Filter(title);

                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Books
        public IHttpActionResult Post([FromBody]Book value)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _booksProvider.SaveBook(value);

                    return Ok(value);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {  
                return InternalServerError(ex);
            }
        }

        // PUT: api/Books/5
        public IHttpActionResult Put([FromBody]Book value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _booksProvider.SaveBook(value.Code, value);

                    return Ok(value);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Books/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                _booksProvider.DeleteBook(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
