using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Classes
{
    class Book
    {
        public string Title { get; set; }
        public Author author { get; set; }
        public Genre bookgenre { get; set; }

        public enum Genre{
            Fictional = 1,
            NonFiction,
            History,
            Biography,
            Science
            }
    }
}
