namespace StartProgram
{
    using System;
    using Sepo;
    using Task_1;
    using Task_2;
    using Task_3;

    class Start
    {
        static void Main()
        {
            while (true)
            {
                if (!Tumbler())
                {
                    break;
                }
            }
        }

        static bool Tumbler()
        {
            Console.Clear();
            var st = new SetLabel();
            st.Label("Выберите действие");
            st.AddPoint(0, "Выход");
            st.AddPoint(1, "Проверка ввода логина");
            st.AddPoint(2,"Операции с текстом");
            st.AddPoint(3,"Проверка на анаграммность");

            switch (st.UserSelTask())
            {
                case 0:
                    Exit.ExitProgram();
                    return false;
                case 1:
                    CheckLogin.Main();
                    return true;
                case 2:
                    Task_2.Main();
                    return true;
                case 3:
                    Anagram.Main();
                    return true;
                default:
                    return true;
            }
        }
    }
}
