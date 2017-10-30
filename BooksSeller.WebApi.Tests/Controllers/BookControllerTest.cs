using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksSeller.WebApi.Providers;
using BooksSeller.WebApi.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BooksSeller.WebApi.Models;
using Moq;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using Ploeh.AutoFixture;
using System.Data.Entity;

namespace BooksSeller.WebApi.Tests.Controllers
{
    [TestClass]
    public class BookControllerTest
    {
        private IBooksProvider _provider;
        private Fixture _fixture;
        
        private BooksController CreateController()
        {
            return new BooksController(_provider)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestInitialize]
        public void BeforeStart()
        {
            Database.SetInitializer<BookSellerContext>(new DropCreateDatabaseIfModelChanges<BookSellerContext>());
            _provider = new BooksProvider();
            _fixture = new Fixture();
        }

        [TestMethod]
        public void GetAll_Returns_OK()
        {
            var ctrl = CreateController();

            var response = ctrl.Get();

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<List<Book>>));
        }

        [TestMethod]
        public void GetById_Empty_404()
        {
            var ctrl = CreateController();

            var response = ctrl.Get("ZZZZZ");

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));
        }
        
        [TestMethod]
        public void Put_Http_Ok()
        {
            var ctrl = CreateController();
            var book = _fixture.Create<Book>();

            var response = ctrl.Post(book);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<Book>));

            book.Rating++;

            response = ctrl.Put(book);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<Book>));
        }

        [TestMethod]
        public void Put_BodyEmpty_Returns_BadRequest()
        {
            var ctrl = CreateController();
            var book = _fixture.Create<Book>();

            var response = ctrl.Post(book);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<Book>));

            response = ctrl.Put(new Book());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Post()
        {
            var ctrl = CreateController();
            var book = _fixture.Create<Book>();

            var response = ctrl.Post(book);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<Book>));
        }

        [TestMethod]
        public void Delete_200()
        {
            var ctrl = CreateController();
            var book = _fixture.Create<Book>();

            var response = ctrl.Post(book);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<Book>));

            response = ctrl.Delete(book.Code);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
