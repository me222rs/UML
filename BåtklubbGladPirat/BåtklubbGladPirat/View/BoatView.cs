﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BåtklubbGladPirat.Model;

namespace BåtklubbGladPirat.View
{
    class BoatView
    {
        private int _type;
        private int _length;
        private int _boatNumber;
        private BoatTypes selectedBoatType;

        public int getLength()
        {
            return _length;
        }

        public BoatTypes getSelectedBoatType() 
        {
            return selectedBoatType;
        }

        public int getBoatNumber()
        {
            return _boatNumber;
        }

        public void EditBoat(List<Boat> boatList) //Frågar vilken båt du vill redigera
        {
            int count = 0;
            foreach (Boat r in boatList)
            {
                Console.WriteLine("{0}: {1} {2} {3}", count, r.MemberID, r.Type, r.Length);
                count++;
            }

            Console.Write("Vilken båt vill du redigera?: ");
            _boatNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine(boatList[_boatNumber].Type + " " + boatList[_boatNumber].Length);

            Console.WriteLine("Fyll i de nya uppgifterna");

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");

            var values = Enum.GetValues(typeof(BoatTypes));
            foreach (BoatTypes r in values)
            {
                Console.WriteLine("{0}: {1}", countBoatType, r);
                countBoatType++;
            }
            selectedBoatType = (BoatTypes) int.Parse(Console.ReadLine());
            Console.Write("Ny längd: ");
            _length = int.Parse(Console.ReadLine());
        }
        //***
        public void RemoveBoat(List<Boat> boatList)//Frågar vilken båt man vill ta bort
        {
            int count = 0;
            
            foreach (Boat line in boatList)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.MemberID, line.Type); //lägger till radnummer framför
                count++;
            }

            Console.Write("Vilken båt vill du ta bort?: ");
            _boatNumber = int.Parse(Console.ReadLine());
        }
        //***
        public void AddBoat(List<Member> memberList)
        {
            int count = 0;
            foreach (Member line in memberList)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.MemberID, line.Name);
                count++;
            }

            Console.Write("Lägga till en båt på vem?: ");
            _boatNumber = int.Parse(Console.ReadLine());

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");
            var values = Enum.GetValues(typeof(BoatTypes));
            foreach (BoatTypes line in values)
            {
                Console.WriteLine("{0}: {1}", countBoatType, line);
                countBoatType++;
            }
            selectedBoatType = (BoatTypes) int.Parse(Console.ReadLine());
            Console.Write("Hur lång är båten i CM?: ");
            _length = int.Parse(Console.ReadLine());
        }
    }
}
