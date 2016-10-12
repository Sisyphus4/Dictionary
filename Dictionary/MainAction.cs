using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
namespace Dictionary
{
    static class MainAction
    {
        public static void Action()
        {
            IDictionary<string, int> dictionary = new Dictionary<string, int>();
            StreamReader input = new StreamReader("input.txt");
            while (!input.EndOfStream)
            {
                string s = input.ReadLine();
                string[] str;
                str = s.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
                int n = str.GetLength(0);
                for (int i = 0; i<n; i++)
                {
                    if (dictionary.ContainsKey(str[i]))
                        dictionary[str[i]]++;
                    else
                        dictionary[str[i]] = 1;
                }
                
            }
            input.Close();
            List<string> vowels = new List<String>();
            List<string> consonants = new List<String>();
            foreach (var item in dictionary)
            {
                if (item.Value == 1)
                {
                    bool isVowel = "aeiouAEIOU".IndexOf(item.Key[0]) >= 0;
                    if (isVowel)
                    {
                        vowels.Add(item.Key);
                    }
                    else
                    {
                        consonants.Add(item.Key);
                    }
                }
            }
            vowels.Sort();
            consonants.Sort();
            File.Delete("text.txt");
         
            StreamWriter writer = new StreamWriter("text.txt");
            foreach (var item in vowels)
            {
                writer.Write(item);
                writer.Write(' ');
            }
            foreach (var item in consonants)
            {
                writer.Write(item);
                writer.Write(' ');
            }
            writer.Close();

        }
       
    }
}
