using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;


class Program
{
    static void Main()
    {
        string bookName = "King_Stiven_Zelenaya_milya.txt";
        string path = @"C:\Users\kosta\source\repos\TextToImage\TextToImage\";
        string text = readFile(path+bookName);
        text = text.ToLower();
        graphics.Clear(Color.White);
        getColorsFromText(text);
        bitmap.Save(path+"BookPortrait.png", ImageFormat.Png);
    }
    static Dictionary<string, Color> dict = new Dictionary<string, Color>
{
    { "красн", Color.Red },
    { "оранжев", Color.Orange },
    { "желт", Color.Yellow },
    { "зелен", Color.Green },
    { "голуб", Color.LightBlue },
    { "син", Color.Blue },
    { "фиолетов", Color.Purple },
    { "багров", Color.Crimson },
    { "черн", Color.Black },
    { "бел", Color.White },
    { "розов", Color.Pink },
    { "коричнев", Color.Brown },
    { "сер", Color.Gray },
    { "серебр", Color.Silver },
    { "золот", Color.Gold },
    { "лазурн", Color.Azure },
    { "бирюзов", Color.Turquoise },
    { "небесн", Color.SkyBlue },
    { "морск", Color.SteelBlue },
    { "оливков", Color.Olive },
    { "лайм", Color.Lime },
    { "мятн", Color.MintCream },
    { "лесн", Color.ForestGreen },
    { "индиго", Color.Indigo },
    { "орхиде", Color.Orchid },
    { "лососев", Color.Salmon },
    { "томатн", Color.Tomato },
    { "шоколадн", Color.Chocolate },
    { "пшеничн", Color.Wheat },
    { "льнян", Color.Linen },
    { "медн", Color.Tan },
    { "бежев", Color.Beige },
    { "персиков", Color.PeachPuff },
    { "кораллов", Color.Coral },
    { "магн", Color.Magenta },
    { "фукси", Color.Fuchsia },
    { "лаванд", Color.Lavender },
    { "сливов", Color.Plum },
    { "сиренев", Color.Thistle },
    { "аквамарин", Color.Aquamarine },
    { "бисквитн", Color.Bisque },
    { "ванильн", Color.BlanchedAlmond },
    { "кремов", Color.Cornsilk },
    { "медов", Color.Honeydew },
    { "слонов", Color.Ivory },
    { "льдист", Color.AliceBlue },
    { "дымчат", Color.GhostWhite },
    { "снежн", Color.Snow },
    { "жемчужн", Color.SeaShell }
}; 
    static Bitmap bitmap = new Bitmap(300, 300);
    static Graphics graphics = Graphics.FromImage(bitmap);
    static SolidBrush brush = new SolidBrush(Color.Red);

    static string readFile(string path)
    {
        return File.ReadAllText(path);
    }

    static void getColorsFromText(string text)
    {
        string[] splittedText = Regex.Split(text, @"[\p{P}\s\r\n]+");
        string foundColor;
        int imageSize = 300;
        int pixelSize = 10;
        int x = 0, y = 0;
        foreach (string word in splittedText)
        {
           
            foundColor = dict.Keys.FirstOrDefault(key => word.Contains(key));
            if (foundColor != null)
            {
                drawPixel(dict[foundColor],ref x,ref y,imageSize,pixelSize);
            }
        }

    }

    static void drawPixel(Color color,ref int x,ref int y,int imageSize,int pixelSize)
    {
        x += pixelSize;
        if (x == imageSize)
        {
            y += pixelSize;
            x = 0;
        }
        //Console.WriteLine(color);
        brush.Color = color;
        graphics.FillRectangle(brush, x, y, 10, 10);
    }

}


