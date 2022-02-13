using System;
using System.IO;
using System.Text;

class Demo
{
    static void Main()
    {
        string path = @"c:\temp\SCRIPT.vis";
        
        char previous = '';
        string all = "";
        string cmd = "";
        
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
                if (cmd == "embed")
                {
                    File.Copy("C:/Visix/Embeds/" + all, all);
                }
                if (cmd == "copyFile")
                {
                    File.Copy("C:/Visix/Embeds/" + all, all);
                }   
            }    
        }
        Console.WriteLine();
    }
}
