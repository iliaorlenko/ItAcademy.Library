using System;
using System.Collections.Generic;

namespace LibraryImplementation
{
    public class Client
    {
        // Constructor to create a Client object
        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            TotalClientCheckouts = 0;
            ClientRank = ClientRank.Paper;
            BooksCheckedOut = new List<Book>();
        }

        // indexer of checked out books list
        public Book this [int index]
        {
            get
            {
                return BooksCheckedOut[index];
            }

            set
            {
                BooksCheckedOut[index] = value;
            }
        }

        // Client auto properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private ushort TotalClientCheckouts { get; set; }
        public ClientRank ClientRank { get; private set; }
        public List<Book> BooksCheckedOut { get; private set; }

        // Method to check out a book
        public void CheckOutBook(Book book)
        {
            // Check a book is not null
            if (book == null)
            {
                Console.WriteLine("Book is not found.");
                return;
            }
            else
            // Check a book is available to check out
                if (!book.IsAvailable)
            {
                // Check if a book is already checked out by this Client
                if (book.CheckedOutBy == this)
                    Console.WriteLine("This book is already checked out by you.");
                else
                    Console.WriteLine("\"{0}\" is already checked out by other client ({1} {2}).", book.Title, book.CheckedOutBy.FirstName, book.CheckedOutBy.LastName);
                return;
            }
            // Check client rank allows to check out a book
            else
                if (BooksCheckedOut.Count > (int)ClientRank)
            {
                Console.WriteLine("Your rank doesn't allow you to check out more books.");
                return;
            }
            // If all checks are passed - check out a book
            else
            {
                // Initialize Book CheckoutHistory if it is null yet
                if(book.CheckoutHistory == null)
                    book.CheckoutHistory = new List<KeyValuePair<DateTime, Client>>();
                // Add checkout record to a Book's CheckoutHistory
                book.CheckoutHistory.Add(new KeyValuePair<DateTime, Client>(DateTime.Now, this));
                // Set IsAvailable flag to false to do not allow checkout to somebody else
                book.IsAvailable = false;
                // Set client who had checkout a book
                book.CheckedOutBy = this;
                // Add checkedd out book to Client's current checkouts
                BooksCheckedOut.Add(book);
                // Increment Client's total checkouts
                TotalClientCheckouts++;
                // Re-calculate Client's rank according to this checkout operation
                RankCheckAndUpdate();
                // Display checkout operation info
                Console.WriteLine("\"{0}\" has been checked out by {1} {2}", book.Title, FirstName, LastName);
            }
        }

        // Method to check in a book
        public void CheckInBook(Book book)
        {
            // Check a book is not null
            if(book == null)
            {
                Console.WriteLine("Book is not found.");
                return;
            }
            else
            // Check client actually has a book to check in
                if (!BooksCheckedOut.Contains(book))
            {
                Console.WriteLine("You don't have {0} to check it in.", book.Title);
                return;
            }
            else
            // If all checks are passed - check in a book
            {
                book.IsAvailable = true;
                book.CheckedOutBy = null;
                BooksCheckedOut.Remove(book);
                Console.WriteLine("\"{0}\" has been checked in.", book.Title);
            }
        }

        // Method to check ClientRank and update it if needed
        private void RankCheckAndUpdate()
        {
            if (TotalClientCheckouts < 3)
                ClientRank = ClientRank.Paper;
            else if (TotalClientCheckouts >= 3 && TotalClientCheckouts < 5)
                ClientRank = ClientRank.Wood;
            else if (TotalClientCheckouts >= 5)
                ClientRank = ClientRank.Steel;
            else
                Console.WriteLine("Something is wrong with your ranking.");
        }

        // Method to display Client information
        public void ShowClientInfo()
        {
            // Display basic Client info
            Console.WriteLine("=======================Client Information========================");
            Console.WriteLine("Full Name: {0} {1}", FirstName, LastName);
            Console.WriteLine("Total checkouts: {0}", TotalClientCheckouts);
            Console.WriteLine("Client Rank: {0}", ClientRank);

            // Check if Clinet has checked out books and if yes, display each of them
            if(BooksCheckedOut.Count != 0)
            {
                Console.WriteLine("Currently checked out {0} books:", BooksCheckedOut.Count);
                foreach (Book book in BooksCheckedOut)
                    Console.WriteLine("- \"{0}\"", book.Title);
            }
            // Display separator line
            Console.WriteLine("================================================================");
        }
    }

    // Client rank shows how many books client can check out at the same time
    public enum ClientRank
    {
        Paper = 1,
        Wood = 3,
        Steel = 5
    }
}
