namespace CountTextula;
class Program
{
    static void Main()
    {
        char[] separators = { ' ', '\n', '\n' };
        string[] text = new string(File.ReadAllText(@"E:\test\Text1.txt").Where(c => !char.IsPunctuation(c) && !char.IsDigit(c)).ToArray())
            .Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordsCounts = new Dictionary<string, int>();
        foreach (string s in text)
        {
            if (wordsCounts.ContainsKey(s)) { ++wordsCounts[s]; }
            else { wordsCounts[s] = 0; }
        }

        var wordsCountsSorted = wordsCounts.OrderByDescending(s => s.Value).ToDictionary();
        string[] words = wordsCountsSorted.Keys.ToList().GetRange(0, 10).ToArray();
        int[] counts = wordsCountsSorted.Values.ToList().GetRange(0, 10).ToArray();
        //there's probably a better way to do this

        for (int i = 0; i < 10; ++i) { Console.WriteLine($"{words[i]}: {counts[i]}"); }

        Console.ReadKey();
    }
}