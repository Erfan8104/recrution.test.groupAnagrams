namespace GroupAnagrams;

public class AnagramGrouper
{
    private readonly Dictionary<string, AnagramGroup> _groups = new();

    public void AddWord(string word)
    {
        string key = CreateKey(word);

        if (_groups.TryGetValue(key, out AnagramGroup? group))
        {
            group.Add(word);
        }
        else
        {
            _groups[key] = new AnagramGroup(word);
        }
    }

    private static string CreateKey(string word)
    {
        char[] letters = word.ToCharArray();
        Array.Sort(letters);

        return new string(letters);
    }

    public List<AnagramGroup> GetSortedGroups()
    {
       return _groups.Values
          .OrderBy(group => group.Representative, StringComparer.Ordinal)
          .ToList();
    }
}