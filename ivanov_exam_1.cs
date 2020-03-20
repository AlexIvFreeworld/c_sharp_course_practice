using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using static System.Console;
namespace Exam_1
{
    public class Word
    {
        public string Value { get; set; }
        public List<string> arrTranslate;
        public Word()
        {
            arrTranslate = new List<string>();
        }
        public void AddTranslate(string trans)
        {
            arrTranslate.Add(trans);
        }
        public void Show()
        {
            Write($"{Value} - ");
            foreach (string str in arrTranslate) Write($"{str} ");
            WriteLine();
        }
        public void ChangeWord(string newword)
        {
            Value = newword;
        }
        public void ChangeTranslate(string trans, string newtrans)
        {
            for (int i = 0; i < arrTranslate.Count; i++)
            {
                if (arrTranslate[i] != null)
                {
                    if (arrTranslate[i] == trans)
                    {
                        arrTranslate[i] = newtrans;
                        return;
                    }
                }
            }
            WriteLine($"New interpretation {newtrans}");
            arrTranslate.Add(newtrans);
        }
        public void DeleteTranslate(string trans)
        {
            if (arrTranslate.Count > 1)
            {
                for (int i = 0; i < arrTranslate.Count; i++)
                {
                    if (arrTranslate[i] != null)
                    {
                        if (arrTranslate[i] == trans)
                        {
                            arrTranslate.Remove(arrTranslate[i]);
                            return;
                        }
                    }
                }
            }
            else
            {
                WriteLine("This word has only one interpretation, forbidden delete it!!");
                return;
            }
            WriteLine("This word hasn't such interpretation");
        }
        public void WriteInFile()
        {
            string filePath = "result.txt";
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.Write($"{Value} - ");
                    foreach (string str in arrTranslate) sw.Write($"{str} ");
                    sw.WriteLine();
                }
            }
        }
    }
    public class Dictionary
    {
        public string Dtype { get; set; }
        public List<Word> arrWords;
        public Dictionary() { }
        public Dictionary(string type)
        {
            Dtype = type;
            arrWords = new List<Word>();
        }
        public void AddWord(string word, string translate)
        {
            WriteLine($"Count words : {arrWords.Count}");
            for (int i = 0; i < arrWords.Count; i++)
            {
                if (arrWords[i] != null)
                {
                    if (arrWords[i].Value == word)
                    {
                        arrWords[i].arrTranslate.Add(translate);
                        return;
                    }
                }
            }
            WriteLine($"New word {word}");
            Word W = new Word();
            W.Value = word;
            W.arrTranslate.Add(translate);
            arrWords.Add(W);
        }
        public void DeleteWord(string word)
        {
            for (int i = 0; i < arrWords.Count; i++)
            {
                if (arrWords[i].Value == word)
                {
                    arrWords.Remove(arrWords[i]);
                    return;
                }
            }
            WriteLine("This word wasn't found");
        }

        public void ChangeWordorTranslate(string word, string newword, int pos, string newtranslate)
        {

        }
        public void DeleteWordorTranslate(string word, int pos)
        {

        }
        public Word SearchTranslate(string word)
        {
            for (int i = 0; i < arrWords.Count; i++)
            {
                //arrWords[i].Show();
                if (arrWords[i].Value == word)
                {
                    return arrWords[i];
                }
            }
            return null;
        }
        public void Show()
        {
            foreach (Word word in arrWords)
            {
                word.Show();
            }
        }
    }
    class Library
    {
        public List<Dictionary> arrDictionary;
        public Library()
        {
            arrDictionary = new List<Dictionary>();
        }
        public void AddDictionary(string type)
        {
            Dictionary D = new Dictionary(type);
            arrDictionary.Add(D);
        }
        public Dictionary SearchDictionary(string type)
        {
            for (int i = 0; i < arrDictionary.Count; i++)
            {
                if (arrDictionary[i].Dtype == type)
                {
                    return arrDictionary[i];
                }
            }
            return null;
        }
    }
    class Program
    {
        public static void Main()
        {
            Library L = new Library();
            //upload bd from file
            L.arrDictionary = null;
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Dictionary>));
            using (Stream fs = File.OpenRead("bd_L.xml"))
            {
                L.arrDictionary = (List<Dictionary>)xmlFormat.Deserialize(fs);
            }
            string choice = "";
            bool is_work = true;
            string typeD, word, new_word, inter, new_inter;
            do
            {
                WriteLine("Enter any choice :");
                WriteLine("Add dictionary (1), Add word (2), Search (3)");
                WriteLine("Change word (4), Change/add interpretation (5), Delete word (6)");
                WriteLine("Delete interpretation (7), Print word (8), exit (e)");
                choice = ReadLine();
                switch (choice)
                {
                    case "1":
                        WriteLine("Enter type new dictionary");
                        typeD = ReadLine();
                        L.AddDictionary(typeD);
                        break;
                    case "2":
                        WriteLine("Enter type dictionary");
                        typeD = ReadLine();
                        Dictionary D = L.SearchDictionary(typeD);
                        if (D != null) WriteLine($"Found dictionary {D.Dtype}");
                        else
                        {
                            WriteLine("Dictionary wasn't found");
                            break;
                        }
                        WriteLine("Enter needed word");
                        word = ReadLine();
                        WriteLine("Enter needed interpretation");
                        inter = ReadLine();
                        D.AddWord(word, inter);
                        break;
                    case "3":
                        WriteLine("Enter type dictionary");
                        typeD = ReadLine();
                        Dictionary D1 = L.SearchDictionary(typeD);
                        if (D1 != null) WriteLine($"Found dictionary {D1.Dtype}");
                        else
                        {
                            WriteLine("Dictionary wasn't found");
                            break;
                        }
                        WriteLine("Enter needed word");
                        word = ReadLine();
                        if (D1.SearchTranslate(word) != null) D1.SearchTranslate(word).Show();
                        else WriteLine("Word wasn't found");
                        break;
                    case "4":
                        WriteLine("Enter type dictionary");
                        typeD = ReadLine();
                        Dictionary D2 = L.SearchDictionary(typeD);
                        if (D2 != null) WriteLine($"Found dictionary {D2.Dtype}");
                        else
                        {
                            WriteLine("Dictionary wasn't found");
                            break;
                        }
                        WriteLine("Enter needed word");
                        word = ReadLine();
                        if (D2.SearchTranslate(word) != null) D2.SearchTranslate(word).Show();
                        else
                        {
                            WriteLine("Word wasn't found");
                            break;
                        }
                        WriteLine("Enter new word");
                        new_word = ReadLine();
                        D2.SearchTranslate(word).ChangeWord(new_word);
               //         D2.Show();
                        break;
                    case "5":
                        WriteLine("Enter type dictionary");
                        typeD = ReadLine();
                        Dictionary D3 = L.SearchDictionary(typeD);
                        if (D3 != null) WriteLine($"Found dictionary {D3.Dtype}");
                        else
                        {
                            WriteLine("Dictionary wasn't found");
                            break;
                        }
                        WriteLine("Enter needed word");
                        word = ReadLine();
                        if (D3.SearchTranslate(word) != null) D3.SearchTranslate(word).Show();
                        else
                        {
                            WriteLine("Word wasn't found");
                            break;
                        }
                        WriteLine("Enter interpretation");
                        inter = ReadLine();
                        WriteLine("Enter new interpretation");
                        new_inter = ReadLine();
                        D3.SearchTranslate(word).ChangeTranslate(inter, new_inter);
                 //       D3.Show();
                        break;
                    case "6":
                        WriteLine("Enter type dictionary");
                        typeD = ReadLine();
                        Dictionary D4 = L.SearchDictionary(typeD);
                        if (D4 != null) WriteLine($"Found dictionary {D4.Dtype}");
                        else
                        {
                            WriteLine("Dictionary wasn't found");
                            break;
                        }
                        WriteLine("Enter needed word");
                        word = ReadLine();
                        if (D4.SearchTranslate(word) != null) D4.SearchTranslate(word).Show();
                        else
                        {
                            WriteLine("Word wasn't found");
                            break;
                        }
                        D4.DeleteWord(word);
                   //     D4.Show();
                        break;
                    case "7":
                        WriteLine("Enter type dictionary");
                        typeD = ReadLine();
                        Dictionary D5 = L.SearchDictionary(typeD);
                        if (D5 != null) WriteLine($"Found dictionary {D5.Dtype}");
                        else
                        {
                            WriteLine("Dictionary wasn't found");
                            break;
                        }
                        WriteLine("Enter needed word");
                        word = ReadLine();
                        if (D5.SearchTranslate(word) != null) D5.SearchTranslate(word).Show();
                        else
                        {
                            WriteLine("Word wasn't found");
                            break;
                        }
                        WriteLine("Enter interpretation");
                        inter = ReadLine();
                        D5.SearchTranslate(word).DeleteTranslate(inter);
                     //   D5.Show();
                        break;
                    case "8":
                        WriteLine("Enter type dictionary");
                        typeD = ReadLine();
                        Dictionary D6 = L.SearchDictionary(typeD);
                        if (D6 != null) WriteLine($"Found dictionary {D6.Dtype}");
                        else
                        {
                            WriteLine("Dictionary wasn't found");
                            break;
                        }
                        WriteLine("Enter needed word");
                        word = ReadLine();
                        if (D6.SearchTranslate(word) != null) D6.SearchTranslate(word).WriteInFile();
                        else WriteLine("Word wasn't found");
                        break;
                    case "e":
                        is_work = false;
                        break;
                    default:
                        WriteLine("Incorrect choice");
                        break;
                }
            } while (is_work);
            using (Stream fs = File.Create("bd_L.xml"))
            {
                xmlFormat.Serialize(fs, L.arrDictionary);
                WriteLine("XmlSerialize OK!\n");
            }
        }
    }
}

