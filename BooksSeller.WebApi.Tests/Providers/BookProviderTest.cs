using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Ploeh.AutoFixture;
using BooksSeller.WebApi.Models;
using System.Data.Entity;

namespace BooksSeller.WebApi.Tests.Providers
{
    using Provider = BooksSeller.WebApi.Providers;

    [TestClass]
    public class BookProviderTest
    {
        private Provider.IBooksProvider provider;

        private Fixture _fixture;

        [TestInitialize]
        public void BeforeStart()
        {
            Database.SetInitializer<BookSellerContext>(new DropCreateDatabaseIfModelChanges<BookSellerContext>());
            provider = new Provider.BooksProvider();
            _fixture = new Fixture();
        }

        [TestMethod]
        public void Create()
        {
            var book = _fixture.Create<Book>();

            provider.SaveBook(book);

            var bookInserted = provider.GetBook(book.Code);

            Assert.IsNotNull(bookInserted);
            Assert.IsTrue(bookInserted.Equals(book));
        }

        [TestMethod]
        public void GetBook()
        {
            var book = _fixture.Create<Book>();

            provider.SaveBook(book);

            var bookInserted = provider.GetBook(book.Code);

            Assert.IsNotNull(bookInserted);
        }

        [TestMethod]
        public void GetBooks()
        {
            var books = provider.GetBooks();

            Assert.IsNotNull(books);
            Assert.IsTrue(books is IList && books.GetType().IsGenericType);
        }

        [TestMethod]
        public void Update()
        {
            var book = _fixture.Create<Book>();

            provider.SaveBook(book);
            
            book.Rating++;

            provider.SaveBook(book.Code, book);

            var bookUpdated = provider.GetBook(book.Code);

            Assert.IsNotNull(bookUpdated);
            Assert.AreEqual(bookUpdated.Rating, book.Rating);
        }

        [TestMethod]
        public void Delete()
        {
            var book = _fixture.Create<Book>();

            provider.SaveBook(book);

            provider.DeleteBook(book.Code);
            var deletedBook = provider.GetBook(book.Code);
            Assert.IsNull(deletedBook);
        }
    }
}
