using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace epic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var textToMorse = new Dictionary<char, String>
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

            var morseToText = textToMorse.ToDictionary(x => x.Value, x => x.Key);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press 1 to encode, press 2 to decode, press 3 to play through a morse code statement, press any other button to exit");
                String ans = Console.ReadLine().Trim();

                if (!"123".Contains(ans) || ans == "") break;

                Console.WriteLine("Enter string");
                String str = Console.ReadLine().ToLower().Trim();

                if (ans == "1")
                {
                    Console.WriteLine(Encode(str, textToMorse));
                }
                else if (ans == "2")
                {
                    Console.WriteLine(Decode(str, morseToText));
                }
                else
                {
                    playMorse(str);
                }
                Console.ReadKey();
            }
            static String Encode(String str, Dictionary<char, String> textToMorse)
            {
                String morseStr = "";
                try
                {
                    foreach (char c in str)
                    {
                        morseStr += textToMorse[c] + " ";
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Can only encode a-z and 0-9");
                }
                return morseStr;
            }
            static String Decode(String str, Dictionary<String, char> morseToText)
            {
                String tranStr = "";
                String morseLetter = "";
                try
                {
                    foreach (char c in str)
                    {
                        if (c == ' ')
                        {
                            tranStr += morseToText[morseLetter];
                            morseLetter = "";
                        }
                        else
                        {
                            morseLetter += c;
                        }
                    }
                    tranStr += morseToText[morseLetter];
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please enter morse string in a format similar to this: \n" +
                        ".... . .-.. .-.. --- | .-- --- .-. .-.. -..");
                }
                return tranStr;
            }
            static void playMorse(String str)
            {
                Thread.Sleep(100);
                foreach (char c in str)
                {
                    switch (c)
                    {
                        case '.':
                            Console.Beep(500, 500);
                            Thread.Sleep(100);
                            break;

                        case '-':
                            Console.Beep(500, 1000);
                            Thread.Sleep(100);
                            break;

                        case '|':
                        case ' ':
                            Thread.Sleep(750);
                            break;
                    }
                }
            }
        }
    }
}