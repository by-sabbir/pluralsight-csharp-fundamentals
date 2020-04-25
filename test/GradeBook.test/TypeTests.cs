using System;
using Xunit;

namespace GradeBook.test
{
    public class TypeTests
    {
        [Fact]
        public void TyepTest()
        {
            int x = GetInt();
            // by reference
            SetInt(out x);

            Assert.Equal(42, x);
        }

        private void SetInt(out int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void PassByRef()
        {
            var book1 = GetBook("Reference");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal(book1.Name, "New Name");
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void PassByValue()
        {
            var book = GetBook("Reference");
            GetBookSetName(book, "New Name");

            Assert.Equal(book.Name, "Reference");
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void TestName()
        {
            var book = GetBook("Book1");
            SetName(book, "New Name");
            Assert.Equal(book.Name, "New Name");
        }

        private void SetName(Book book, string newName)
        {
            book.Name = newName;
        }

        [Fact]
        public void TwoBooksReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {
            var book1 = GetBook("New Book");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
