using System;
using System.Collections.Generic;

namespace LibraryImplementation
{
    public partial class Book
    {
        // Getters and setters implementation
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value == null)
                    Console.WriteLine("Invalid book instance. Title is required.");
                else
                    _title = value;
            }
        }
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                if (value == null)
                    Console.WriteLine("Invalid book instance. Author is required.");
                else
                    _author = value;
            }
        }

        // Method to display book information
        public void ShowBookInfo()
        {
            // Display basic text lines
            Console.WriteLine("=======================Book Information========================");
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Author: {0}", Author);
            Console.WriteLine("Genre: {0}", Genre);
            Console.WriteLine("Is available: {0}", IsAvailable);

            // Check if a book is checked out and if yes, display name of a Client who checked out 
            if (CheckedOutBy != null)
                Console.WriteLine("Checked out by: {0} {1}", CheckedOutBy.FirstName, CheckedOutBy.LastName);

            //  Check if CheckoutHistory dictionary is initialized and if yes, display full content of CheckoutHistory
            if (CheckoutHistory != null)
            {
                Console.WriteLine("Checkout History:");
                // Display each pair of checkout date and client
                foreach(KeyValuePair<DateTime, Client> Checkout in CheckoutHistory)
                    Console.WriteLine("{0} - {1} {2}", Checkout.Key, Checkout.Value.FirstName, Checkout.Value.LastName);
            }
            // Display separator line
            Console.WriteLine("===============================================================");

        }

        // Method to update book object basic information
        public void UpdateBook(string title, string author, Genre genre)
        {
            Title = title;
            Author = author;
            Genre = genre;
        }
    }
}
