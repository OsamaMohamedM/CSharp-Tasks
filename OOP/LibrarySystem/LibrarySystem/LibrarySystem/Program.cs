using System;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
            var librarian = new Librarian(1, "Osama");

          
            var b1 = new Book(1, "The Hobbit", "No one");
            var b2 = new Book(2, "no problem", "Mohamed Ahmed");
            var b3 = new Book(3, "C# Programming", "Microsoft");

            librarian.AddBook(library, b1);
            librarian.AddBook(library, b2);
            librarian.AddBook(library, b3);

            var user = new User(101, "Osos");
            library.RequestLibraryCard(user);

            Console.WriteLine("Welcome to Library System");
            Console.WriteLine("Are you a User or Librarian?");
            Console.WriteLine("1. User");
            Console.WriteLine("2. Librarian");
            Console.Write("Choose: ");
            string roleChoice = Console.ReadLine();

            if (roleChoice == "1")
            {
                while (true)
                {
                    Console.WriteLine("\n--- User Menu ---");
                    Console.WriteLine("1. Display Books");
                    Console.WriteLine("2. Borrow Book");
                    Console.WriteLine("3. Return Book");
                    Console.WriteLine("4. Display All Loans");
                    Console.WriteLine("5. Display Overdue Loans");
                    Console.WriteLine("0. Exit");
                    Console.Write("Choose option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            librarian.DisplayBooks(library);
                            break;
                        case "2":
                            Console.Write("Enter Book ID to borrow: ");
                            if (int.TryParse(Console.ReadLine(), out int borrowId))
                            {
                                var bookToBorrow = library.GetAllBooks().Find(b => b.Id == borrowId);
                                if (bookToBorrow != null) user.BorrowBook(library, bookToBorrow);
                                else Console.WriteLine("Book not found.");
                            }
                            else Console.WriteLine("Invalid ID");
                            break;
                        case "3":
                            Console.Write("Enter Book ID to return: ");
                            if (int.TryParse(Console.ReadLine(), out int returnId))
                            {
                                var bookToReturn = library.GetAllBooks().Find(b => b.Id == returnId);
                                if (bookToReturn != null) user.ReturnBook(library, bookToReturn);
                                else Console.WriteLine("Book not found.");
                            }
                            else Console.WriteLine("Invalid ID");
                            break;
                        case "4":
                            Console.WriteLine("Loans History:");
                            foreach (var loan in library.GetLoans())
                                Console.WriteLine(loan.GetInfo());
                            break;
                        case "5":
                            Console.WriteLine("Overdue Loans:");
                            var overdue = library.GetOverdueLoans();
                            if (overdue.Count == 0) Console.WriteLine("No overdue loans.");
                            foreach (var ln in overdue) Console.WriteLine(ln.GetInfo());
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            else if (roleChoice == "2")
            {
              
                while (true)
                {
                    Console.WriteLine("\n--- Librarian Menu ---");
                    Console.WriteLine("1. Display Books");
                    Console.WriteLine("2. Add Book");
                    Console.WriteLine("3. Remove Book");
                    Console.WriteLine("4. Display All Loans");
                    Console.WriteLine("0. Exit");
                    Console.Write("Choose option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            librarian.DisplayBooks(library);
                            break;
                        case "2":
                            Console.Write("Enter Book Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();
                            int newId = library.GetAllBooks().Count + 1;
                            var newBook = new Book(newId, title, author);
                            librarian.AddBook(library, newBook);
                            break;
                        case "3":
                            Console.Write("Enter Book ID to remove: ");
                            if (int.TryParse(Console.ReadLine(), out int removeId))
                            {
                                var bookToRemove = library.GetAllBooks().Find(b => b.Id == removeId);
                                if (bookToRemove != null) librarian.RemoveBook(library, bookToRemove);
                                else Console.WriteLine("Book not found.");
                            }
                            else Console.WriteLine("Invalid ID");
                            break;
                        case "4":
                            Console.WriteLine("Loans History:");
                            foreach (var loan in library.GetLoans())
                                Console.WriteLine(loan.GetInfo());
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid role selected. Exiting...");
            }
        }
    }
}
