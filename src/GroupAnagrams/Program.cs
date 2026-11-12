using GroupAnagrams;
using System.Text.RegularExpressions;

string currentDirectory = Directory.GetCurrentDirectory();

string[] inputFiles = Directory.GetFiles(
    currentDirectory,
    "input_*.txt"
);

foreach (string inputPath in inputFiles)
{
    string fileName = Path.GetFileName(inputPath);

    if (!IsValidInputFile(fileName))
    {
        Console.WriteLine($"Skipped invalid file: {fileName}");
        continue;
    }

    var grouper = new AnagramGrouper();
    var processor = new FileProcessor();

    processor.ProcessInputFile(inputPath, grouper);

    var groups = grouper.GetSortedGroups();

    string outputFileName = fileName.Replace("input_", "output_");

    string outputPath = Path.Combine(
        currentDirectory,
        outputFileName
    );

    processor.WriteOutputFile(outputPath, groups);

    Console.WriteLine($"Processed: {fileName}");
}

static bool IsValidInputFile(string fileName)
{
    return Regex.IsMatch(
        fileName,
        @"^input_\d{2}_.+\.txt$"
    );
}