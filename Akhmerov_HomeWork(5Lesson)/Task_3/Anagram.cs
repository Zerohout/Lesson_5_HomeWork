using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sepo;

namespace Task_3
{
    public class Anagram
    {
        public static void Main()
        {
           StartTask();
        }

        static void StartTask()
        {
            while (true)
            {
                string[] anagramm;
                Console.Clear();
                Console.WriteLine("Введите через пробел 2 слова и я проверю, являются ли они анаграммами: ");
                try
                {
                    anagramm = Console.ReadLine().Split(' ');
                    if (anagramm.Length != 2)
                    {
                        continue;
                    }

                }
                catch
                {
                    continue;
                }

                var firstWord = anagramm[0].ToCharArray();
                Array.Sort(firstWord);
                var secondWord = anagramm[1].ToCharArray();
                Array.Sort(secondWord);

                if (Matches(firstWord,secondWord))
                {
                    ColorText.SetColorText("Слова ", ConsoleColor.Green, "являются", " анаграммами!\n\n");
                }
                else
                {
                    ColorText.SetColorText("Слова ", ConsoleColor.Red, "не являются", " анаграммами!\n\n");
                }

                if (Exit.ExitTask() != 1)
                {
                    break;

                }
            }
        }

        static bool Matches(char[] first, char[] second)
        {
            for(var i = 0; i < first.Length;i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

}
