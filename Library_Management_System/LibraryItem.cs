using System.Text;

namespace Library_Management_System;

class LibraryCatalog
{
    public LibraryItem this[int id] { get => GetItemById(id); }
    private static LibraryItem[] _libraryItems = new LibraryItem[0];
    public static LibraryItem[] LibraryItems { get => _libraryItems; }

    public static void AddItems(LibraryItem libr)
    {
        Array.Resize(ref _libraryItems, _libraryItems.Length + 1);
        _libraryItems[_libraryItems.Length - 1] = libr;
    }

    public static LibraryItem GetItemById(int id) // bu method, yalniz kitabi yox, butun itemleri id'sine gore geri qaytarir
    {
        try
        {
            for (int i = 0; i < LibraryItems.Length; i++)
            {
                if (LibraryItems[i].Id == id)
                    return LibraryItems[i];
            }
            
            throw new CustomBookException($"Bu id'de ({id}) item tapilmadi");
        }
        catch (CustomBookException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}

class CustomBookException : Exception
{
    public CustomBookException(string message) : base(message)
    {
    }
}

abstract class LibraryItem
{
    private static int _id;
    public int Id { get; set; }
    public DateTime? PublicationYear { get; private set; }
    public string Title { get; set; }

    protected LibraryItem(string title, DateTime? publicationYear)
    {
        Id = ++_id;
        Title = title.ToTitleCase();
        PublicationYear = publicationYear;
    }

    public abstract void DisplayInfo();
}

class Book : LibraryItem
{
    private (int aisle, int shelf) _location;
    public (int aisle, int shelf) Location { get => _location; }
    public BookJenre Genre { get; set; }
    public Book(BookJenre genre, string title, DateTime? publicationYear, LibraryLocation location) : base(title, publicationYear)
    {
        _location.shelf = location.Shelf;
        _location.aisle = location.Aisle;
        Genre = genre;
        LibraryCatalog.AddItems(this);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{this.GetType().ToString().Split('.')[^1]} {{ Book Id: {Id}, Book Title: {Title}, Book publication year: {PublicationYear}, Aisle: {Location.aisle}, Shelf: {Location.shelf} }}");
    }
}
class Magazine : LibraryItem
{
    public Magazine(string title, DateTime? publicationYear) : base(title, publicationYear)
    {
        LibraryCatalog.AddItems(this);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{this.GetType().ToString().Split('.')[^1]} {{ Magazine Id: {Id}, Magazine title: {Title}, Magazine publication year: {PublicationYear} }}");
    }
}

class DVD : LibraryItem
{
    public DVD(string title, DateTime? publicationYear) : base(title, publicationYear)
    {
        LibraryCatalog.AddItems(this);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{this.GetType().ToString().Split('.')[^1]} {{ DVD Id: {Id}, DVD title: {Title}, DVD publication year: {PublicationYear} }}");
    }
}

struct LibraryLocation
{
    public int Aisle { get; set; }
    public int Shelf { get; set; }
    public LibraryLocation(int aisle, int shelf)
    {
        Aisle = aisle;
        Shelf = shelf;
    }
}

static class LibraryHelper
{
    public static int CalculateAge(this LibraryItem libraryItem)
    {
        int currentYear = DateTime.Now.Year;
        int itemYear = 0;
        if (libraryItem.PublicationYear == null)
        {
            return 0;
        }

        if (libraryItem.PublicationYear != null)
            itemYear = libraryItem.PublicationYear.Value.Year;
        Console.WriteLine();

        return currentYear - itemYear;
    }

    public static string ToTitleCase(this string title)
    {
        string[] strArr = title.Split(' ');
        string partStr = "";
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < strArr.Length; i++)
        {
            partStr = strArr[i];
            sb.Append(Char.ToUpper(partStr[0]));
            sb.Append(partStr.Substring(1).ToLower());
            sb.Append(' ');
        }

        return sb.ToString();
    }
}

public enum BookJenre
{
    Fiction = 1,
    NonFiction,
    Science,
    Art
}
