namespace Project
{
  // LINQ Methods
  public partial class Book
  {
    /// <summary>
    /// Find books which were released after a specific year
    /// </summary>
    /// <param name="books">A collection of Book objects</param>
    /// <param name="year">The year after which the books were released</param>
    public static IEnumerable<Book> ReleasedAfter(IEnumerable<Book> books, int year)
    {
      return books.Where(b => b.ReleaseDate.Year > year);
    }
    /// <summary>
    /// Get the average number of pages in the collection of books
    /// </summary>
    /// <param name="books">A collection of Book objects</param>
    public static double AveragePageCount(IEnumerable<Book> books)
    {
      return books.Average(b => b.PageCount);
    }
    /// <summary>
    /// Get the average price of the books in the collection
    /// </summary>
    /// <param name="books">A collection of Book objects</param>

    public static decimal AveragePrice(IEnumerable<Book> books)
    {
      return books.Average(b => b.Price);
    }
    /// <summary>
    /// Get the price of the most expensive book
    /// </summary>
    /// <param name="books">A collection of Book objects</param>

    public static decimal MaxPrice(IEnumerable<Book> books)
    {
      return books.Max(b => b.Price);
    }
    /// <summary>
    /// Get the price of the least expensive book
    /// </summary>
    /// <param name="books">A collection of Book objects</param>

    public static decimal MinPrice(IEnumerable<Book> books)
    {
      return books.Min(b => b.Price);
    }
    /// <summary>
    /// Get the number of pages of the thinnest book
    /// </summary>
    /// <param name="books">A collection of Book objects</param>

    public static int Thinnest(IEnumerable<Book> books)
    {
      return books.Min(b => b.PageCount);
    }
    /// <summary>
    /// Get the number of pages of the thickest book
    /// </summary>
    /// <param name="books">A collection of Book objects</param>

    public static int Thickest(IEnumerable<Book> books)
    {
      return books.Max(b => b.PageCount);
    }
    /// <summary>
    /// Search book by name of Author
    /// </summary>
    /// <param name="books">A collection of Book objects</param>
    /// <param name="author">The name of the author</param>

    public static IEnumerable<Book> FindBooksByAuthor(IEnumerable<Book> books, string author)
    {
      return books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
    }
    /// <summary>
    /// Seach books by genre
    /// </summary>
    /// <param name="books">A collection of Book objects</param>
    /// <param name="genre">The genre to be searched</param>

    public static IEnumerable<Book> FindBooksByGenre(IEnumerable<Book> books, GENRE genre)
    {
      return books.Where(b => b.Genre == genre);
    }
  }

  public partial class CD
  {
    /// <summary>
    /// Find CD by name of artist
    /// </summary>
    /// <param name="cds">A collection of CD objects</param>
    /// <param name="artist">Name of the artist</param>

    public static IEnumerable<CD> FindCDsByArtist(IEnumerable<CD> cds, string artist)
    {
      return cds.Where(c => c.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase));
    }
    /// <summary>
    /// Find the total duration of the CDs
    /// </summary>
    /// <param name="cds">A collection of CD objects</param>

    public static TimeSpan TotalDuration(IEnumerable<CD> cds)
    {
      return TimeSpan.FromMinutes(cds.Sum(c => c.Duration.TotalMinutes));
    }
    /// <summary>
    /// Group CDs baed on genre
    /// </summary>
    /// <param name="cds">A collection of CD objects</param>

    public static IEnumerable<IGrouping<GENRE, CD>> GroupCDsByGenre(IEnumerable<CD> cds)
    {
      return cds.GroupBy(c => c.Genre);
    }
    /// <summary>
    /// Find CDs which were released after a specific year
    /// </summary>
    /// <param name="cds">A collection of CD objects</param>
    /// <param name="year">The year after which the CDs were released</param>

    public static IEnumerable<CD> ReleasedAfter(IEnumerable<CD> cds, int year)
    {
      return cds.Where(c => c.ReleaseDate.Year > year);
    }
    /// <summary>
    /// Get the average price in the collection of CDs
    /// </summary>
    /// <param name="cds">A collection of CD objects</param>

    public static decimal AveragePrice(IEnumerable<CD> cds)
    {
      return cds.Average(c => c.Price);
    }
    /// <summary>
    /// Get the price of the most expensive CD
    /// </summary>
    /// <param name="cds">A collection of CD objects</param>

    public static decimal MaxPrice(IEnumerable<CD> cds)
    {
      return cds.Max(c => c.Price);
    }
    /// <summary>
    /// Get the price of the least expensive CDs
    /// </summary>
    /// <param name="cds">A collection of CD objects</param>

    public static decimal MinPrice(IEnumerable<CD> cds)
    {
      return cds.Min(d => d.Price);
    }
  }

  public partial class DVD
  {
    /// <summary>
    /// Find CD by name of director
    /// </summary>
    /// <param name="dvds">A collection of DVD objects</param>
    /// <param name="director">Name of the director</param>

    public static IEnumerable<DVD> FindDVDsByDirector(IEnumerable<DVD> dvds, string director)
    {
      return dvds.Where(d => d.Director.Equals(director, StringComparison.OrdinalIgnoreCase));
    }
    /// <summary>
    /// Find the total duration of the DVDs
    /// </summary>
    /// <param name="dvds">A collection of DVD objects</param>

    public static TimeSpan TotalDuration(IEnumerable<DVD> dvds)
    {
      return TimeSpan.FromMinutes(dvds.Sum(d => d.Duration.TotalMinutes));
    }
    /// <summary>
    /// Group DVDs baed on genre
    /// </summary>
    /// <param name="dvds">A collection of DVD objects</param>

    public static IEnumerable<IGrouping<GENRE, DVD>> GroupDVDsByGenre(IEnumerable<DVD> dvds)
    {
      return dvds.GroupBy(d => d.Genre);
    }
    /// <summary>
    /// Find DVDs which were released after a specific year
    /// </summary>
    /// <param name="dvds">A collection of DVD objects</param>
    /// <param name="year">The year after which the DVDs were released</param>

    public static IEnumerable<DVD> ReleasedAfter(IEnumerable<DVD> dvds, int year)
    {
      return dvds.Where(d => d.ReleaseDate.Year > year);
    }
    /// <summary>
    /// Get the average price in the collection of DVDs
    /// </summary>
    /// <param name="dvds">A collection of DVD objects</param>

    public static decimal AveragePrice(IEnumerable<DVD> dvds)
    {
      return dvds.Average(d => d.Price);
    }
    /// <summary>
    /// Get the price of the most expensive DVD
    /// </summary>
    /// <param name="dvds">A collection of DVD objects</param>

    public static decimal MaxPrice(IEnumerable<DVD> dvds)
    {
      return dvds.Max(d => d.Price);
    }
    /// <summary>
    /// Get the price of the least expensive DVDs
    /// </summary>
    /// <param name="dvds">A collection of DVD objects</param>

    public static decimal MinPrice(IEnumerable<DVD> dvds)
    {
      return dvds.Min(d => d.Price);
    }
  }

}