using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

public class TextAnalyzer
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a paragraph to analyze:");
        string s = Console.ReadLine();
        string[] words = s.Split(' ');
        int countTotalWorld  =words.Length;
        Console.WriteLine(countTotalWorld);
        int countTotalSentences = s.Split('\n').Length;
        Console.WriteLine(countTotalSentences);
        var dic = new Dictionary<string, int>();
        int mxx = 0;
        string mostFrequentWord = "";
        foreach (var  word in words)
        {
            if (!dic.ContainsKey(word))
            {
                dic.Add(word , 1);
            } 
            else
            {
                dic[word]++;
            }
            if (dic[word] > mxx)
            {
                mostFrequentWord = word;
                mxx = dic[word];
            }
        }
        Console.WriteLine($"most frequent word is {mostFrequentWord} and has count is {mxx}");
        int Const = 0, vawoles = 0;
        foreach(var c in s)// no thing 
        {
            char x = Char.ToLower(c);
            if (x == 'a' || x == 'e' || x == 'i' || x == 'u' || x == 'o') vawoles++;
            else Const++;
        }
        Console.WriteLine($" vowels and consonants is {vawoles} {Const}");

    }
}