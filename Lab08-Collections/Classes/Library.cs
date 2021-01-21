using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Classes
{
    // write a method to remove books from the library
    class Library<T> : IEnumerable<T>
    {
        private T[] items = new T[5];
        private int counter;

        public void add(T item)
        {
            if (counter == items.Length)
            {
                //resize it so if count = length, make more room.
                Array.Resize(ref items, items.Length * 2);
            }
            items[counter++] = item;
        }
        public void remove(int indexRemoved)
        {
            //we need to iterate to find which item the user selects, else we remove from the end of the list
            //set the basecase, the index MUSt be within our array boundries.
            // we check our array to find the index that matches the index-to-remove that the user input
            if (indexRemoved > -1 && indexRemoved < counter)
            {
                T[] newItemArr = new T[counter - 1];
                for (int i = 0; i < counter; i++)
                {
                    if (i < indexRemoved)
                    {
                        newItemArr[i] = items[i];
                    }else if(i == indexRemoved)
                    {
                        // we skip this index, thus creating a new array -index we dont want.
                        continue;
                    }
                    else
                    {
                        newItemArr[i - 1] = items[i];
                    }
                }
                counter--;
                items = newItemArr;
            }
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T[] GetArray() => items;
        
    }
}
