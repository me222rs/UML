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
        MemberModel memberModel;

        public static string[] m_boatType = new string[] { "Segelbåt", "Motorseglare", "Motorbåt", "Kajak/Kanot", "Övrigt" };

        private string _boatPath = "./boat.txt";
        public string getBoatTextFile {
            get { return _boatPath; }
        }

        public string[] getTypes { 
            get{
                return m_boatType;
            }
            
        }

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


        public BoatModel() 
        {
            memberModel = new MemberModel();
        }

        public void SetMemberTextfile(string memberPath)
        {
            MemberPath = memberPath;
        }

        public void AddBoat(int member, int type, int length)
        {
            List<string> memberList = memberModel.ViewCompactListMembers();

            int memberID = int.Parse(memberList[member].Substring(0, 6));

            using (StreamWriter writer = new StreamWriter(_boatPath, true))
            {
                writer.Write(memberID + ";" + BoatType(type) + ";" + length + ";" + "\n");
            }
        }

        public void RemoveBoat(int boat)
        {
            List<string> boatList = ViewAllboats();

            boatList.RemoveAt(boat);
            var lineCount = File.ReadLines(_boatPath).Count();

            using (StreamWriter writer = new StreamWriter(_boatPath))
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
                    boatType = getTypes[0];
                    break;
                case 1:
                    boatType = getTypes[1];
                    break;
                case 2:
                    boatType = getTypes[2];
                    break;
                case 3:
                    boatType = getTypes[3];
                    break;
                case 4:
                    boatType = getTypes[4];
                    break;
            }
            return boatType;
        }

        public void Editboat(int boat, int type, int length)
        {
            List<string> boatList = ViewAllboats();

            int memberID = int.Parse(boatList[boat].Substring(0, 6));

            RemoveBoat(boat);

            using (StreamWriter writer = new StreamWriter(_boatPath, true))
            {
                writer.Write(memberID + ";" + BoatType(type) + ";" + length + ";" + "\n");
            }
        }

        public List<string> ViewAllboats()//Visar alla båtar som finns
        {
            string[] numberOfBoats = File.ReadAllLines(_boatPath);
            List<string> boats = new List<string>();

            foreach (string boatLine in numberOfBoats)
            {
                boats.Add(boatLine);
            }
            return boats;
        }
    }
}
