using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sepo;
using Task_1;

namespace StartProgram
{
    class Start
    {
        private static bool exit;
        static void Main()
        {
            while(true){

                Console.Clear();
                var st = new SetLabel();
                st.Label("Выберите действие");
                st.AddPoint(0, "Выход");
                st.AddPoint(1, "Проверка ввода логина");


                switch (st.UserSelTask())
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        CheckLogin.Main();
                        break;
                }

                if (exit)
                {
                    break;
                }
            }
        }
    }
}
