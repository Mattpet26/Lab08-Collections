using System;
using System.Collections.Generic;
using Lab08_Collections.Classes;

namespace Lab08_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Library<Book> library = new Library<Book>();
            List<Book> bookBag = new List<Book>();

            LoadBooks(library);
            UserInterface(library, bookBag);
        }

        public static void LoadBooks(Library<Book> library)
        {
            Book coding = new Book() { Title = "The Art of Code", bookgenre = (Book.Genre)1};
            coding.author = new Author() { firstName = "Jack", lastName = "Jrohn"};

            Book jumping = new Book() { Title = "Jumping...You know this one", bookgenre = (Book.Genre)4 };
            jumping.author = new Author() { firstName = "Sean", lastName = "Mcwrittington" };

            Book flying = new Book() { Title = "Flying 101", bookgenre = (Book.Genre)5 };
            flying.author = new Author() { firstName = "Jess", lastName = "Ica" };

            Book swimming = new Book() { Title = "How To Not Drown", bookgenre = (Book.Genre)2 };
            swimming.author = new Author() { firstName = "Jack", lastName = "Black" };

            Book racing = new Book() { Title = "Racing And How To Win", bookgenre = (Book.Genre)3 };
            racing.author = new Author() { firstName = "Phil", lastName = "Ipeno" };

            library.add(coding);
            library.add(jumping);
            library.add(flying);
            library.add(swimming);
            library.add(racing);

        }
        public static void UserInterface(Library<Book> library, List<Book> bookBag)
        {
            Console.WriteLine("Welcome to the library! Select an option below to get started.");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. View all books");
                Console.WriteLine("2. Add a book");
                Console.WriteLine("3. Borrow a book");
                Console.WriteLine("4. Return a book");
                Console.WriteLine("5. View bookbag");
                Console.WriteLine("6. Exit library");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        foreach (Book books in library)
                        {
                            Console.WriteLine($"Title:{books.Title} - By:{books.author.firstName} - Published: {books.bookgenre}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter the title of the book you would like:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Please enter the first name of the author:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Please enter the last name of the author:");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Please enter a number for the genre:");
                        Console.WriteLine("1. Fiction");
                        Console.WriteLine("2. Non-Fiction");
                        Console.WriteLine("3. History");
                        Console.WriteLine("4. Biography");
                        Console.WriteLine("5. Science");

                        string genre = Console.ReadLine();
                        int newgenre = Convert.ToInt32(genre);

                        Book newbook = new Book() { Title = title, bookgenre = (Book.Genre)newgenre};
                        newbook.author = new Author() { firstName = firstName, lastName = lastName};
                        library.add(newbook);
                        break;

                    case "3":
                        int count = 0;
                        Console.WriteLine("Please enter the number of the book to borrow:");

                        foreach (Book libbooks in library)
                        {
                            Console.WriteLine($"{count++}. {libbooks.Title}");
                        }
                        int bookBorrowed = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < library.count(); i++)
                        {
                            if (i == bookBorrowed)
                            {
                                Book bookreturned = library.GetArray()[bookBorrowed];
                                bookBag.Add(bookreturned);
                                //this removes the index of which the book is located at.
                                library.remove(bookBorrowed);
                            }
                        }
                        break;

                    case "4":
                        Console.WriteLine("Please enter which number of the book you would like to return:");
                        int counter = 1;
                        Dictionary<int, Book> mystuff = new Dictionary<int, Book>();

                        foreach (var books in bookBag)
                        {
                            mystuff.Add(counter, books);
                            Console.WriteLine($"{counter}. {books.Title}");
                        }

                        int bookReturned = Convert.ToInt32(Console.ReadLine());
                        mystuff.TryGetValue(bookReturned, out Book returnedbook);
                        bookBag.Remove(returnedbook);
                        library.add(returnedbook);

                        break;

                    case "5":
                        Console.WriteLine("Here is your current bookbag:");
                        foreach (Book books in bookBag)
                        {
                            Console.WriteLine($"Title: {books.Title}, By: {books.author.firstName}, Genre: {books.bookgenre}");
                        }
                        break;

                    case "6":

                        break;
                }
            }
        }
    }
}
