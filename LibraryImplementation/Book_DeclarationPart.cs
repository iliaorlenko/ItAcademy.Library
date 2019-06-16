using System;
using System.Collections.Generic;

namespace LibraryImplementation
{
    public partial class Book
    {
        // Constructor to create a Book object
        public Book(string title, string author, Genre genre)
        {
            Title = title;
            Author = author;
            Genre = genre;
        }

        // Backing fields. Getters and setters are implemented in Book_ImplementationPart.cs
        private string _title;
        private string _author;
        
        // Book auto properties
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Client CheckedOutBy { get; set; }
        public List<KeyValuePair<DateTime, Client>> CheckoutHistory { get; set; }
    }

    // Genres enumeration
    public enum Genre
    {
        Scientific,
        Fiction,
        IT,
        History
    }
}
