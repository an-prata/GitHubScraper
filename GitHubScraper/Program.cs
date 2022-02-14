using static System.Text.Encoding;
using static GitHubScraper.ReadMeScraper;

namespace GitHubScraper;

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine($"README from GitHub repo {args[0]}:\n");

		string scrape = ScrapeRaw(args[0]);
		Console.WriteLine(scrape);

		try
		{
			FileStream file = File.Open(args[1], FileMode.Create);
			file.Write(UTF8.GetBytes(scrape));
			file.Close();
		}
		catch(IndexOutOfRangeException)
		{
			return;
		}
		catch(FileNotFoundException)
		{
			Console.Write($"File {args[1]} was not found.");
		}
	}
}
