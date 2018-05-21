using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse10Min
{
    class Program
    {
        static Dictionary<string, string> MorseConvert = new Dictionary<string, string>(72)
        {
            [".-"] = "A",
            ["-..."] = "B",
            ["-.-."] = "C",
            ["-.."] = "D",
            ["."] = "E",
            ["..-."] = "F",
            ["--."] = "G",
            ["...."] = "H",
            [".."] = "I",
            [".---"] = "J",
            ["-.-"] = "K",
            [".-.."] = "L",
            ["--"] = "M",
            ["-."] = "N",
            ["---"] = "O",
            [".--."] = "P",
            ["--.-"] = "Q",
            [".-."] = "R",
            ["..."] = "S",
            ["-"] = "T",
            ["..-"] = "U",
            ["...-"] = "V",
            [".--"] = "W",
            ["-..-"] = "X",
            ["-.--"] = "Y",
            ["--.."] = "Z",
            [".----"] = "1",
            ["..---"] = "2",
            ["...--"] = "3",
            ["....-"] = "4",
            ["....."] = "5",
            ["-...."] = "6",
            ["--..."] = "7",
            ["---.."] = "8",
            ["----."] = "9",
            ["-----"] = "0",

            ["A"] = ".-",
            ["B"] = "-...",
            ["C"] = "-.-.",
            ["D"] = "-..",
            ["E"] = ".",
            ["F"] = "..-.",
            ["G"] = "--.",
            ["H"] = "....",
            ["I"] = "..",
            ["J"] = ".---",
            ["K"] = "-.-",
            ["L"] = ".-..",
            ["M"] = "--",
            ["N"] = "-.",
            ["O"] = "---",
            ["P"] = ".--.",
            ["Q"] = "--.-",
            ["R"] = ".-.",
            ["S"] = "...",
            ["T"] = "-",
            ["U"] = "..-",
            ["V"] = "...-",
            ["W"] = ".--",
            ["X"] = "-..-",
            ["Y"] = "-.--",
            ["Z"] = "--..",
            ["1"] = ".----",
            ["2"] = "..---",
            ["3"] = "...--",
            ["4"] = "....-",
            ["5"] = ".....",
            ["6"] = "-....",
            ["7"] = "--...",
            ["8"] = "---..",
            ["9"] = "----.",
            ["0"] = "-----"
        };
        
        static int longestMorse = 6;
        static void Main(string[] args)
        {
            string input;
            do
            {
                input = Console.ReadLine();
                int iterations = 0;
                var possibilities = GetPossibleLettersFromMorse(input, 0, "", out iterations);

                foreach (var str in possibilities)
                {
                    Console.Write(str + ", ");
                }
                Console.Write(iterations);

                Console.WriteLine();
            } while (input.ToLower() != "exit");

            Console.ReadKey();

        }

        static List<string> GetPossibleLettersFromMorse(string morse, int index, string currentStr, out int iterations)
        {
            List<string> arr = new List<string>();
            iterations = 1;
            for (int i = 1; i <= longestMorse && index + i <= morse.Length; i++)
            {
                string subStr = morse.Substring(index, i);
                iterations++;
                if (MorseConvert.ContainsKey(subStr))
                {
                    string newString = MorseConvert[subStr];
                    int newIterations = 0;
                    var next = GetPossibleLettersFromMorse(morse, index + i, currentStr+newString, out newIterations);
                    iterations += newIterations;
                    if (next.Count > 0)
                    {
                        arr.AddRange(next);
                    }
                    else
                    {
                        arr.Add(currentStr + newString);
                    }
                    //if (next.Count > 0)
                    //{
                    //    foreach (string str in next)
                    //    {
                    //        iterations++;
                    //        arr.Add(newString + str);
                    //    }
                    //}
                    //else
                    //{
                    //    arr.Add(newString);
                    //}
                }
            }

            return arr;
        }
    }
}
