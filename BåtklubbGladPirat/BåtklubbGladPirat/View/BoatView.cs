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
        public static string[] m_boatType;

        private int _type;
        private int _length;
        private int _boatNumber;

        public int getLength()
        {
            return _length;
        }

        public int getType() 
        {
            return _type;
        }

        public int getBoatNumber()
        {
            return _boatNumber;
        }


        public BoatView(string[]boatType) { 
          m_boatType = boatType; 
            
        
        }

        public void EditBoat(List<string> boatList) //Frågar vilken båt du vill redigera
        {
            int count = 0;
            foreach (string r in boatList)
            {
                Console.WriteLine("{0}: {1}", count, r);
                count++;
            }

            Console.Write("Vilken båt vill du redigera?: ");
            _boatNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine(boatList[_boatNumber]);

            Console.WriteLine("Fyll i de nya uppgifterna");

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");
            foreach (string r in m_boatType)
            {
                Console.WriteLine("{0}: {1}", countBoatType, r);
                countBoatType++;
            }
            _type = int.Parse(Console.ReadLine());

            Console.Write("Ny längd: ");
            _length = int.Parse(Console.ReadLine());
        }
        //***
        public void RemoveBoat(List<string> boatList)//Frågar vilken båt man vill ta bort
        {
            int count = 0;
            
            foreach (string line in boatList)
            {
                Console.WriteLine("{0}: {1}", count, line); //lägger till radnummer framför
                count++;
            }

            Console.Write("Vilken båt vill du ta bort?: ");
            _boatNumber = int.Parse(Console.ReadLine());
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
            _boatNumber = int.Parse(Console.ReadLine());

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");
            foreach (string line in m_boatType)
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
