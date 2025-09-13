using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;


class Program
{
    static void Main()
    {
        string path = @"C:\Users\kosta\source\repos\TextToImage\TextToImage\King_Stiven_Zelenaya_milya.txt";
        string text = readFile(path);
        text = text.ToLower();
        getColorsFromText(text);
        bitmap.Save("шахматная_доска.png", ImageFormat.Png);
    }
    static Dictionary<string, Color> dict = new Dictionary<string, Color> { { "красн", Color.Red }, { "оранжев", Color.Orange }, { "желт", Color.Yellow }, { "зелен", Color.Green }, { "голуб", Color.LightBlue }, { "син", Color.Blue }, { "фиолетов", Color.Purple }, { "багров", Color.Crimson }, { "черн", Color.Black }, { "бел", Color.White } };
    static Bitmap bitmap = new Bitmap(1000, 1000);
    static Graphics graphics = Graphics.FromImage(bitmap);
    static string readFile(string path)
    {
        return File.ReadAllText(path);
    }

    static void getColorsFromText(string text)
    {
        string[] splittedText = Regex.Split(text, @"[\p{P}\s\r\n]+");
        int x = 0, y = 0;
        graphics.Clear(Color.White);
        foreach (string word in splittedText)
        {
           
            string foundColor = dict.Keys.FirstOrDefault(key => word.Contains(key));
            if (foundColor != null)
            {
                x += 10;
                if (x == 1000)
                {
                    y += 10;
                    x = 0;
                }
                Console.WriteLine(foundColor);
                drawBookPortrait(dict[foundColor],x,y);
            }
        }

    }
    static void drawBookPortrait(Color color,int x,int y)
    {

        SolidBrush brush = new SolidBrush(Color.Red);
        brush.Color = color;
        graphics.FillRectangle(brush, x, y, 10, 10);
    }

}


