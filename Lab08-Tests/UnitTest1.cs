using System;
using Xunit;
using Lab08_Collections.Classes;

namespace Lab08_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddBook()
        {
            Book book = new Book() { Title = "Crunchy"};
            Library<Book> library = new Library<Book>();
            library.add(book);
            string expected = "Crunchy";

            foreach (Book stuff in library)
            {
                Assert.Equal(expected, stuff.Title);
            }


        }
        [Fact]
        public void RemoveBook()
        {
            Book book = new Book() { Title = "Crunchy" };
            Book book2 = new Book() { Title = "deleteMe" };
            Library<Book> library = new Library<Book>();

            int expected = 1;
            library.add(book);
            library.add(book2);
            library.remove(1);

                Assert.Equal(expected, library.count());

        }
        [Fact]
        public void RemoveImaginaryBook()
        {
            Book book = new Book() { Title = "Crunchy" };
            Book book2 = new Book() { Title = "deleteMe" };
            Library<Book> library = new Library<Book>();

            int expected = 2;
            library.add(book);
            library.add(book2);
            library.remove(100);

            Assert.Equal(expected, library.count());
        }
        [Fact]
        public void GettSettBook()
        {
            Book book = new Book();
            book.Title = "Crunchy";
            Library<Book> library = new Library<Book>();

            string expected = "Crunchy";
            library.add(book);

            Assert.Equal(expected, book.Title);
        }
        [Fact]
        public void GettSettAuthor()
        {
            Author author = new Author() { firstName ="jack", lastName="json"};
            string expected = "jack";

            Assert.Equal(expected, author.firstName);
        }
        [Fact]
        public void BookCount()
        {
            Book book = new Book() { Title = "Crunchy" };
            Book book2 = new Book() { Title = "deleteMe" };
            Library<Book> library = new Library<Book>();

            int expected = 2;
            library.add(book);
            library.add(book2);

            Assert.Equal(expected, library.count()) ;
        }
        [Fact]
        public void EdgeCase()
        {
            Book book = new Book() { Title = "Crunchy" };
            Book book2 = new Book() { Title = "deleteMe" };
            Library<Book> library = new Library<Book>();

            int expected = 0;

            Assert.Equal(expected, library.count());
        }
    }
}
