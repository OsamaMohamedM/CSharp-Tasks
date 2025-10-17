using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public LibraryCard Card { get; private set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SetLibraryCard(LibraryCard card)
        {
            Card = card;
        }

        public void BorrowBook(Library library, Book book)
        {
            if (Card == null)
            {
                Console.WriteLine("You must have a library card to borrow books!");
                return;
            }
            library.BorrowBook(this, book);
        }

        public void ReturnBook(Library library, Book book)
        {
            if (Card == null)
            {
                Console.WriteLine("You must have a library card to return books!");
                return;
            }
            library.ReturnBook(this, book);
        }
    }
}
