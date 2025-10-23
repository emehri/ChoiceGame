using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceGame
{
    public class Book
    {
        public string Title { get; set; }
        List<string> Words { get; set; }
        public Book(string name)
        {
            Title = name;
            Words = File.ReadAllLines(name + ".txt").ToList();
        }
    }
    public static class Library
    {
        public static int Book_Index;
        public static Dictionary<string, List<string>> All_Words_In_Book = new Dictionary<string, List<string>>();
        public static Dictionary<string, string> Dic = new Dictionary<string, string>();
        public static List<string> Books = new List<string> { "400", "504", "1100", "4000", "GRE Essential",
                                                              "Sophie", "WorkBook", "B", "C", "Spanish", "Gap","Ox3000" };
        public static string noDigit(string s)
        {
            string ss = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i])) continue;
                ss += s[i];
            }
            return ss;
        }
        public static void ReadDictionary(string dictionary)
        {
            List<string> book = new List<string>();
            if (dictionary == "") dictionary = "Dic6-2";
            book = File.ReadAllLines(@"C:\ChoiceGame\" + dictionary + ".txt", Encoding.UTF8).ToList();
            Dic.Clear();
            for (int i = 0; i < book.Count - 1; i += 2)
            {
                if (!Dic.ContainsKey(book[i]))
                {
                    Dic.Add(book[i], book[i + 1]);
                    continue;
                }
                if (Dic[book[i]].IndexOf(book[i + 1]) == -1) Dic[book[i]] += "<br>" + book[i + 1];
            }
        }
        public static void ReadWords(int Index_Book)
        {
            string path = @"C:\ChoiceGame\";
            string ss = Books[Index_Book];
            List<string> xx = File.ReadAllLines(path + ss + ".txt").ToList();
            All_Words_In_Book[ss] = xx;
        }
        public static string give(string s)
        {
            string ss = "";
            try
            {
                ss = Dic[s];
            }
            catch { return ""; }
            return ss;
        }
        public static int getLength()
        {
            return Dic.Count;
        }
    }
    public class Question
    {
        public string Definition { get; set; }
        public List<string> Choices { get; set; }
        public int CorrectAnswer { get; set; }
        static string verb(string s)
        {
            int k = s.IndexOf("<b>");
            if (k == -1) return "";
            string ss = "";
            for (int i = k + 3; s[i] != '<'; i++)
                ss += s[i];
            return ss;
        }
        public Question(List<string> words, int N, string Language)
        {
            Choices = new List<string>();
            Random rr = new Random();
            string Dorost = words[rr.Next(words.Count)];
            Definition = Library.give(Dorost);
            if (Definition == "") return;
            Definition = Definition.Replace("<br><br>","<br>");
            List<string> answer = new List<string>();
            answer.Clear();
            Choices.Clear();
            for (int i = 0; i < N; i++)
            {
                answer.Add("");
            }
            int Gozine = rr.Next(N);
            CorrectAnswer = Gozine;
            Dorost = Library.noDigit(Dorost);
            answer[Gozine] = Dorost;
            Dictionary<string, bool> temp = new Dictionary<string, bool>();
            temp.Add(Dorost, true);
            for (int i = 0; i < N; i++)
            {
                if (i == Gozine) continue;
                while (true)
                {
                    string Ghalat = Library.noDigit(words[rr.Next(words.Count)]);
                    if (temp.ContainsKey(Ghalat))
                        continue;
                    if (Language == "Spanish" && verb(Definition) != verb(Library.give(Ghalat))) continue;
                    temp.Add(Ghalat, true);
                    answer[i] = Ghalat;
                    break;
                }
            }
            Choices = answer;
        }
    }
}
