using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace New_Dawn
{
    class ColorWriter : TextWriter
    {
        private TextWriter originalOut;

        public ColorWriter()
        {
            originalOut = Console.Out;
        }

        public override Encoding Encoding
        {
            get { return new System.Text.ASCIIEncoding(); }
        }
        public override void WriteLine(string value)
        {
            this.Write(value);
            originalOut.WriteLine();
        }
        public override void Write(string value)
        {
            List<char> printBuffer = new List<char>();
            List<char> ColorChars = new List<char>();
            ColorChars.AddRange(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '@', '#', '$', '%', '.' });
            for (int i = 0; i < value.Length; i++)
            {


                if (i + 1 < value.Length && (value[i] == '`' || value[i] == '^'))
                {
                    if (ColorChars.Contains(value[i + 1]))
                    {
                        originalOut.Write(printBuffer.ToArray());
                        printBuffer = new List<char>();
                        if (value[i] == '`')
                        {
                            switch (value[i + 1])
                            {
                                case '0':
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    break;
                                case '1':
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    break;
                                case '2':
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    break;
                                case '3':
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    break;
                                case '4':
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    break;
                                case '5':
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    break;
                                case '6':
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    break;
                                case '7':
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                case '8':
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    break;
                                case '9':
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case '&':
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case '!':
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case '@':
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case '#':
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    break;
                                case '$':
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    break;
                                case '%':
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case '.':
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                            }
                        }
                        else if (value[i] == '^')
                        {
                            switch (value[i + 1])
                            {
                                case '0':
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case '1':
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    break;
                                case '2':
                                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    break;
                                case '3':
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    break;
                                case '4':
                                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    break;
                                case '5':
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    break;
                                case '6':
                                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                                    break;
                                case '7':
                                    Console.BackgroundColor = ConsoleColor.Gray;
                                    break;
                                case '8':
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    break;
                                case '9':
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    break;
                                case '&':
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    break;
                                case '!':
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    break;
                                case '@':
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    break;
                                case '#':
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    break;
                                case '$':
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    break;
                                case '%':
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case '.':
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                            }
                        }
                        i = i + 1;
                    }
                    else
                    {
                        printBuffer.Add(value[i]);
                    }
                }
                else
                {
                    printBuffer.Add(value[i]);
                }
            }
            originalOut.Write(printBuffer.ToArray());
        }

        public void WriteLeftAlignToColumn(string text, bool centerVertical, int column)
        {
            //If the text has line breaks, we'll assume everything should be centered.
            if (text.Contains("\r\n"))
            {
                string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                //Center vertically
                if (centerVertical)
                    Console.CursorTop = Math.Max(0, (24 - lines.Length) / 2) - 1;
                foreach (string line in lines)
                {
                    Console.CursorTop += 1;
                    Console.CursorLeft = column;
                    this.Write(line);
                }
            }
            else
            {
                if (centerVertical)
                    Console.CursorTop = Math.Max(0, (24 - text.Length) / 2);
                Console.CursorLeft = column;
                this.Write(text);
            }
        }

        public void WriteCenter(string text, bool centerVertical, bool centerHorizontal)
        {
            //If the text has line breaks, we'll assume everything should be centered.
            if (text.Contains("\r\n"))
            {
                string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                //Center vertically
                if (centerVertical)
                    Console.CursorTop = Math.Max(0, (24 - lines.Length) / 2) - 1;
                foreach (string line in lines)
                {
                    Console.CursorTop += 1;
                    if (centerHorizontal)
                        Console.CursorLeft = Math.Max(0, (Console.BufferWidth - RawTextLength(line)) / 2);
                    this.Write(line);
                }
            }
            else
            {
                if (centerVertical)
                    Console.CursorTop = Math.Max(0, (24 - text.Length) / 2);
                if (centerHorizontal)
                    Console.CursorLeft = Math.Max(0, (Console.BufferWidth - RawTextLength(text)) / 2);
                this.Write(text);
            }
        }

        //Returns the length of the string without any color formatting characters
        int RawTextLength(string text)
        {
            List<char> ColorChars = new List<char>();
            ColorChars.AddRange(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '@', '#', '$', '%', '.' });
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {

                if (text[i] == '`' || text[i] == '^')
                {
                    if (i + 1 < text.Length && ColorChars.Contains(text[i + 1]))
                        i++;
                    else
                        count += 1;
                }
                else
                    count += 1;
            }

            return count;
        }
    }
}
