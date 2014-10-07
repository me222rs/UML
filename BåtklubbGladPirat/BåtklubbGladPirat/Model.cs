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


namespace BåtklubbGladPirat
{
    class Model
    {
        private string _path;
        public string Path      //Validerar sökvägen så att den inte referarar till null, är tom eller bara innehåller whitespaces
        {
            get { return _path; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Strängen är tom eller innehåller mellanslag!");
                }
                _path = value;
            }
        }

       
        public Model(string path) 
        {
            Path = path;        //initierar fältet _path så att det instansierade objektet innehåller en sökväg
        }

        public void CreateMember(string namn, int personnummer)
        {
            using (StreamWriter writer = new StreamWriter("medlem.txt", true))
            {
                string medlemsnummer = createUniqueNumber();

                using (StreamWriter writer2 = new StreamWriter("UniktNummer.txt", true))
                {
                    writer2.WriteLine(medlemsnummer);
                }

                writer.Write(medlemsnummer + " " +namn + " " +";" + personnummer  + ";" + "\n");

            }
        }


        

        private static string createUniqueNumber()      //Fungerar bra
        {
            bool ifNumberExists = false;
            int uniqueNumber;
            string uniqueNumber2 = "";
            Random random = new Random();
            uniqueNumber = random.Next(99999, 999999);
            //uniqueNumber = 666;
            uniqueNumber2 = uniqueNumber.ToString();

            string[] lines = File.ReadAllLines("UniktNummer.txt");

            foreach (string r in lines)
            {
                if (r.Equals(uniqueNumber2))
                {
                    ifNumberExists = true;
                    Console.WriteLine("Detta nummer finns redan: " + r);
                }

            }

            if (ifNumberExists == false)
            {
                return uniqueNumber2;
            }
            else
            {
                createUniqueNumber();
                return "fel";
            }



        }

        public List<string> ViewCompactListMembers()        //Fungerar utmärkt
        {
            string[] lines = File.ReadAllLines("medlem.txt");
            List<string>strArr = new List<string>();

            string[] numberOfBoats = File.ReadAllLines("boat.txt");
            
            foreach (string r in lines)
            {
                int count = 0;
                foreach (string n in numberOfBoats) 
                {
                    if (r.Substring(0, 6) == n.Substring(0, 6))//Kollar om medlemsnummer i en rad är lika med båtars medlemsnummer
                    {
                        count++;
                    }
                }
                string[] info = r.Split(';');
                strArr.Add(info[0] + " " + count + " Båt(ar)");
            }
            return strArr;
        }

        public List<string> ViewAllMembers() 
        {
            string[] lines = File.ReadAllLines("medlem.txt");
            List<string> strArr = new List<string>();

            foreach (string r in lines)
            {
                strArr.Add(r);
            }
            return strArr;
        }

        public List<string> ViewCompleteMembers()
        {
            string[] lines = File.ReadAllLines("medlem.txt");
            List<string> strArr = new List<string>();

            string[] numberOfBoats = File.ReadAllLines("boat.txt");
            List<string> boats = new List<string>();

            foreach (string r in lines)
            {
                foreach (string n in numberOfBoats)
                {
                    if (r.Substring(0, 6) == n.Substring(0, 6))
                    {
                       string p = n.Substring(7);
                        boats.Add(p);
                    }
                }
                strArr.Add(r);
                strArr.AddRange(boats);
                boats.Clear();
                //Console.WriteLine("{0}", info[0]);
            }
           return strArr;
        }

        public List<string> ViewAllboats()
        {
            string[] numberOfBoats = File.ReadAllLines("boat.txt");
            List<string> boats = new List<string>();

                foreach (string n in numberOfBoats)
                {
                    boats.Add(n);
                }
            return boats;
        }

        public void DeleteMember(int member, List<string> memberList)//Tar bort medlem beroende på radnummer
        {
            memberList.RemoveAt(member);
            var lineCount = File.ReadLines("medlem.txt").Count();

            using (StreamWriter writer = new StreamWriter("medlem.txt"))
            {
                for (int i = 0; i < lineCount -1; i++)
                {
                    writer.WriteLine(memberList[i]);
                }
            }
        }

        public void EditMember(int member, List<string> memberList, string name, int personalID, int memberID) 
        {
            DeleteMember(member, memberList);

            using (StreamWriter writer = new StreamWriter("medlem.txt", true))
            {

                writer.Write(memberID + " " + name + ";" + personalID + ";" + "\n");

            }
        }

        public void AddBoat(int memberID, int type, int length) 
        {
            string boatType = BoatType(type);

            using (StreamWriter writer = new StreamWriter("boat.txt", true))
            {
                writer.Write(memberID + ";" + boatType + ";" + length + ";" + "\n");
            }
        }

        public void RemoveBoat(int boat, List<string> boatList) 
        {
            boatList.RemoveAt(boat);
            var lineCount = File.ReadLines("boat.txt").Count();

            using (StreamWriter writer = new StreamWriter("boat.txt"))
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
            string boatType = BoatType(type);

            using (StreamWriter writer = new StreamWriter("boat.txt", true))
            {

                writer.Write(memberID + ";" + boatType + ";" + length + ";" + "\n");

            }
        }
    }
}
