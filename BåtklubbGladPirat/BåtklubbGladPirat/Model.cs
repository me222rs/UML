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
        private const string memberTextFile = "medlem.txt";
        private const string boatTextFile = "boat.txt";
        private const string unikTextFile = "UniktNummer.txt";

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
            using (StreamWriter writer = new StreamWriter(memberTextFile, true))
            {
                string medlemsnummer = createUniqueNumber();

                using (StreamWriter writer2 = new StreamWriter(unikTextFile, true))
                {
                    writer2.WriteLine(medlemsnummer);
                }
                writer.Write(medlemsnummer + " " + namn + " ;" + personnummer  + ";" + "\n");
            }
        }

        private static string createUniqueNumber()      //Fungerar bra
        {
            bool ifNumberExists;
            string ret = "";

            do//Om ett nummer redan finns, ge han ett nytt utan att visa några errors
            {
                int uniqueNumber;
                Random random = new Random();
                uniqueNumber = random.Next(111111, 999999);
                ret = uniqueNumber.ToString();

                string[] lines = File.ReadAllLines(unikTextFile);
                ifNumberExists = false;
                if (lines.Contains(ret))
                    {
                        ifNumberExists = true;
                    }
            } while(ifNumberExists == true);

            return ret;
        }

        public List<string> ViewCompactListMembers()        //Fungerar utmärkt
        {
            string[] lines = File.ReadAllLines(memberTextFile);
            List<string>strArr = new List<string>();

            string[] numberOfBoats = File.ReadAllLines(boatTextFile);

            foreach (string memberLine in lines)
            {
                int count = 0;
                foreach (string boatLine in numberOfBoats) 
                {
                    if (memberLine.Substring(0, 6) == boatLine.Substring(0, 6))//Kollar om medlemsnummer i en rad är lika med båtars medlemsnummer
                    {
                        count++;
                    }
                }
                string[] info = memberLine.Split(';');
                strArr.Add(info[0] + " " + count + " Båt(ar)");//Lägger till hur många båtar som varje ensklid medlem har.
            }
            return strArr;//Returnar en lista med medlemmar och hur många båtar de har
        }

        public List<string> ViewAllMembers() 
        {
            string[] lines = File.ReadAllLines(memberTextFile);
            List<string> strArr = new List<string>();

            foreach (string memberLine in lines)
            {
                strArr.Add(memberLine);
            }
            return strArr;
        }

        public List<string> ViewCompleteMembers()
        {
            string[] lines = File.ReadAllLines(memberTextFile);
            List<string> strArr = new List<string>();

            string[] numberOfBoats = File.ReadAllLines(boatTextFile);
            List<string> boats = new List<string>();

            foreach (string memberLine in lines)
            {
                foreach (string boatLine in numberOfBoats)
                {
                    if (memberLine.Substring(0, 6) == boatLine.Substring(0, 6))//Om memberID stämmer överens med memberID på en båt. blocka ut båtinfon
                    {
                        string p = boatLine.Substring(7);
                        boats.Add(p);
                    }
                }
                strArr.Add(memberLine);//Lägger till medlem i en lista
                strArr.AddRange(boats);//Lägger till alla båtar som tillhör rätt medlem
                boats.Clear();//rensar båt listan för att kunna återanvända vid nästa medlem
            }
           return strArr;//Returnerar en lista med Medlemmar och deras tillhörande båtar
        }

        public List<string> ViewAllboats()
        {
            string[] numberOfBoats = File.ReadAllLines(boatTextFile);
            List<string> boats = new List<string>();

            foreach (string boatLine in numberOfBoats)
                {
                    boats.Add(boatLine);
                }
            return boats;
        }

        public void DeleteMember(int member, List<string> memberList)//Tar bort medlem beroende på radnummer
        {
            memberList.RemoveAt(member);
            var lineCount = File.ReadLines(memberTextFile).Count();

            using (StreamWriter writer = new StreamWriter(memberTextFile))
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

            using (StreamWriter writer = new StreamWriter(memberTextFile, true))
            {
                writer.Write(memberID + " " + name + " ;" + personalID + ";" + "\n");
            }
        }

        public void AddBoat(int memberID, int type, int length) 
        {
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

    }
}
