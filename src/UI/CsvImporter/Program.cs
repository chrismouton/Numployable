using CommandLine;

using Numployable.APIClient.Client;

namespace Numployable.CsvImporter;

public class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<CommandLineOptions>(args)
            .WithParsed<CommandLineOptions>(o =>
            {
                Client httpClient = new (new System.Net.Http.HttpClient()
                    {
                        BaseAddress = new Uri(o.Url) //"http://localhost:5093")
                    }
                );
                CsvParser parser = new(o.FilePath, httpClient);
            });
    }
}
