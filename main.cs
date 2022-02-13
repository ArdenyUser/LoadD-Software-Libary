using System;
using System.IO;
using System.Text;

class Main
{
    static void Main()
    {
        string path = @"c:\temp\SCRIPT.vis";

        char previous = '';
        string all = "";
        string cmd = "";
        string scpy;
        int mode = 0;
        string aug2;

        Stream s = new FileStream(@"data.vi", FileMode.Open);
        int val = 0;
        char ch;

        while (true)
        {
            val = s.ReadByte();

            if (val < 0)
                break;
            ch = (char)val;
            Console.Write(ch);
            if (ch != '(')
            {
                all = Concat(all, ch);


            }
            else
            {
                mode = 1;
                all = "";

            }
            if (mode = 1)
            {
                cmd = all;
                all = Concat(all, ch);
            }
            if (ch == ',')
            {
                mode = 2;
                all = "";
            }
            if (mode = 2)
            {
                aug2 = all;
                all = Concat(all, ch);
            }
            if (ch == ')')
            {
                if (cmd == "embed")
                {
                    File.Copy("C:/Visix/Embeds/" + all, all);
                }
                if (cmd == "copy")
                {
                    File.AppendAllText(@"main.vis", "File.Copy(" + all", " + aug2");" + Environment.NewLine);
                }
                if (cmd == "using")
                {
                    File.AppendAllText(@"main.vis", "using " + all + Environment.NewLine);
                }
                if (cmd == "fileAppend")
                {
                    File.AppendAllText(@"main.vis", "File.AppendAllText(@" + all + ',' + aug2 " + Environment.NewLine);" + Environment.NewLine);
                }
            }
        }
        Console.WriteLine();
    }
}
