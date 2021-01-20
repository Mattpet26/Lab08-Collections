using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Classes
{
    // write a method to remove books from the library
    class Library<T>
    {
        T[] items = new T[5];
        int counter;

        public void add(T item)
        {
            if (counter == items.Length)
            {
                //resize it so if count = length, make more room.
                Array.Resize(ref items, items.Length * 2);
            }
            items[counter++] = item;
        }
        public void remove()
        {

        }
        public int count()
        {
            return counter;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < counter; i++)
            {
                // yield is much like return, but it doesn't just run the whole for loop. It returns, waits, then next reutrn.
                yield return items[i];
            }
        }
    }
}
