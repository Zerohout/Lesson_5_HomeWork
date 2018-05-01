namespace StartProgram
{
    using System;
    using Sepo;
    using Task_1;

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

            switch (st.UserSelTask())
            {
                case 0:
                    Exit.ExitProgram();
                    return false;
                case 1:
                    CheckLogin.Main();
                    return true;
                default:
                    return true;
            }
        }
    }
}
