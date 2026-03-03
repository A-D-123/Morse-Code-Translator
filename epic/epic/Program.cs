using System;
using System.Collections.Generic;
using System.Linq;

namespace epic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var morseCode = new Dictionary<char, String>
            {
                //alphabet
                {'a', ".-"},
                {'b', "-..."},
                {'c', "-.-."},
                {'d', "-.."},
                {'e', "."},
                {'f', "..-."},
                {'g', "--."},
                {'h', "...."},
                {'i', ".."},
                {'j', ".---"},
                {'k', "-.-"},
                {'l', ".-.."},
                {'m', "--"},
                {'n', "-."},
                {'o', "---"},
                {'p', ".--."},
                {'q', "--.-"},
                {'r', ".-."},
                {'s', "..."},
                {'t', "-"},
                {'u', "..-"},
                {'v', "...-"},
                {'w', ".--"},
                {'x', "-..-"},
                {'y', "-.--"},
                {'z', "--.."},
                
                //numbers
                {'1', ".----"},
                {'2', "..---"},
                {'3', "...--"},
                {'4', "....-"},
                {'5', "....."},
                {'6', "-...."},
                {'7', "--..."},
                {'8', "---.."},
                {'9', "----."},
                {'0', "-----"},

                //other
                {' ', "|"}
            };

            var morseToText = morseCode.ToDictionary(x => x.Value, x => x.Key);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press 1 to encode press 2 to decode press any other button to exit");
                String ans = Console.ReadLine();

                if (ans != "1" && ans != "2") break;
                
                Console.WriteLine("Enter string");
                String str = Console.ReadLine().ToLower();

                if (ans == "1")
                {
                    foreach (char c in str)
                    {
                        Console.Write(morseCode[c] + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    try
                    {
                        String morseLetter = "";
                        foreach (char c in str)
                        {
                            if (c == ' ')
                            {
                                Console.Write(morseToText[morseLetter]);
                                morseLetter = "";
                            }
                            else
                            {
                                morseLetter += c;
                            }
                        }
                        Console.WriteLine(morseToText[morseLetter]);
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter morse string in a format similar to this: \n" +
                            ".... . .-.. .-.. --- | .-- --- .-. .-.. -..");
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
