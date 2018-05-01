namespace Task_1
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using Sepo;

    public class CheckLogin
    {
        public static void Main()
        {
            while (true) // Цикл повтора списка заданий
            {
                if (!TaskTumbler())
                {
                    break;
                }
            }
        }

        static bool TaskTumbler()
        // Переключатель заданий
        {
            var sl = new SetLabel();
            int sel;

            do // Цикл выбора заданий
            {
                Console.Clear();
                sl.Label("Выберите действие");
                sl.AddPoint(0, "Возврат в главное меню");
                sl.AddPoint(1, "Проверка без регулярных выражений");
                sl.AddPoint(2, "Проверка с регулярным выражением");
                sel = sl.UserSelTask();
            } while (sel < 0 || sel > 2);

            while (true) // Цикл повтора заданий
            {
                switch (sel)
                {
                    case 0:
                        return false;
                    case 1:
                        Checking(1);
                        break;
                    case 2:
                        Checking(2);
                        break;
                }

                var i = Exit.ExitTask(); // Повтор задания/Переход к выбору задания/Переход к начальному меню

                switch (i)
                {
                    case 2:
                        return true;
                    case 3:
                        return false;
                }
            }
        }

        static void Checking(int numTask)
        // Метод проверки логина
        {
            Console.Clear();
            Console.WriteLine("\n\n\nВведите логин для проверки соответствия требованиям РКН:\n");
            var correct = false;
            switch (numTask)
            {
                case 1: // Проверка без регулярного выражения
                    var sb = new StringBuilder(Console.ReadLine(), 10);
                    correct = !char.IsNumber(sb[0]) && (sb.Length > 1 && sb.Length < 11);
                    break;
                case 2: // Проверка с регулярным выражением
                    var regex = new Regex(@"^[A-Za-zА-я]{1}[0-9A-Za-zА-я]{1,9}$");
                    correct = regex.IsMatch(Console.ReadLine());
                    break;
            }
            if (correct)
            {
                ColorText.SetColorText("Логин ", ConsoleColor.Green, "соответствует", " требованиям РКН!");
            }
            else
            {
                ColorText.SetColorText("Логин ", ConsoleColor.Red, "не соответствует", " требованиям РКН!");
                ColorText.SetColorText("\n\nЛогин должен быть не больше ", ConsoleColor.Yellow, " 10-ти", "знаков,\n");
                ColorText.SetColorText("1-й знак ", ConsoleColor.Yellow, " не должен быть", "числом.");
            }
        }
    }
}
