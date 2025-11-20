using CommandLine;

namespace Numployable.CsvImporter;

public class CommandLineOptions
{
    [Option('f', "file", Required = true, HelpText = "Path to the file that contains the CSV data to import")]
    public string FilePath { get; set; }

    [Option('u', "URL", Required = true, HelpText = "URL to the Numployable API")]
    public string Url { get; set; }
}
