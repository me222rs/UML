using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BåtklubbGladPirat
{
    class Program
    {
        private const string memberTextFile = "medlem.txt";

        static void Main(string[] args)
        {
            Model model = new Model(memberTextFile); 
            //List<Recipe> myRecipeList = new List<Recipe>();
             do
             {
                 switch (GetMenuChoice())           //Visar menyn
                 {
                     case 0:
                         return;
                     case 1:
                         CreateMember();
                         break;
                     case 2:
                         ViewCompactListMembers();
                         break;
                     case 3:
                         ViewAllMembers();
                         break;



                 }
                 ContinueOnKeyPressed();
             } while (true);
        }

        private static void ViewCompactListMembers() 
        {
            Model model = new Model(memberTextFile);
            List<string>members = model.ViewCompactListMembers();
            foreach (string r in members) 
            {
                Console.WriteLine(r);
            }
            
        }

        private static void ViewAllMembers()
        {
            Model model = new Model(memberTextFile);
            List<string> members = model.ViewAllMembers();
            foreach (string r in members)
            {
                Console.WriteLine(r);
            } 
        }

        private static void CreateMember() 
        {
            Console.Write("Förnamn: ");
            string firstName = Console.ReadLine();

            Console.Write("Personnummer: ");
            int personNummer = int.Parse(Console.ReadLine());


            Model model = new Model(memberTextFile);
            model.CreateMember(firstName, personNummer);
        }

        private static void ContinueOnKeyPressed()
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

        private static int GetMenuChoice()          //Skriver ut menyn
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
