using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BåtklubbGladPirat.Model;

namespace BåtklubbGladPirat.View
{
    class BoatView
    {
        private const string boatTextFile = "./boat.txt";
        private const string memberTextFile = "./medlem.txt";
        public static string[] boatType = new string[] { "Segelbåt", "Motorseglare", "Motorbåt", "Kajak/Kanot", "Övrigt" };

        private int _type;
        private int _length;

        public int getLength()
        {
            return _length;
        }

        public int getType() 
        {
            return _type;
        }

        MemberView memberView = new MemberView();

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
        public void AddBoat(List<string> memberList)
        {
            int count = 0;
            foreach (string line in memberList)
            {
                Console.WriteLine("{0}: {1}", count, line);
                count++;
            }

            Console.Write("Lägga till en båt på vem?: ");
            memberView.setMemberNumber(int.Parse(Console.ReadLine()));

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");
            foreach (string line in boatType)
            {
                Console.WriteLine("{0}: {1}", countBoatType, line);
                countBoatType++;
            }
            _type = int.Parse(Console.ReadLine());

            Console.Write("Hur lång är båten i CM?: ");
            _length = int.Parse(Console.ReadLine());
        }
    }
}
