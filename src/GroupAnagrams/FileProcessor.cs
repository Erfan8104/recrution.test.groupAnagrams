namespace GroupAnagrams;

public class FileProcessor
{
    public void ProcessInputFile(string inputPath, AnagramGrouper grouper)
    {
        using var reader = new StreamReader(inputPath);

        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            grouper.AddWord(line);
        }
    }
    public void WriteOutputFile(
    string outputPath,
    List<AnagramGroup> groups)
{
    using var writer = new StreamWriter(outputPath);

    foreach (var group in groups)
    {
        writer.WriteLine($"{group.Representative} {group.Count}");
    }
}
}