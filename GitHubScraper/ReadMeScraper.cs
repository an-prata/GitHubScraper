namespace GitHubScraper;

public static class ReadMeScraper
{
	/// <summary>
	/// Scrapes the raw content of the repository's README file.
	/// </summary>
	/// 
	/// <param name="repositoryURL">
	/// The reposity URL, e.g. 
	/// https://github.com/an-prata/TimeBasedVerification/,
	/// http://github.com/an-prata/TimeBasedVerification/,
	/// /an-prata/TimeBasedVerification/
	/// </param>
	/// 
	/// <param name="usesMain">
	/// Set to true if your repository uses the name "Main"
	/// instead of "master" for your primary branch.
	/// </param>
	/// 
	/// <param name="usesMdExtension">
	/// Whether or not the README file is README.md.
	/// </param>
	/// 
	/// <returns>
	/// A string with the README's contents.
	/// </returns>
	public static string ScrapeRaw(string repositoryURL, bool usesMdExtension = true, bool usesMain = false)
	{
		// If the URL contains the protocol or domain, remove
		// them before continuing.
		if (repositoryURL.Contains("https://"))
		{
			repositoryURL = repositoryURL.Remove(0, 18);
		}
		else if (repositoryURL.Contains("http://"))
		{
			repositoryURL = repositoryURL.Remove(0, 17);
		}
		else if (repositoryURL.Contains("github.com"))
		{
			repositoryURL = repositoryURL.Remove(0, 10);
		}
		
		// Add the necassary parts to make the URL complete.
		string readMeURL = repositoryURL[0] == '/' ? "https://raw.githubusercontent.com" : "https://raw.githubusercontent.com/";
		readMeURL += repositoryURL[^1] == '/' ? repositoryURL : repositoryURL + '/';
		readMeURL += usesMain ? "main/" : "master/";
		readMeURL += usesMdExtension ? "README.md" : "README";

		// Make a get request to the raw GitHub user content.
		using HttpClient webClient = new();
		return webClient.GetStringAsync(new Uri(readMeURL)).GetAwaiter().GetResult();
	}
}