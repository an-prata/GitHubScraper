using static GitHubScraper.ReadMeScraper;

namespace GitHubScraper;

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine($"README from GitHub repo {args[1]}:\n");
		Console.WriteLine(ScrapeRaw(args[1]));
	}
}
