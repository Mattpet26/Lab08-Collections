using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Classes
{
    public class Author
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<string> booksWritten { get; set; }

        public void getAuthor()
        {
            Author dude = new Author();
            Console.WriteLine($"Here's the author: {dude.firstName}, {dude.lastName}");
        }
        public void getBooks()
        {
            Author written = new Author();

            foreach (string book in written.booksWritten)
            {
                Console.WriteLine($"{book}");
            }
        }
    }
}
