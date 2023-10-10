namespace Project
{
  /// <summary>
  /// A child of Media class to represent CDs
  /// </summary>
  public partial class CD : Media<string>
  {
    public string Artist { get; set; }
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// Constructs a new CD object
    /// </summary>
    /// <param name="title">The title of the Media</param>
    /// <param name="artist">The author of the Media</param>
    /// <param name="duration">Duration of the CD</param>
    /// <param name="genre">The genre of the Media</param>
    /// <param name="realeaseDate">The date when it was released</param>
    /// <param name="slug">Used to uniquely identify the Media</param>
    /// <param name="description">The description of the Media</param>
    /// <param name="price">How much it costs in BDT</param>
    public CD(string title, string artist, TimeSpan duration, GENRE genre, DateTime realeaseDate, string slug, string description = "Not provided", decimal price = 0) : base(title, genre, realeaseDate, slug, description, price)
    {
      Artist = artist;
      Duration = duration;
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"Artist: {Artist}");
      Console.WriteLine($"Duration in minutes: {Duration.Minutes}");
    }
    public static new CD TakeInput()
    {
      CD media = (CD)Media<string>.TakeInput();
      media.Artist = Input.InputString("Artist");
      media.Duration = Input.InputTimeSpan("Duration");
      return media;
    }
  }
}