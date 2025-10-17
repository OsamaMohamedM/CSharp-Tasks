using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class Librarian
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Librarian(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddBook(Library library, Book book)
        {
            library.AddBook(book);
            Console.WriteLine($"{Name} added {book.Title} to the library.");
        }

        public void RemoveBook(Library library, Book book)
        {
            library.RemoveBook(book);
            Console.WriteLine($"{Name} removed {book.Title} from the library.");
        }

        public void DisplayBooks(Library library)
        {
            Console.WriteLine("Books in Library:");
            foreach (var book in library.GetAllBooks())
            {
                Console.WriteLine(book.GetInfo());
            }
        }
    }
}
