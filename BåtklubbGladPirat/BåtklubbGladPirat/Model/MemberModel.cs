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
    class MemberModel
    {
        private const string unikTextFile = "UniktNummer.txt";
       
        private List<string> memberList;

        private const string _memberPath = "./medlem.txt";
        public string getMemberTextFile {
            get { return _memberPath; }
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

       
        public MemberModel() 
        {
            
            memberList = ViewAllMembers();
        }

        public void setBoatTextfile(string boatPath)
        {
            BoatPath = boatPath;
        }

        public void CreateMember(string name, int personNumber)
        {

            using (StreamWriter writer = new StreamWriter(_memberPath, true))
            {
                string medlemsnummer = createUniqueNumber();

                using (StreamWriter writer2 = new StreamWriter(unikTextFile, true))
                {
                    writer2.WriteLine(medlemsnummer);
                }
                writer.Write(medlemsnummer + " " + name + " ;" + personNumber  + ";" + "\n");
            }
        }

        public string createUniqueNumber() 
        {
            bool ifNumberExists;
            string ret = "";

            do//Om ett nummer redan finns, ge användaren ett nytt utan att visa några errors
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

        public List<string> ViewCompactListMembers() //Visar en kompakt lista av medlemmarna och hur många båtar dom har var
        {
            string[] lines = File.ReadAllLines(_memberPath);
            List<string>strArr = new List<string>();

            string[] numberOfBoats = File.ReadAllLines(_boatPath);

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

        public List<string> ViewAllMembers()//Visar alla medlemmar utan båtar
        {
            string[] lines = File.ReadAllLines(_memberPath);
            List<string> strArr = new List<string>();

            foreach (string memberLine in lines)
            {
                strArr.Add(memberLine);
            }
            return strArr;
        }

        public List<string> ViewCompleteMembers()//Visar medlemmar med deras båtar 
        {
            string[] lines = File.ReadAllLines(_memberPath);
            List<string> strArr = new List<string>();

            string[] numberOfBoats = File.ReadAllLines(_boatPath);
            List<string> boats = new List<string>();

            foreach (string memberLine in lines)//Loopar medlemmar
            {
                foreach (string boatLine in numberOfBoats)//Loopar båtarna och matchar dom med medlemmarna som äger båten
                {
                    if (memberLine.Substring(0, 6) == boatLine.Substring(0, 6))//Om memberID stämmer överens med memberID på en båt, plocka ut båtinfo
                    {
                        string p = boatLine.Substring(7);//Visar båtar utan medlemsnummer 
                        boats.Add(p);//Lägger till båtar i en lista 
                    }
                }
                strArr.Add(memberLine);//Lägger till medlem i en lista
                strArr.AddRange(boats);//Lägger till alla båtar som tillhör rätt medlem
                boats.Clear();//rensar båt listan för att kunna återanvända vid nästa medlem
            }
           return strArr;//Returnerar en lista med Medlemmar och deras tillhörande båtar
        }

        public void DeleteMember(int member)//Tar bort medlem beroende på radnummer
        {
            memberList.RemoveAt(member);
            var lineCount = File.ReadLines(_memberPath).Count();

            using (StreamWriter writer = new StreamWriter(_memberPath))
            {
                for (int i = 0; i < lineCount -1; i++)
                {
                    writer.WriteLine(memberList[i]);
                }
            }
        }

        public void EditMember(int member, string name, int personalID) 
        {
            int memberID = int.Parse(memberList[member].Substring(0, 6));
            
            DeleteMember(member);
                      
            using (StreamWriter writer = new StreamWriter(_memberPath, true))
            {
                writer.Write(memberID + " " + name + " ;" + personalID + ";" + "\n");
            }
        }
    }
}
