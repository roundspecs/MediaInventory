namespace Project
{
  public class Driver
  {
    public static void Main(string[] args)
    {
      /// These are just placeholder values
      var placeholderMedias = new Media<string>[] {
          new Book("The Catcher in the Rye", "J.D. Salinger", "978-0-316-76948-0", 277, GENRE.Fiction, new DateTime(1951, 7, 16), "catcher-in-the-rye", price: 200),
          new Book("To Kill a Mockingbird", "Harper Lee", "978-0-06-112008-4", 324, GENRE.Fiction, new DateTime(1960, 7, 11), "to-kill-a-mockingbird", price: 150),
          new Book("1984", "George Orwell", "978-0-452-28423-4", 328, GENRE.ScienceFiction, new DateTime(1949, 6, 8), "1984", price: 180),
          new Book("The Hobbit", "J.R.R. Tolkien", "978-0-261-10237-2", 366, GENRE.Fantasy, new DateTime(1937, 9, 21), "the-hobbit", price: 250),
          new Book("Steve Jobs", "Walter Isaacson", "978-1-4516-4853-9", 656, GENRE.Biography, new DateTime(2011, 10, 24), "steve-jobs", price: 155),
          new Book("A Brief History of Time", "Stephen Hawking", "978-0-553-10953-5", 256, GENRE.ScienceFiction, new DateTime(1988, 4, 1), "brief-history-of-time", price: 250),
          new CD("Thriller", "Michael Jackson", TimeSpan.FromMinutes(42), GENRE.Pop, new DateTime(1982, 11, 30), "thriller", price: 190),
          new CD("The Dark Side of the Moon", "Pink Floyd", TimeSpan.FromMinutes(43), GENRE.Rock, new DateTime(1973, 3, 1), "dark-side-of-the-moon", price: 350),
          new CD("Kind of Blue", "Miles Davis", TimeSpan.FromMinutes(55), GENRE.Jazz, new DateTime(1959, 8, 17), "kind-of-blue", price: 120),
          new CD("Johnny Cash at Folsom Prison", "Johnny Cash", TimeSpan.FromMinutes(51), GENRE.Country, new DateTime(1968, 5, 30), "folsom-prison", price: 350),
          new CD("Random Access Memories", "Daft Punk", TimeSpan.FromMinutes(74), GENRE.Electronic, new DateTime(2013, 5, 17), "random-access-memories", price: 130),
          new DVD("Inception", "Christopher Nolan", TimeSpan.FromMinutes(148), GENRE.ScienceFiction, new DateTime(2010, 7, 8), "inception"),
          new DVD("The Shawshank Redemption", "Frank Darabont", TimeSpan.FromMinutes(142), GENRE.Drama, new DateTime(1994, 9, 10), "shawshank-redemption", price: 230),
          new DVD("Pulp Fiction", "Quentin Tarantino", TimeSpan.FromMinutes(154), GENRE.Crime, new DateTime(1994, 10, 14), "pulp-fiction", price: 180),
          new DVD("The Matrix", "The Wachowskis", TimeSpan.FromMinutes(136), GENRE.Action, new DateTime(1999, 3, 31), "the-matrix", price: 300),
          new DVD("The Lord of the Rings: The Fellowship of the Ring", "Peter Jackson", TimeSpan.FromMinutes(178), GENRE.Fantasy, new DateTime(2001, 12, 19), "fellowship-of-the-ring", price: 150),
      };

      MediaInventory mediaInventory = new();

      Input addMenu = new("What do you want to add?");
      addMenu.Add("Book", () => mediaInventory.AddMedia(Book.TakeInput()));
      addMenu.Add("CD", () => mediaInventory.AddMedia(CD.TakeInput()));
      addMenu.Add("DVD", () => mediaInventory.AddMedia(DVD.TakeInput()));
      addMenu.Add("Some default media", () => mediaInventory.AddMedia(placeholderMedias.ToArray()));

      Input removeByYearMenu = new("Select a filter");
      removeByYearMenu.Add("Remove all before a specific year", () => mediaInventory.RemoveAllBeforeYear(Input.InputInt("Year")));
      removeByYearMenu.Add("Remove all after a specific year", () => mediaInventory.RemoveAllAfterYear(Input.InputInt("Year")));
      removeByYearMenu.Add("Remove all in a specific year", () => mediaInventory.RemoveAllInYear(Input.InputInt("Year")));

      Input removeByPriceMenu = new("Select a filter");
      removeByPriceMenu.Add("Remove all less than a specific price", () => mediaInventory.RemoveAllWithPriceBelow(Input.InputInt("Price")));
      removeByPriceMenu.Add("Remove all greater than a specific price", () => mediaInventory.RemoveAllWithPriceAbove(Input.InputInt("Price")));
      removeByPriceMenu.Add("Remove all of a specific price", () => mediaInventory.RemoveAllWithPrice(Input.InputInt("Price")));

      Input removeMenu = new("Select a filter");
      removeMenu.Add("Remove by year", removeByYearMenu.Ask);
      removeMenu.Add("Remove by price", removeByPriceMenu.Ask);
      removeMenu.Add("Remove all by genre", () => mediaInventory.RemoveAllWithGenre(Input.InputGenre("Pick a genre")));

      Input filterBook = new("Select a filter");
      filterBook.Add("Filter by author", () => MediaInventory.DisplayInfo(
        Book.FindBooksByAuthor(
          mediaInventory.GetMediasOfType<Book>(),
          Input.InputString("Author")
        ).Cast<Media<string>>().ToList()
      ));
      filterBook.Add("Filter by genre", () => MediaInventory.DisplayInfo(
        Book.FindBooksByGenre(
          mediaInventory.GetMediasOfType<Book>(),
          Input.InputGenre("Genre")
        ).Cast<Media<string>>().ToList()
      ));

      Input filterCD = new("Select a filter");
      filterBook.Add("Filter by artist", () => MediaInventory.DisplayInfo(
        CD.FindCDsByArtist(
          mediaInventory.GetMediasOfType<CD>(),
          Input.InputString("Artist")
        ).Cast<Media<string>>().ToList()
      ));

      Input filterDVD = new("Select a filter");
      filterBook.Add("Filter by director", () => MediaInventory.DisplayInfo(
        DVD.FindDVDsByDirector(
          mediaInventory.GetMediasOfType<DVD>(),
          Input.InputString("Director")
        ).Cast<Media<string>>().ToList()
      ));

      Input filterMenu = new("What would you like to filter?");
      filterMenu.Add("Book", filterBook.Ask);
      filterMenu.Add("CD", filterCD.Ask);
      filterMenu.Add("DVD", filterDVD.Ask);

      Input bookStats = new("What do you want to know?");
      bookStats.Add("Average page count", () => Console.WriteLine("=> " + Book.AveragePageCount(mediaInventory.GetMediasOfType<Book>())));
      bookStats.Add("Average price", () => Console.WriteLine("=> " + Book.AveragePrice(mediaInventory.GetMediasOfType<Book>())));
      bookStats.Add("Max price", () => Console.WriteLine("=> Tk. " + Book.MaxPrice(mediaInventory.GetMediasOfType<Book>())));
      bookStats.Add("Min price", () => Console.WriteLine("=> Tk. " + Book.MinPrice(mediaInventory.GetMediasOfType<Book>())));
      bookStats.Add("Page count of thinnest book", () => Console.WriteLine("=> " + Book.Thinnest(mediaInventory.GetMediasOfType<Book>())));
      bookStats.Add("Page count of thickest book", () => Console.WriteLine("=> " + Book.Thickest(mediaInventory.GetMediasOfType<Book>())));

      Input cdStats = new("What do you want to know?");
      cdStats.Add("Average price", () => Console.WriteLine("=> " + CD.AveragePrice(mediaInventory.GetMediasOfType<CD>())));
      cdStats.Add("Max price", () => Console.WriteLine("=> Tk. " + CD.MaxPrice(mediaInventory.GetMediasOfType<CD>())));
      cdStats.Add("Min price", () => Console.WriteLine("=> Tk. " + CD.MinPrice(mediaInventory.GetMediasOfType<CD>())));
      cdStats.Add("Total duration", () => Console.WriteLine("=> " + CD.TotalDuration(mediaInventory.GetMediasOfType<CD>())));

      Input dvdStats = new("What do you want to know?");
      dvdStats.Add("Average price", () => Console.WriteLine("=> " + DVD.AveragePrice(mediaInventory.GetMediasOfType<DVD>())));
      dvdStats.Add("Max price", () => Console.WriteLine("=> Tk. " + DVD.MaxPrice(mediaInventory.GetMediasOfType<DVD>())));
      dvdStats.Add("Min price", () => Console.WriteLine("=> Tk. " + DVD.MinPrice(mediaInventory.GetMediasOfType<DVD>())));
      dvdStats.Add("Total duration", () => Console.WriteLine("=> " + DVD.TotalDuration(mediaInventory.GetMediasOfType<DVD>())));

      Input statsMenu = new("Pick a media");
      statsMenu.Add("Book", bookStats.Ask);
      statsMenu.Add("CD", cdStats.Ask);
      statsMenu.Add("DVD", dvdStats.Ask);

      Input mainMenu = new("Please select an option");
      mainMenu.Add("Add media", addMenu.Ask);
      mainMenu.Add("Remove media", removeMenu.Ask);
      mainMenu.Add("List all media", mediaInventory.DisplayInfo);
      mainMenu.Add("Filter media", filterMenu.Ask);
      mainMenu.Add("Get statistics", statsMenu.Ask);

      while (true)
      {
        try
        {
          mainMenu.Ask();
        }
        catch (Exception e)
        {
          Console.WriteLine("ERROR: " + e.Message);
        }
      }
    }
  }
}