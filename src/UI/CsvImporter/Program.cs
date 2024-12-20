﻿using CommandLine;

namespace Numployable.CsvImporter;

public class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<CommandLineOptions>(args)
            .WithParsed<CommandLineOptions>(o =>
            {
                CsvParser parser = new(o.FilePath, o.Url);
            });
    }
}