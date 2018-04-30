using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sepo
{
    class Program
    {
        static void Main()
        {

        }
    }
    public class SetLabel
    // Отрисовка меню
    {
        private int selectedTask;
        public void Label(string label) // Заголовок меню
        {
            Console.SetCursorPosition(20, Console.CursorTop + 3);
            Console.WriteLine($"{label}:");
        }

        public void AddPoint(int numTask, string nameTask) // Пункт меню
        {
            Console.SetCursorPosition(20, Console.CursorTop + 2);
            Console.WriteLine($"{numTask}) {nameTask}.");
        }

        public int UserSelTask() // Выбор пользователя
        {
            try
            {
                selectedTask = int.Parse(Console.ReadLine());
            }
            catch
            {
                selectedTask = -1;
            }
            return selectedTask;
        }

        //public int SelectedTask() => selectedTask;
    }

    public static class Exit // Выход
    {
        public static int ExitTask() // Выход из задания
        {
            var sl = new SetLabel();

            while (true) // Цикл выбора после завершения задания
            {
                int i;
                sl.Label("Выберите необходимое действие");
                sl.AddPoint(1, "Повторить задание");
                sl.AddPoint(2, "Завершить задание");
                sl.AddPoint(3, "Выход в главное меню");
                try
                {
                    i = (int.Parse(Console.ReadLine()));
                }
                catch
                {
                    i = 0;
                }

                if (i > 0 && i < 4)
                {
                    return i;
                }
            }
        }
    }

    public static class ColorText // Покраска текста 
    {
        public static void SetColorText(string firstText, ConsoleColor color, string colorText, string secondText)
        // Покраска текста в формате {Текст, Покрашенный текст, Текст}
        {
            Console.Write(firstText);
            Console.ForegroundColor = color;
            Console.Write(colorText);
            Console.ResetColor();
            Console.WriteLine(secondText);
        }
    }
}
