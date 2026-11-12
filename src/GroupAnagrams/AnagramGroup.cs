
namespace GroupAnagrams;

public class AnagramGroup
{
    public string Representative { get; private set; }

    public int Count { get; private set; }

    public AnagramGroup(string word)
    {
        Representative = word;
        Count = 1;
    }

    public void Add(string word)
    {
        Count++;

        if (string.CompareOrdinal(word, Representative) < 0)
        {
            Representative = word;
        }
    }
}
