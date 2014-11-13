using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BåtklubbGladPirat.View
{
    class MenuView
    {
        public void ContinueOnKeyPressed()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n   Tryck tangent för att fortsätta   ");
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = true;
        }

        public int GetMenuChoice()          //Skriver ut menyn
        {
            int choice = 0;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("=     Den glade piraten     =");
            Console.ResetColor();
            Console.WriteLine(" - Medlem -----------------------\n");
            Console.WriteLine(" 0. Avsluta.");
            Console.WriteLine(" 1. Lägg till medlem.");
            Console.WriteLine(" 2. Visa kompakt lista.\n");
            Console.WriteLine(" 3. Visa fullständig lista.\n");
            Console.WriteLine(" 4. Ta bort medlem.\n");
            Console.WriteLine(" 5. Redigera medlem.\n");
            Console.WriteLine(" 6. Visa medlem.\n");
            Console.WriteLine(" - Båt --------------------\n");
            Console.WriteLine(" 7. Registrera båt.\n");
            Console.WriteLine(" 8. Ta bort båt.\n");
            Console.WriteLine(" 9. Redigera båt.\n");
            Console.WriteLine(" ===============================\n");
            Console.WriteLine(" Ange menyval [0-9]:");

            do
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());         //Läser in ett menyval 0-5 som användaren matar in

                    if (choice > 9 || choice < 0)           //Kastar undantag om det inte är inom intervallet
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Det inmatade menyvalet är inte inom intervallet 0-9");
                    Console.ResetColor();
                }

            } while (true);
            return choice;   //Returnar menyvalet
        }
    }
}
