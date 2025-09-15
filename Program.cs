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
                if (x == 300)
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


