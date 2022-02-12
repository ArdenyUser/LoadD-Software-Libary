using System;
using System.IO;
using System.Text;

private previous = null;
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
               
            }
        }
        Console.WriteLine();
    }
}
