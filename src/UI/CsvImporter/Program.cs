namespace Numployable.CsvImporter;

using CommandLine;

public class Program
{
     public static void Main (string[] args)
     {
          CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
               .WithParsed<CommandLineOptions>(o =>
               {
                    CsvParser parser = new(o.FilePath, o.Url);
               });
     }
}

