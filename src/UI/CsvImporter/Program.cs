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
                Client httpClient = null; // new Client(cl => cl.BaseAddress = new Uri("http://localhost:5093"));
                //httpClient.HttpClient.BaseAddress = new Uri("http://localhost:5093");
                CsvParser parser = new(o.FilePath, httpClient);
            });
    }
}