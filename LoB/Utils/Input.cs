using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace New_Dawn.Game
{
    public static class Input
    {
        #region User Input
        public static string GetUserInput(string prompt, string defaultValue)
        {
            return GetUserInput(prompt, false, false, defaultValue);
        }

        public static string GetUserInput(string prompt)
        {
            return GetUserInput(prompt, false, false, string.Empty);
        }

        public static string GetUserInput(string prompt, bool centerVertical, bool centerHorizontal)
        {
            return GetUserInput(prompt, false, false, string.Empty);
        }

        public static string GetUserInput(string prompt, bool mask, bool numeric, string defaultValue)
        {
            Console.Write(prompt + defaultValue);
            Stack chars = new Stack();

            if (defaultValue != null)
                foreach (char c in defaultValue.ToArray())
                    chars.Push(c.ToString());

            // keep reading
            for (ConsoleKeyInfo keyInfo = Console.ReadKey(true); keyInfo.Key != ConsoleKey.Enter || (keyInfo.Key == ConsoleKey.Enter && chars.Count == 0); keyInfo = Console.ReadKey(true))
            {
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (chars.Count > 0)
                    {
                        // rollback the cursor and write a space so it looks backspaced to the user
                        DoBackSpace();
                        chars.Pop();
                    }
                }

                if (IsFunction(keyInfo.Key)) return keyInfo.Key.ToString();

                else if (keyInfo.Key != ConsoleKey.Enter)
                {
                    string s = keyInfo.KeyChar.ToString();
                    if (numeric && (!IsNumeric(keyInfo.Key) || chars.Count >= 5))
                        continue;
                    Console.Write((mask) ? "*" : s);
                    chars.Push(s);
                }
            }
            object[] o = chars.ToArray();
            Array.Reverse(o);
            Console.WriteLine();
            string returnString = string.Empty;
            for (int i = 0; i < o.Length; i++)
            {
                returnString += o[i].ToString();
            }
            return returnString;
        }

        public static void DoBackSpace()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Console Left {0}", Console.CursorLeft));
            Console.CursorLeft -= 1;
            Console.Write(" ");
            System.Diagnostics.Debug.WriteLine(string.Format("Console Left {0}",Console.CursorLeft));
        }

        public static bool GetYesNo(string prompt)
        {
            Console.Write(prompt);
            // keep reading
            for (ConsoleKeyInfo keyInfo = Console.ReadKey(true); keyInfo.Key != ConsoleKey.Escape; keyInfo = Console.ReadKey(true))
            {
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    return true;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine();
                    return false;
                }
                // rollback the cursor and write a space so it looks backspaced to the user
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(" ");
            }

            Console.WriteLine();
            return false;
        }

        public static bool IsFunction(ConsoleKey key)
        {
            switch (key)
            {
                //Help
                case ConsoleKey.F1:
                //Show help screen
                case ConsoleKey.F2:
                //Show character screen
                case ConsoleKey.F3:
                case ConsoleKey.F4:
                    return true;
            }
            return false;
        }

        public static bool IsNumeric(ConsoleKey key)
        {
            switch (key)
            {

                case ConsoleKey.D0:
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                case ConsoleKey.D6:
                case ConsoleKey.D7:
                case ConsoleKey.D8:
                case ConsoleKey.D9:
                case ConsoleKey.NumPad0:
                case ConsoleKey.NumPad1:
                case ConsoleKey.NumPad2:
                case ConsoleKey.NumPad3:
                case ConsoleKey.NumPad4:
                case ConsoleKey.NumPad5:
                case ConsoleKey.NumPad6:
                case ConsoleKey.NumPad7:
                case ConsoleKey.NumPad8:
                case ConsoleKey.NumPad9:
                    return true;
            }
            return false;
        }
        #endregion
    }
}
