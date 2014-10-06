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
                     case 4:
                         DeleteMember();
                         break;
                     case 5:
                         EditMember();
                         break;
                     case 6:
                         ShowMember();
                         break;
                     case 7:
                         AddBoat();
                         break;
                     case 8:
                         RemoveBoat();
                         break;
                     //case 9:
                     //    EditBoat();
                     //    break;

                         
                 }
                 ContinueOnKeyPressed();
             } while (true);
        }

        private static void RemoveBoat()//Frågar vilken båt man vill ta bort
        {
            int count = 0;
            Model model = new Model("boat.txt");
            List<string> boatList = model.ViewAllboats();
            foreach (string r in boatList)
            {
                Console.WriteLine("{0}: {1}", count, r); //lägger till radnummer framför
                count++;
            }

            Console.Write("Vilken båt vill du ta sänka?: ");
            int boat = int.Parse(Console.ReadLine());

            model.RemoveBoat(boat, boatList);
        }

        private static void AddBoat() 
        {
            string[] boatType = new string[]{"Segelbåt", "Motorseglare", "Motorbåt", "Kajak/Kanot", "Övrigt"};

            int count = 0;
            Model model = new Model(memberTextFile);
            List<string> memberList = model.ViewCompleteMembers();
            foreach (string r in memberList)
            {
                Console.WriteLine("{0}: {1}", count, r);
                count++;
            }

            Console.Write("Lägga till en båt på vem?: ");
            int member = int.Parse(Console.ReadLine());

            int memberID = int.Parse(memberList[member].Substring(0, 6));

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");
            foreach (string r in boatType) 
            {
                Console.WriteLine("{0}: {1}", countBoatType, r);
                countBoatType++;
            }
            int type = int.Parse(Console.ReadLine());

            Console.Write("Hur lång är båtfan i CM?: ");
            int length = int.Parse(Console.ReadLine());

            model.AddBoat(memberID, type, length);
        }

        private static void ShowMember() 
        {
            int count = 0;
            Model model = new Model(memberTextFile);
            List<string> memberList = model.ViewCompactListMembers();
            foreach (string r in memberList)
            {
                Console.WriteLine("{0}: {1}", count, r);
                count++;
            }

            Console.Write("Vilken medlem vill du visa?: ");
            int member = int.Parse(Console.ReadLine());

            Console.Clear();
            List<string> oneMemberList = model.ViewCompleteMembers();
            Console.WriteLine(oneMemberList[member]);
        }

        private static void EditMember() //Frågar vilken jävla medlem du vill redigera
        {
            int count = 0;
            Model model = new Model(memberTextFile);
            List<string> memberList = model.ViewAllMembers();
            foreach (string r in memberList)
            {
                Console.WriteLine("{0}: {1}", count, r);
                count++;
            }

            Console.Write("Vilken medlem vill du redigera?: ");
            int member = int.Parse(Console.ReadLine());

            Console.Clear();
            List<string> oneMemberList = model.ViewCompleteMembers();
            Console.WriteLine(oneMemberList[member]);

            Console.WriteLine("Fyll i de nya uppgifterna");

            Console.Write("Nytt namn: ");
            string name = Console.ReadLine();

            Console.Write("Nytt personnummer: ");
            int personalID = int.Parse(Console.ReadLine());

            int memberID = int.Parse(memberList[member].Substring(0, 6));
            //int memberID = 
            
            model.EditMember(member, memberList, name, personalID, memberID);

            Console.Write("SUCCESS");
        }

        private static void DeleteMember()//Frågar vilken medlem man vill ta bort
        {
            int count = 0;
            Model model = new Model(memberTextFile);
            List<string> memberList = model.ViewAllMembers();
            foreach(string r in memberList){
                Console.WriteLine("{0}: {1}", count, r); //lägger till radnummer framför
                count++;
            }

            Console.Write("Vilken medlem vill du ta döda?: ");
            int member = int.Parse(Console.ReadLine());

            
            model.DeleteMember(member, memberList);
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
            List<string> members = model.ViewCompleteMembers();
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

        public static object boat { get; set; }
    }
}
