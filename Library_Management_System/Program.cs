namespace Library_Management_System;

internal class Program
{
    static void Main(string[] args)
    {
        Librarian librarian = new("Jack", new DateTime(2010, 05, 25));
        LibraryMember libraryMember = new("Jonathon", new DateTime(2020, 04, 12));
        Console.WriteLine(librarian);
        Console.WriteLine(libraryMember);

        Console.WriteLine("---------------------------");

        Book book = new(BookJenre.Fiction, "atOmic haBiTs", new DateTime(2008, 04, 10), new LibraryLocation(2, 5));
        DVD dvd = new("Aistra Mora dvd", null); // publication yeari yoxdur
        book.DisplayInfo();
        dvd.DisplayInfo();
        Console.WriteLine("---------------------------");

        int year = book.CalculateAge();
        int year2 = dvd.CalculateAge();
        Console.WriteLine(year);
        Console.WriteLine(year2); // 0 qaytaracaq cunki dvd'in publication yeari yoxdur

        Console.WriteLine("---------------------------");
        LibraryCatalog catalog = new LibraryCatalog();
        Console.WriteLine(LibraryCatalog.LibraryItems.Length); // nece dene itemimiz oldugunu goruruk, hemcinin butun itemleri bu array'de toplanir
        LibraryItem gettedItemById = catalog[1]; //indexer, id'e gore tapir
        gettedItemById.DisplayInfo();

        Console.WriteLine("---------------");
        LibraryItem gettedItemById2 = catalog[2]; // exception alacagiq (bui id'de item tapilmadi) ve null qaytaracaq 
        gettedItemById2.DisplayInfo();
    }
}
