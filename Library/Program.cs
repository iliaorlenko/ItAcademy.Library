using LibraryImplementation;
using System;

namespace LibraryMgmt
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initialize Books
            Book CatcherInTheRye = new Book("The Catcher in the Rye", "J. D. Salinger", Genre.Fiction);
            Book RomeoAndJuliet = new Book("Romeo and Juliet", "W. Shakespeare", Genre.Fiction);
            Book BriefHistoryofTime = new Book("A Brief History of Time", "S. Hawking", Genre.Scientific);
            Book OriginofSpecies = new Book("On the Origin of Species", "C. Darwin", Genre.Scientific);
            Book MurachsCS = new Book("Murach’s C#", "J. Murach", Genre.IT);
            Book ComputerNetworks = new Book("Computer Networks", "A. S. Tanenbaum", Genre.IT);
            Book TheCrusades = new Book("The Crusades", "T. Asbridge", Genre.History);
            Book GunsGermsSteel = new Book("Guns, Germs, and Steel", "J. Diamond", Genre.History);
            #endregion

            #region Initialize Clients
            Client John = new Client("John", "Doe");
            Client Bob = new Client("Bob", "Marley");
            Client Chris = new Client("Chris", "Novoselic");
            Client Matt = new Client("Matt", "Shadows");
            #endregion

            John.ShowClientInfo();
            John.CheckOutBook(CatcherInTheRye);
            John.CheckOutBook(BriefHistoryofTime);
            John.CheckInBook(BriefHistoryofTime);
            John.CheckOutBook(RomeoAndJuliet);
            John.CheckInBook(RomeoAndJuliet);
            Bob.CheckOutBook(RomeoAndJuliet);
            Bob.CheckInBook(RomeoAndJuliet);
            Chris.CheckOutBook(RomeoAndJuliet);
            John.CheckOutBook(MurachsCS);
            Bob.CheckOutBook(MurachsCS);
            Bob.ShowClientInfo();
            RomeoAndJuliet.ShowBookInfo();
            John.ShowClientInfo();

            // Case of indexator using
            Console.WriteLine(John[1].Title);

            Console.ReadKey();
        }
    }
}
