using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BåtklubbGladPirat.Model
{
    class BoatModel
    {
        private const string boatTextFile = "boat.txt";
        
        private string _memberPath;
        public string MemberPath      //Validerar sökvägen så att den inte referarar till null, är tom eller bara innehåller whitespaces
        {
            get { return _memberPath; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                _memberPath = value;
            }
        }

        private string _boatPath;
        public string BoatPath      //Validerar sökvägen så att den inte referarar till null, är tom eller bara innehåller whitespaces
        {
            get { return _boatPath; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                _boatPath = value;
            }
        }
        MemberModel memberModel = new MemberModel(_memberPath);

        public BoatModel(string boatPath, string memberPath) 
        {
            MemberPath = memberPath;
            BoatPath = boatPath;//initierar fältet _path så att det instansierade objektet innehåller en sökväg
        }

        public void AddBoat(int member, int type, int length)
        {
            List<string> memberList = memberModel.ViewCompactListMembers();

            int memberID = int.Parse(memberList[member].Substring(0, 6));

            using (StreamWriter writer = new StreamWriter(boatTextFile, true))
            {
                writer.Write(memberID + ";" + BoatType(type) + ";" + length + ";" + "\n");
            }
        }

        public void RemoveBoat(int boat, List<string> boatList)
        {
            boatList.RemoveAt(boat);
            var lineCount = File.ReadLines(boatTextFile).Count();

            using (StreamWriter writer = new StreamWriter(boatTextFile))
            {
                for (int i = 0; i < lineCount - 1; i++)
                {
                    writer.WriteLine(boatList[i]);
                }
            }
        }

        public string BoatType(int type)//Gör om båttypen till en sträng istället för nummer
        {
            string boatType = "";
            switch (type)
            {
                case 0:
                    boatType = "Segelbåt";
                    break;
                case 1:
                    boatType = "Motorseglare";
                    break;
                case 2:
                    boatType = "Motorbåt";
                    break;
                case 3:
                    boatType = "Kajak/Kanot";
                    break;
                case 4:
                    boatType = "Övrigt";
                    break;
            }
            return boatType;
        }

        public void Editboat(int boat, List<string> boatList, int type, int length, int memberID)
        {
            RemoveBoat(boat, boatList);

            using (StreamWriter writer = new StreamWriter(boatTextFile, true))
            {
                writer.Write(memberID + ";" + BoatType(type) + ";" + length + ";" + "\n");
            }
        }

        public List<string> ViewAllboats()//Visar alla båtar som finns
        {
            string[] numberOfBoats = File.ReadAllLines(boatTextFile);
            List<string> boats = new List<string>();

            foreach (string boatLine in numberOfBoats)
            {
                boats.Add(boatLine);
            }
            return boats;
        }
    }
}
