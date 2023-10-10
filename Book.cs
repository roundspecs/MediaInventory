namespace Project
{
  /// <summary>
  /// A child of Media class to represent Books
  /// </summary>
  public partial class Book : Media<string>
  {
    public string Author { get; set; }
    public int PageCount { get; set; }
    public string ISBN { get; set; }

    /// <summary>
    /// Constructs a new Book object
    /// </summary>
    /// <param name="title">The title of the Media</param>
    /// <param name="author">The author of the Media</param>
    /// <param name="isbn">Identifier of the book</param>
    /// <param name="pageCount">Number of pages in the book</param>
    /// <param name="genre">The genre of the Media</param>
    /// <param name="realeaseDate">The date when it was released</param>
    /// <param name="slug">Used to uniquely identify the Media</param>
    /// <param name="description">The description of the Media</param>
    /// <param name="price">How much it costs in BDT</param>
    public Book(string title, string author, string isbn, int pageCount, GENRE genre, DateTime realeaseDate, string slug, string description = "Not provided", decimal price = 0) : base(title, genre, realeaseDate, slug, description, price)
    {
      Author = author;
      ISBN = isbn;
      PageCount = pageCount;
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Author: {Author}");
      Console.WriteLine($"Page Count: {PageCount}");
      Console.WriteLine($"ISBN: {ISBN}");
    }

    public static new Book TakeInput()
    {
      Media<string> media = Media<string>.TakeInput();
      return new Book(
        title: media.Title,
        author: Input.InputString("Author"),
        isbn: Input.InputString("ISBN"),
        pageCount: Input.InputInt("Number of Pages"),
        genre: media.Genre,
        realeaseDate: media.ReleaseDate,
        slug: media.Slug,
        description: media.Description,
        price: media.Price
      );
    }
  }
}