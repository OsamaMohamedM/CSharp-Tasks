using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class Library
    {
        private readonly List<Book> books = new List<Book>();
        private readonly List<Loan> loans = new List<Loan>();
        private int nextCardID = 1;

        public void AddBook(Book book) => books.Add(book);
        public void RemoveBook(Book book) => books.Remove(book);
        public List<Book> GetAllBooks() => books;

        public LibraryCard RequestLibraryCard(User user)
        {
            var card = new LibraryCard(nextCardID++, user.Id);
            user.SetLibraryCard(card);
            return card;
        }

        public void BorrowBook(User user, Book book)
        {
            if (!book.IsAvailable())
            {
                Console.WriteLine("This book is already borrowed.");
                return;
            }
            book.Borrow();
            var loan = new Loan(book, user);
            loans.Add(loan);
            Console.WriteLine($"{user.Name} borrowed '{book.Title}'. Due: {loan.DueDate}");
        }

        public void ReturnBook(User user, Book book)
        {
            var loan = loans.FindLast(l => l.BorrowedBook == book && !l.IsReturned);
            if (loan == null)
            {
                Console.WriteLine("No active loan found for this book.");
                return;
            }

            loan.MarkAsReturned();
            book.Return();

            if (loan.IsOverdue)
                Console.WriteLine($"{user.Name} returned '{book.Title}' (OVERDUE). Returned at {loan.ActualReturnDate}");
            else
                Console.WriteLine($"{user.Name} returned '{book.Title}'. Returned at {loan.ActualReturnDate}");
        }

        public List<Loan> GetLoans() => loans;

        public List<Loan> GetOverdueLoans()
        {
            return loans.Where(l => !l.IsReturned && l.DueDate < DateTime.Now).ToList();
        }
    }
}
