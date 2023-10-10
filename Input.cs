namespace Project
{
  /// <summary>
  /// Takes input from user
  /// </summary>
  public class Input
  {
    public delegate void Task();
    private List<string> _options = new List<string>();
    private string _question;
    private List<Task> _tasks = new List<Task>();
    public Input(string question) => _question = question;
    public void Add(string option, Task promptTask)
    {
      _options.Add(option);
      _tasks.Add(promptTask);
    }
    public void Ask()
    {
      Console.WriteLine(_question);
      for (int i = 0; i < _options.Count; i++)
        Console.WriteLine($"{i + 1}. {_options[i]}");
      Console.WriteLine($"{_options.Count + 1}. Exit");
      Console.Write("> ");
      string? input = Console.ReadLine();
      Console.WriteLine();
      if (int.TryParse(input, out int selected))
      {
        selected--;
        if (selected < 0 || selected > _options.Count)
          throw new FormatException("You have selected an option out of range");
        if (selected == _options.Count)
          Environment.Exit(0);
        _tasks[selected]();
      }
      else
        throw new FormatException("Option number must be an integer");
    }
    public static int InputInt(string prompt = "", int? defaultValue = null)
    {
      if (prompt != "")
      {
        if (defaultValue != null) Console.Write(prompt + "(optional): ");
        else Console.Write(prompt + ": ");
      }
      string? input = Console.ReadLine();
      if (int.TryParse(input, out int year)) return year;
      if (defaultValue == null) throw new FormatException($"{input} is not a valid integer");
      return (int)defaultValue;
    }
    public static string InputString(string prompt = "", string? defaultValue = null)
    {
      if (prompt != "")
      {
        if (defaultValue != null) Console.Write(prompt + "(optional): ");
        else Console.Write(prompt + ": ");
      }
      string? input = Console.ReadLine();
      if (input != null) return input;
      if (defaultValue == null) throw new FormatException($"Please enter a valid string");
      return defaultValue;
    }
    public static DateTime InputDateTime(string prompt = "", DateTime? defaultValue = null)
    {
      if (prompt != "")
      {
        if (defaultValue != null) Console.Write(prompt + "(yyyy-MM-dd)(optional): ");
        else Console.Write(prompt + "(yyyy-MM-dd): ");
      }
      string? input = Console.ReadLine();
      if (DateTime.TryParse(input, out DateTime dateTime)) return dateTime;
      if (defaultValue == null) throw new FormatException($"{input} is not a valid date format");
      return (DateTime)defaultValue;
    }
    public static TimeSpan InputTimeSpan(string prompt = "", TimeSpan? defaultValue = null)
    {
      if (prompt != "")
      {
        if (defaultValue != null) Console.Write(prompt + "(in minutes)(optional): ");
        else Console.Write(prompt + "(in minutes): ");
      }
      string? input = Console.ReadLine();
      if (TimeSpan.TryParse(input, out TimeSpan timeSpan)) return timeSpan;
      if (defaultValue == null) throw new FormatException($"{input} is not a valid time format");
      return (TimeSpan)defaultValue;
    }
    public static GENRE InputGenre(string prompt = "")
    {
      if (prompt != "")
        Console.WriteLine(prompt + ": ");
      foreach (GENRE genre in Enum.GetValues(typeof(GENRE)))
        Console.WriteLine($"{(int)genre + 1}. {genre.ToString()}");
      Console.Write("> ");
      string? input = Console.ReadLine();
      if (int.TryParse(input, out int val))
      {
        return (GENRE)(val - 1);
      }
      throw new FormatException($"{input} is not a valid genre option");
    }
  }
}