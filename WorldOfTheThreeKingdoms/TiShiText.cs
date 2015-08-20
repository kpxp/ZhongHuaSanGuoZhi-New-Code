namespace WorldOfTheThreeKingdoms
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class TiShiText
    {
        List<String> text = new List<String>();

        public TiShiText()
        {
            TextReader tr = new StreamReader("Resources/tishiText.txt");
            while (tr.Peek() >= 0)
            {
                String line = tr.ReadLine();
                text.Add(line);
            }
        }

        public String getRandomText()
        {
            return text[GameGlobal.StaticMethods.Random(text.Count)];
        }
    }
}
