using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class Loan
    {
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ActualReturnDate { get; private set; }
        public Book BorrowedBook { get; set; }
        public User Borrower { get; set; }
        public bool IsReturned { get; private set; }
        public bool IsOverdue { get; private set; }

        public Loan(Book book, User user)
        {
            BorrowDate = DateTime.Now;
            DueDate = BorrowDate.AddDays(14);
            BorrowedBook = book;
            Borrower = user;
            IsReturned = false;
            IsOverdue = false;
            ActualReturnDate = null;
        }

        public void MarkAsReturned()
        {
            ActualReturnDate = DateTime.Now;
            IsReturned = true;
            IsOverdue = ActualReturnDate > DueDate;
        }

        public string GetInfo()
        {
            if (IsReturned)
            {
                var overdueText = IsOverdue ? " (OVERDUE)" : "";
                return $"Book: [{BorrowedBook.Id}] {BorrowedBook.Title}, User: {Borrower.Name}, Borrowed: {BorrowDate}, Returned: {ActualReturnDate}{overdueText}";
            }
            else
            {
                return $"Book: [{BorrowedBook.Id}] {BorrowedBook.Title}, User: {Borrower.Name}, Borrowed: {BorrowDate}, Due: {DueDate}";
            }
        }
    }
}