namespace Project
{
  /// <summary>
  /// Base Media class
  /// </summary>
  /// <typeparam name="T">Type of the slug</typeparam>
  public class Media<T>
  {
    public T Slug { get; set; }
    public string Title { get; set; }
    public GENRE Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    /// <summary>
    /// Constructs a new Media object
    /// </summary>
    /// <param name="title">The title of the Media</param>
    /// <param name="genre">The genre of the Media</param>
    /// <param name="realeaseDate">The date when it was released</param>
    /// <param name="slug">Used to uniquely identify the Media</param>
    /// <param name="description">The description of the Media</param>
    /// <param name="price">How much it costs in BDT</param>
    public Media(string title, GENRE genre, DateTime realeaseDate, T slug, string description, decimal price)
    {
      Title = title;
      Genre = genre;
      ReleaseDate = realeaseDate;
      Slug = slug;
      Description = description;
      Price = price;
    }

    /// <summary>
    /// Method to display information about the media item
    /// </summary>
    public virtual void DisplayInfo()
    {
      Console.WriteLine($"Title: {Title}");
      Console.WriteLine($"Genre: {Genre}");
      Console.WriteLine($"Release Date: {ReleaseDate.ToShortDateString()}");
      Console.WriteLine($"Slug: {Slug}");
      Console.WriteLine($"Description: {Description}");
      Console.WriteLine($"Price: Tk. {Price}");
    }

    /// <summary>
    /// Calculates the discounted price of the Media object
    /// </summary>
    /// <param name="discountRate">The rate of discount</param>
    /// <exception cref="ArgumentException"></exception>
    public decimal CalculateDiscountPrice(decimal discountRate)
    {
      if (discountRate < 0 || discountRate > 100)
        throw new ArgumentException("Discount rate must be between 0 and 100");
      return Price * (1 - discountRate / 100);
    }

    /// <summary>
    /// Calculates the total price which includes the discount and tax rate
    /// </summary>
    /// <param name="taxRate">The rate of tax</param>
    /// <param name="discountRate">The rate of discount</param>
    /// <exception cref="ArgumentException"></exception>
    public decimal CalculateNetPrice(decimal taxRate, decimal discountRate = 0)
    {
      if (taxRate < 0 || taxRate > 100)
        throw new ArgumentException("Tax rate must be between 0 and 100");
      return CalculateDiscountPrice(discountRate) * (1 + taxRate / 100);
    }

    /// <summary>
    /// Takes input from the user through Console
    /// </summary>
    public static Media<T> TakeInput()
    {
      string title = Input.InputString("Title");
      GENRE genre = Input.InputGenre("Genre");
      DateTime releaseDate = Input.InputDateTime("Release date");
      Console.Write("Slug: ");
      T? slug = (T?)Convert.ChangeType(Console.ReadLine(), typeof(T)) ?? throw new Exception("The provided slug is not valid");
      string description = Input.InputString("Description", defaultValue: "Not provided");
      int price = Input.InputInt("Price", defaultValue: 0);

      // Create and return a new Media object with the provided input
      return new Media<T>(title, genre, releaseDate, slug, description, price);
    }
  }

}