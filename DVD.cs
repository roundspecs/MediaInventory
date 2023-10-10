namespace Project
{
  /// <summary>
  /// A child of Media class to represent DVDs
  /// </summary>
  public partial class DVD : Media<string>
  {
    public string Director { get; set; }
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// Constructs a new DVD object
    /// </summary>
    /// <param name="title">The title of the Media</param>
    /// <param name="director">The author of the Media</param>
    /// <param name="duration">Duration of the DVD</param>
    /// <param name="genre">The genre of the Media</param>
    /// <param name="realeaseDate">The date when it was released</param>
    /// <param name="slug">Used to uniquely identify the Media</param>
    /// <param name="description">The description of the Media</param>
    /// <param name="price">How much it costs in BDT</param>
    public DVD(string title, string director, TimeSpan duration, GENRE genre, DateTime realeaseDate, string slug, string description = "Not provided", decimal price = 0) : base(title, genre, realeaseDate, slug, description, price)
    {
      Director = director;
      Duration = duration;
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Director: {Director}");
      Console.WriteLine($"Duration in minuts: {Duration.TotalMinutes}");
    }

    public static new DVD TakeInput()
    {
      DVD media = (DVD)Media<string>.TakeInput();
      media.Director = Input.InputString("Director");
      media.Duration = Input.InputTimeSpan("Duration");
      return media;
    }
  }
}