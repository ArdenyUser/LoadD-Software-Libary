using System;
using System.IO;
using System.Text;

private char previous = '';
private string all = "";
private string cmd = "";

class Demo
{
    static void Main()
    {
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
            if (ch != "(")
            {
               all = Concat(all, ch);
               
               
            }
            else
            {
                cmd = all;
                all = "";
                all = Concat(all, ch);
            }
            if (ch == ")")
            {
                if (cmd == "os.Start")
                {
                    
                }    
            }    
        }
        Console.WriteLine();
    }
}
