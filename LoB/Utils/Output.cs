using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Dawn.Game
{
    public static class Output
    {
        #region Screen Parsing functions

        //TODO: abstract this crap out in to a class that will then fire an event here with
        //the color and string to be printed with that color.

        public static void WriteLine(string str)
        {
            Write(str);
            Console.WriteLine();
        }
        public static void Write(string str)
        {
            /*Specials:
              Colors:
               ForeGround:
                `1 : Dark Red
                `2 : Dark Green
                `3 : Dark Yellow or Brown (depends on terminal)
                `4 : Dark Blue
                `5 : Dark Magenta or Purple (depends on terminal)
                `6 : Dark Cyan
                `7 : Light Grey (a.k.a. Dark White) (a.k.a. Normal)
                `8 : Dark Grey (a.k.a. Light Black)
                `9 : Bright Red
                `0 : Bright Green
                `! : Bright Yellow
                `@ : Bright Blue
                `# : Bright Magenta
                `$ : Bright Cyan
                `% : Bright White
                `. : Reset to TERM Default
               BackGround:
                ^1 : Dark Red
                ^2 : Dark Green
                ^3 : Dark Yellow or Brown (depends on terminal)
                ^4 : Dark Blue
                ^5 : Dark Magenta or Purple (depends on terminal)
                ^6 : Dark Cyan
                ^7 : Light Grey (a.k.a. Dark White) (a.k.a. Normal)
                ^8 : Dark Grey (a.k.a. Light Black)
                ^9 : Bright Red
                ^0 : Bright Green
                ^! : Bright Yellow
                ^@ : Bright Blue
                ^# : Bright Magenta
                ^$ : Bright Cyan
                ^% : Bright White
                ^. : Reset to TERM Default
               Display Game Date & raltive time, i.e 6th hour of 7
              */
            List<char> printBuffer = new List<char>();
            List<char> ColorChars = new List<char>();
            ColorChars.AddRange(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '@', '#', '$', '%', '.' });
            for (int i = 0; i < str.Length; i++)
            {


                if (i + 1 < str.Length && (str[i] == '`' || str[i] == '^'))
                {
                    if (ColorChars.Contains(str[i + 1]))
                    {
                        Console.Write(printBuffer.ToArray());
                        printBuffer = new List<char>();
                        if (str[i] == '`')
                        {
                            switch (str[i + 1])
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
                        else if (str[i] == '^')
                        {
                            switch (str[i + 1])
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
                        printBuffer.Add(str[i]);
                    }
                }
                else
                {
                    printBuffer.Add(str[i]);
                }
            }
            Console.Write(printBuffer.ToArray());
            //Always switch it back to default.
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.BackgroundColor = ConsoleColor.Black;
        }

        static public void WriteLeftAlignToColumn(string text, bool centerVertical, int column)
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
                    Write(line);
                }
            }
            else
            {
                if (centerVertical)
                    Console.CursorTop = Math.Max(0, (24 - text.Length) / 2);
                Console.CursorLeft = column;
                Write(text);
            }
        }       

        static public void WriteCenter(string text, bool centerVertical,bool centerHorizontal)
        {
            //If the text has line breaks, we'll assume everything should be centered.
            if (text.Contains("\r\n"))
            {
                string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                //Center vertically
                if(centerVertical)
                    Console.CursorTop = Math.Max(0, (24 - lines.Length) / 2)-1;
                foreach (string line in lines)
                {
                    Console.CursorTop += 1;
                    if(centerHorizontal)
                        Console.CursorLeft = Math.Max(0, (Console.BufferWidth - RawTextLength(line)) / 2);
                    Write(line);
                }
            }
            else
            {
                if(centerVertical)
                    Console.CursorTop = Math.Max(0, (24 - text.Length) / 2);
                if(centerHorizontal)
                    Console.CursorLeft = Math.Max(0, (Console.BufferWidth - RawTextLength(text)) / 2);
                Write(text);
            }
        }

        //Returns the length of the string without any color formatting characters
        static int RawTextLength(string text)
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

        #endregion
    }
}
