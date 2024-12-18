﻿namespace CountTextula;
class Program
{
    static void Main()
    {
        char[] separators = { ' ', '\n', '\n' };
        string[] text = new string(File.ReadAllText(@"E:\test\Text1.txt")
            .Where(c => !char.IsPunctuation(c) && !char.IsDigit(c)).ToArray())
            .Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordsCounts = new Dictionary<string, int>();
        foreach (string s in text)
        {
            if (wordsCounts.ContainsKey(s)) { ++wordsCounts[s]; }
            else { wordsCounts[s] = 0; }
        }

        var wordsCountsSorted = wordsCounts.OrderByDescending(s => s.Value).Take(10);
        foreach ((string word, int count) in wordsCountsSorted) { Console.WriteLine($"{word}: {count}"); }

        Console.ReadKey();
    }
}