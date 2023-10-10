using System.Collections;

namespace Project
{
  public class MediaInventory : IEnumerable
  {
    /// <summary>
    /// List of all medias in the Inventory
    /// </summary>
    private List<Media<string>> _medias = new List<Media<string>>();

    /// <summary>
    /// Enumerator of the Media Inventory as a method of IEnumerable interface
    /// </summary>

    public IEnumerator GetEnumerator()
    {
      return _medias.GetEnumerator();
    }

    /// <summary>
    /// Add one or more Media objects in the inventory
    /// </summary>
    /// <param name="medias"></param>
    public void AddMedia(params Media<string>[] medias)
    {
      foreach (Media<string> media in medias)
        _medias.Add(media);
    }

    public static void DisplayInfo(List<Media<string>> medias)
    {
      if (medias.Count == 0) Console.WriteLine("The inventory is empty");
      foreach (var media in medias)
      {
        media.DisplayInfo();
        Console.WriteLine("---------------------------");
      }
    }
    public void DisplayInfo() => DisplayInfo(_medias);

    /// <summary>
    /// Get a collection of Media objects of a specific type
    /// </summary>
    /// <typeparam name="T">Type of Media</typeparam>
    public IEnumerable<T> GetMediasOfType<T>() where T : Media<string> => _medias.Where(m => m is T).Cast<T>();

    /// <summary>
    /// Access media by slug
    /// </summary>
    /// <param name="slug">The slug of media to be searched</param>
    public Media<string>? this[string slug]
    {
      get => _medias.FirstOrDefault(m => m.Slug == slug);
      private set { }
    }

    /// <summary>
    /// Removes all media items released before the specified year
    /// </summary>
    /// <param name="year">The year to compare against for removal</param>
    public void RemoveAllBeforeYear(int year) => _medias.RemoveAll(m => m.ReleaseDate.Year < year);

    /// <summary>
    /// Removes all media items released after the specified year
    /// </summary>
    /// <param name="year">The year to compare against for removal</param>
    public void RemoveAllAfterYear(int year) => _medias.RemoveAll(m => m.ReleaseDate.Year > year);

    /// <summary>
    /// Removes all media items released in the specified year
    /// </summary>
    /// <param name="year">The year to compare against for removal</param>
    public void RemoveAllInYear(int year) => _medias.RemoveAll(m => m.ReleaseDate.Year == year);

    /// <summary>
    /// Removes all media items with the specified genre
    /// </summary>
    /// <param name="genre">The genre to compare against for removal</param>
    public void RemoveAllWithGenre(GENRE genre) => _medias.RemoveAll(m => m.Genre == genre);

    /// <summary>
    /// Removes all media items with the specified price
    /// </summary>
    /// <param name="price">The price to compare against for removal</param>
    public void RemoveAllWithPrice(decimal price) => _medias.RemoveAll(m => m.Price == price);

    /// <summary>
    /// Removes all media items with a price above the specified value
    /// </summary>
    /// <param name="price">The price to compare against for removal</param>
    public void RemoveAllWithPriceAbove(decimal price) => _medias.RemoveAll(m => m.Price > price);

    /// <summary>
    /// Removes all media items with a price below the specified value
    /// </summary>
    /// <param name="price">The price to compare against for removal</param>
    public void RemoveAllWithPriceBelow(decimal price) => _medias.RemoveAll(m => m.Price < price);
  }
}