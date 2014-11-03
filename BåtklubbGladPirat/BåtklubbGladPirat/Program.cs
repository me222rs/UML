﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BåtklubbGladPirat
{
    class Program
    {
        private const string memberTextFile = "medlem.txt";
        private const string boatTextFile = "boat.txt";

        public static string[] boatType = new string[] { "Segelbåt", "Motorseglare", "Motorbåt", "Kajak/Kanot", "Övrigt" };

        static void Main(string[] args)
        {
            Program program = new Program();
             do
             {
                 switch (program.GetMenuChoice())//Visar menyn
                 {
                     case 0:
                         return; //Avsluta 
                     case 1:
                         program.CreateMember();//Skapa ny medlem
                         break;
                     case 2:
                         program.ViewCompactListMembers(); //Visa medlemmar med hur många båtar de har
                         break;
                     case 3:
                         program.ViewAllMembers(); // Visa alla medlemmar med deras båtar
                         break;
                     case 4:
                         program.DeleteMember();// Ta bort medlem
                         break;
                     case 5:
                         program.EditMember();// Redigera medlem
                         break;
                     case 6:
                         program.ShowMember();//Visa en enstaka medlem med hans båtar
                         break;
                     case 7:
                         program.AddBoat();//Lägger till en ny båt
                         break;
                     case 8:
                         program.RemoveBoat();//Tar bort en befintlig båt
                         break;
                     case 9:
                         program.EditBoat();//Redigerar en båt
                         break;
                 }
                 program.ContinueOnKeyPressed();
             } while (true);
        }
        //***
        private void EditBoat() //Frågar vilken båt du vill redigera
        {
            int count = 0;
            BoatModel BoatModel = new BoatModel(memberTextFile);
            List<string> boatList = BoatModel.ViewAllboats();
            foreach (string r in boatList)
            {
                Console.WriteLine("{0}: {1}", count, r);
                count++;
            }

            Console.Write("Vilken båt vill du redigera?: ");
            int boat = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine(boatList[boat]);

            Console.WriteLine("Fyll i de nya uppgifterna");

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");
            foreach (string r in boatType)
            {
                Console.WriteLine("{0}: {1}", countBoatType, r);
                countBoatType++;
            }
            int type = int.Parse(Console.ReadLine());

            Console.Write("Ny längd: ");
            int length = int.Parse(Console.ReadLine());

            int memberID = int.Parse(boatList[boat].Substring(0, 6));

            BoatModel.Editboat(boat, boatList, type, length, memberID);

            Console.Write("SUCCESS");
        }
        //***
        private void RemoveBoat()//Frågar vilken båt man vill ta bort
        {
            int count = 0;
            BoatModel BoatModel = new BoatModel(boatTextFile);
            List<string> boatList = BoatModel.ViewAllboats();
            foreach (string line in boatList)
            {
                Console.WriteLine("{0}: {1}", count, line); //lägger till radnummer framför
                count++;
            }

            Console.Write("Vilken båt vill du ta bort?: ");
            int boat = int.Parse(Console.ReadLine());

            BoatModel.RemoveBoat(boat, boatList);
        }
        //***
        private void AddBoat() 
        {
            BoatModel BoatModel = new BoatModel(boatTextFile);

            int count = 0;
            MemberModel model = new MemberModel(memberTextFile);
            List<string> memberList = model.ViewAllMembers();
            foreach (string line in memberList)
            {
                Console.WriteLine("{0}: {1}", count, line);
                count++;
            }

            Console.Write("Lägga till en båt på vem?: ");
            int member = int.Parse(Console.ReadLine());

            int memberID = int.Parse(memberList[member].Substring(0, 6));

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");
            foreach (string line in boatType) 
            {
                Console.WriteLine("{0}: {1}", countBoatType, line);
                countBoatType++;
            }
            int type = int.Parse(Console.ReadLine());

            Console.Write("Hur lång är båten i CM?: ");
            int length = int.Parse(Console.ReadLine());

            
            BoatModel.AddBoat(memberID, type, length);
        }
        //***
        private void ShowMember()//Visa enskild medlem 
        {
            int count = 0;
            MemberModel MemberModel = new MemberModel(memberTextFile);
            List<string> memberList = MemberModel.ViewCompactListMembers();
            foreach (string line in memberList)
            {
                Console.WriteLine("{0}: {1}", count, line);
                count++;
            }

            Console.Write("Vilken medlem vill du visa?: ");
            int member = int.Parse(Console.ReadLine());

            Console.Clear();
            List<string> oneMemberList = MemberModel.ViewAllMembers();
            Console.WriteLine(oneMemberList[member]);
        }

        private void EditMember() //Frågar vilken medlem du vill redigera
        {
            int count = 0;
            MemberModel model = new MemberModel(memberTextFile);
            List<string> memberList = model.ViewAllMembers();
            foreach (string line in memberList)
            {
                Console.WriteLine("{0}: {1}", count, line);
                count++;
            }

            Console.Write("Vilken medlem vill du redigera?: ");
            int member = int.Parse(Console.ReadLine());

            Console.Clear();
            List<string> oneMemberList = model.ViewAllMembers();
            Console.WriteLine(oneMemberList[member]);

            Console.WriteLine("Fyll i de nya uppgifterna");

            Console.Write("Nytt namn: ");
            string name = Console.ReadLine();

            Console.Write("Nytt personnummer: ");
            int personalID = int.Parse(Console.ReadLine());

            int memberID = int.Parse(memberList[member].Substring(0, 6));
            
            model.EditMember(member, memberList, name, personalID, memberID);

            Console.Write("SUCCESS");
        }
        //***
        private void DeleteMember()//Frågar vilken medlem man vill ta bort
        {
            int count = 0;
            MemberModel model = new MemberModel(memberTextFile);
            List<string> memberList = model.ViewAllMembers();
            foreach (string line in memberList)
            {
                Console.WriteLine("{0}: {1}", count, line); //lägger till radnummer framför
                count++;
            }

            Console.Write("Vilken medlem vill du ta döda?: ");
            int member = int.Parse(Console.ReadLine());

            
            model.DeleteMember(member, memberList);
        }

        private void ViewCompactListMembers() 
        {
            MemberModel model = new MemberModel(memberTextFile);
            List<string>members = model.ViewCompactListMembers();
            foreach (string r in members) 
            {
                Console.WriteLine(r);
            }
            
        }

        private void ViewAllMembers()//visar alla medlemmar med deras båtar
        {
            MemberModel model = new MemberModel(memberTextFile);
            List<string> members = model.ViewCompleteMembers();
            foreach (string line in members)
            {
                Console.WriteLine(line);
            } 
        }

        private void CreateMember() 
        {
            Console.Write("Förnamn: ");
            string firstName = Console.ReadLine();

            if(firstName == "" || firstName == null){
                throw new Exception();
            }

            Console.Write("Personnummer(10 siffror): ");
            int personNummer = int.Parse(Console.ReadLine());
            double numberOfDigits = Math.Floor(Math.Log10(personNummer) + 1);
            if (personNummer == null || numberOfDigits != 10)
            {
                throw new Exception();
            }

            MemberModel model = new MemberModel(memberTextFile);
            model.CreateMember(firstName, personNummer);
        }

        private void ContinueOnKeyPressed()
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

        int GetMenuChoice()          //Skriver ut menyn
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
