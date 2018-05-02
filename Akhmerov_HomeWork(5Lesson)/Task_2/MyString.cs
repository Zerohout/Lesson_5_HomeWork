namespace Task_2
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Sepo;

    public class Task_2
    {

        public static void Main()
        {
            var tt = new TaskTumbler();
            while (true)
            {
                if (tt.Own())
                {
                    while (true)
                    {
                        if (!tt.StartTask())
                        {
                            break;
                        }
                    }
                }
                else
                {
                    tt = new TaskTumbler();
                    while (true)
                    {
                        if (!tt.StartTask())
                        {
                            break;
                        }
                    }
                }

                if (tt.TaskExit())
                {
                    break;
                }
            }
        }
    }

    class TaskTumbler
    // Переключатель заданий
    {
        private bool own;
        public bool Own() => own;
        private bool taskExit;
        public bool TaskExit() => taskExit;
        string ownText;
        public bool StartTask()
        // Метод старта задания
        {
            var ms = own ? new MyString(ownText) : new MyString();
            var sl = new SetLabel();

            int sel;

            do
            {
                Console.Clear();

                Console.Write($"\n\n{ms.Text()}");
                sl.Label("Выберите действие, которое хотите произвести над данным текстом");
                sl.AddPoint(0, "Вернуться в начально меню");
                sl.AddPoint(1, "Вывести только те слова текста, которые содержат не более чем n букв");
                sl.AddPoint(2, "Удалить из текста все слова, которые заканчиваются на заданную букву");
                sl.AddPoint(3, "Найти самое длинное слово в тексте");
                sl.AddPoint(4, "Найти все самые длинные слова в тексте");
                sl.AddPoint(5, own ? "Вернуть стандартный текст" : "Ввести свой текст");

                sel = sl.UserSelTask();
            } while (sel < 0 || sel > 5);

            var label = "";
            switch (sel)
            {
                case 0: // Выход в начальное меню
                    taskExit = true;
                    return false;
                case 1: // Пункт a)
                    label =
                        "\n\nВведите количество букв, которое \nмаксимально может содержать слово(иные слова отсеются): ";
                    break;
                case 2: // Пунк b)
                    label =
                        "\n\nВведите букву (1 букву, не больше не меньше)\nслова заканчивающиеся на данную букву будут удалены: ";
                    break;
                case 3: // Пункт c)
                    label = "\n\nНажмите Enter и на экране возникнет самое длинное слово в данном тексте: ";
                    break;
                case 4: // Пункт d) 
                    label = "\n\nНажмите Enter и на экране появятся все самые длинные слова: ";
                    break;
                case 5: // Возможность самому ввести текст
                    if (!own)
                    {
                        sl.Label("Введите свой (наверяка более изящный, рифмованный, и видимо намного лучше моего) текст");
                        ownText = Console.ReadLine();
                        own = true;
                        return false;
                    }
                    else
                    {
                        own = false;
                        return false;
                    }
            }
            Console.WriteLine($"\n\n{ms.TextOperations(label, sel)}");


            var i = Exit.ExitTask(); // Повтор задания/Переход к выбору задания/Переход к начальному меню

            switch (i)
            {
                case 1:
                    return true;
                case 2:
                    return false;
                case 3:
                    taskExit = false;
                    return false;
            }

            return true;

        }
    }

    class MyString
    // Класс для работы с текстом
    {
        StringBuilder sb;

        public MyString(string sb)
        {
            this.sb = new StringBuilder(sb);
        }

        public MyString()
        {
            sb = new StringBuilder("В лесу по дорожке шел зловещий сапожник, об камень споткнулся и грязно ругнулся\nНикто не услышал, никто не узнал, от слов таких грязных он замертво пал.\nМораль сего текста была такова: хоть в лесу одному, хоть на людях со зла\nБудь ты взрослым бугаем, иль младым дитя, ругаться не нужно, иль будет беда.");
        }

        public string Text() => sb.ToString();

        public string TextOperations(string label, int numOper)
        // Операции над текстом
        {
            while (true)
            {
                Console.Clear();
                Console.Write(label);
                var symCount = -1;
                var lastSym = ' ';

                switch (numOper)
                {
                    case 1: // Пункт a)
                        try
                        {
                            symCount = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            symCount = -1;
                        }
                        if (symCount <= 0) continue;

                        break;
                    case 2: // Пункт b)
                        try
                        {
                            lastSym = char.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            continue;
                        }

                        break;
                    default: // Пункты c) и d)
                        Console.ReadLine();
                        break;
                }

                char[] symbols = { ',', '.', ':', ';', '!', '?', '\n' };
                var tempWords = new List<string>(Text().Split(symbols));
                var maxWords = new List<string>();
                var allWords = new List<string>();
                var tempText = new StringBuilder();
                var maxWord = " ";

                foreach (var t in tempWords) // Перебор текста без знаков пунктуации
                {
                    if (t.Length < 1)
                    {
                        continue; // Пропуск нулевых значений
                    }

                    foreach (var s in t.Split(' ')) // Перебор слов в отрывке текста без знаков пунктуации
                    {
                        if (s.Length < 1)
                        {
                            continue; // Пропуск нулевых значений
                        }

                        allWords.Add(s); // Добавление всех слов в массив (без пустых мест и пробелов)

                        switch (numOper)
                        {
                            case 1: // Пункт a)
                                if (s.Length > symCount)
                                {
                                    continue;
                                }

                                break;
                            case 2: // Пункт b)
                                if (s[s.Length - 1] == lastSym)
                                {
                                    continue;
                                }

                                break;
                            default: // Пункты c) и d)
                                if (s.Length > maxWord.Length)
                                {
                                    maxWord = s;
                                    continue;
                                }

                                break;
                        }

                        if (numOper == 1 || numOper == 2) // Если пункты a) и b)
                        {
                            tempText.Append($"{s} ");
                        }
                        else if (numOper == 4) // Если пункт d)
                        {
                            if (t == (tempWords[tempWords.Count - 1] == "" ? tempWords[tempWords.Count - 2] : tempWords[tempWords.Count - 1]) &&
                                                            s == t.Split(' ')[t.Split(' ').Length - 1])
                            // Если t равно последнему элементу массива tempWords (или предпоследнему если последний элемент массива tempWords равен нулю) И 
                            // Если s равен последнему элементу массива t.Split(' ') (в данном случае послдений элемент не может буть нулевым)
                            {
                                foreach (var word in allWords)
                                {
                                    if (word.Length == maxWord.Length)
                                    {
                                        tempText.Append($"{word} ");
                                    }
                                }
                            }
                        }
                    }
                }

                if (numOper == 3) // Пункт c)
                {
                    return maxWord;
                }

                return tempText.ToString();
            }
        }
    }
}
