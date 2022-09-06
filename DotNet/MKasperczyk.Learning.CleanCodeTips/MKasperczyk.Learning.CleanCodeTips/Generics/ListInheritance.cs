using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKasperczyk.Learning.CleanCodeTips.Generics;

public class Examples
{
    public void Main()
    {
        // Cleaner:
        CleanerLibrary library = new CleanerLibrary();
        var result = library.Books.GetFavouriteBook();
        Console.WriteLine(result);

        // Worst: 
        WorstLibrary secoundLibrary = new WorstLibrary();
        var secoundResult = GetFavouriteBook(secoundLibrary);
        Console.WriteLine(secoundResult);
    }
    public string GetFavouriteBook(WorstLibrary library)
    {
        return library.Books.First(x => x.StartsWith("J"));
    }
}

public class Books : List<string>
{
    public string GetFavouriteBook()
    {
        return this.First(x => x.StartsWith("J"));
    }
}

public class CleanerLibrary
{
    public Books Books { get; set; }
}

public class WorstLibrary
{
    public List<string> Books { get; set; }
}

