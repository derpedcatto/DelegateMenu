using System;
using System.Reflection;

namespace DelegateMenu
{
    
    class Program
    {
        delegate void MenuButtons();

        static void PrintMenu()
        {
            Console.Write("1 - New Game\n2 - Load Game\n3 - Show Rules\n4 - About Author\n0 - Exit\n\n--> ");
        }

        static void NewGame()
        {
            Console.WriteLine("\nNew Game Started!\n");
        }
        static void LoadGame()
        {
            Console.WriteLine("\nGame loaded!\n");
        }
        static void ShowRules()
        {
            Console.WriteLine("\nRules are presented!\n");
        }
        static void AboutAuthor()
        {
            Console.WriteLine("\nAuthor - derpedcatto\n");
        }
        static void Exit()
        {
            System.Environment.Exit(1);
        }


        static void Main()
        {
            MenuButtons menu = Exit;
            menu += NewGame;
            menu += LoadGame;
            menu += ShowRules;
            menu += AboutAuthor;

            while (true)
            {
                PrintMenu();
                int input;

                try
                {
                    input = Convert.ToInt32(Console.ReadLine());

                    MethodInfo mi = menu.GetInvocationList()[input].Method;
                    mi.Invoke(typeof(Program), new object[] { });
                }
                catch
                {
                    Console.WriteLine("\nWrong value!\n");
                    continue;
                }
            }
        }
    }
}