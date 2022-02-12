using System;
using System.IO;
using System.Text;

private char previous = '';
private string all = "";
private string cmd = "";

public static System.IO.StreamWriter AppendText (string path);

class Demo
{
    static void Main()
    {
        string path = @"c:\temp\SCRIPT.vis";
        
        private char previous = '';
        private string all = "";
        private string cmd = "";
        
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
                    if (!File.Exists(path))
                    {
                         using (StreamWriter sw = File.CreateText(path))
                         {
                             sw.WriteLine("section .multiboot_header");
                             sw.WriteLine("header_start:");
                             sw.WriteLine("     dd 0xe85250d6");
                             sw.WriteLine("     dd 0");
                             sw.WriteLine("     dd header_end - header_start");
                             sw.WriteLine("     dd 0x100000000 - (0xe85250d6 + 0 + (header_end - header_start))");
                             sw.WriteLine("     ");
                             sw.WriteLine("     dw 0");
                             sw.WriteLine("     dw 0");
                             sw.WriteLine("     dd 8");
                             sw.WriteLine("header_end:");


                         }    
                    }    
                }    
            }    
        }
        Console.WriteLine();
    }
}
