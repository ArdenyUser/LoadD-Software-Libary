using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

string dataVis = File.ReadAllText(@"data.vis");

List<string> tokens = new List<string>();

// 1. Lex source

{
    int position = 0;

    Func<char> Current = () => position >= dataVis.Length
        ? '\0'
        : dataVis[position];

    while (true)
    {
        // End on null terminator - indicates end of string
        if (Current() == '\0')
        {
            break;
        }

        // Ignore whitespace (inc. new lines)
        if (char.IsWhiteSpace(Current()))
        {
            position++;
            continue;
        }

        // Special punctuation can go into it's own token
        if (new[] { '(', ')', ',' }.Contains(Current()))
        {
            tokens.Add(Current().ToString());
            position++;
            continue;
        }

        // Otherwise assume a string (represents a command name & any arguments)
        ReadString();
    }

    void ReadString()
    {
        StringBuilder sb = new StringBuilder();

        bool done = false;

        while (!done)
        {
            switch (Current())
            {
                case ',':
                case ' ':
                case '\t':
                case '\0':
                case '(':
                case ')':
                    done = true;
                    break;
                default:
                    sb.Append(Current());
                    position++;
                    break;
            }
        }

        tokens.Add(sb.ToString());
    }
}

// 2. Parse tokens

{
    int position = 0;

    Func<string> Current = () => position >= tokens.Count
        ? null
        : tokens[position];

    StringBuilder sb = new StringBuilder();

    Func<string> Consume = () =>
    {
        string token = position < tokens.Count
            ? tokens[position]
            : null;

        position++;

        return token;
    };

    while (true)
    {
        // End of tokens
        if (Current() == null)
        {
            break;
        }

        // If it's a copy token we can consume it & the expected trailing tokens
        if (Current() == "copy")
        {
            position++;

            _ = Consume(); // Open parenthesis

            string firstArg = Consume();

            _ = Consume(); // Comma

            string secondArg = Consume();

            _ = Consume(); // Close parenthesis

            sb.AppendLine($@"File.Copy(""{firstArg}"", ""{secondArg}"");");

            continue;
        }

        if (Current() == "print")
        {
            position++;

            _ = Consume(); // Open parenthesis

            string arg = Consume();

            File.AppendAllText(@"main.cs", "Console.WriteLine(" + arg + ");" + Environment.NewLine);

            _ = Consume(); // Close parenthesis

            continue;
        }



        if (Current() == "use")
        {
            position++;

            _ = Consume(); // Open parenthesis

            string arg = Consume();

            File.AppendAllText(@"main.cs", "using " + arg + Environment.NewLine);

            _ = Consume(); // Close parenthesis

            continue;
        }

        if (Current() == "direct")
        {
            position++;

            _ = Consume(); // Open parenthesis

            string arg = Consume();

            File.AppendAllText(@"main.cs", arg + Environment.NewLine);

            _ = Consume(); // Close parenthesis

            continue;
        }

        if (Current() == "embed")
        {
            position++;

            _ = Consume(); // Open parenthesis

            string arg = Consume();

            File.Copy("C:/Visix/Embeds/" + arg, arg);

            _ = Consume(); // Close parenthesis

            continue;
        }

        if (Current() == "var")
        {
            position++;

            _ = Consume(); // Open parenthesis

            string arg = Consume();

            File.AppendAllText(@"main.cs", arg + Environment.NewLine);

            _ = Consume(); // Close parenthesis

            continue;
        }

        if (Current() == "DEFINENAME")
        {
            position++;

            _ = Consume(); // Open parenthesis

            File.AppendAllText(@"main.cs", "public void " + arg + Environment.NewLine);
            File.AppendAllText(@"main.cs", @"{" + Environment.NewLine);

            _ = Consume(); // Close parenthesis

            continue;
        }
        
        if (Current() == "DEFINEEND")
        {
            position++;

            _ = Consume(); // Open parenthesis

            File.AppendAllText(@"main.cs", "}" + Environment.NewLine);

            _ = Consume(); // Close parenthesis

            continue;
        }
        // Add more commands here
    }

    // Write to data.vis - just printing for demonstration
    Console.WriteLine(sb.ToString());
}
