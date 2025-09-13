using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;


class Program {
    static void Main()
    {
        string path = @"C:\Users\kosta\source\repos\TextToImage\TextToImage\King_Stiven_Zelenaya_milya.txt";
        string text = readFile(path);
        text = text.ToLower();
        getColorsFromText(text);
    }
    static Dictionary<string, Color> dict = new Dictionary<string, Color> { { "красн", Color.Red },{"оранжев",Color.Orange }, { "желт", Color.Yellow },{ "зелен", Color.Green }, { "голуб", Color.LightBlue }, { "син", Color.Blue }, { "фиолетов", Color.Purple }, { "багров", Color.Crimson }, { "черн", Color.Black }, { "бел", Color.White } };

    static string readFile(string path)
    {
        return File.ReadAllText(path);
    }

    static void getColorsFromText(string text)
    {
        string[] splittedText = Regex.Split(text, @"[\p{P}\s\r\n]+");
        foreach (string word in splittedText)
        {
            string foundColor = dict.Keys.FirstOrDefault(key => word.Contains(key));
            if (foundColor!=null)
            Console.WriteLine(foundColor);
        }
    }
    static void drawBookPortrait()
    {
        
    }
}

