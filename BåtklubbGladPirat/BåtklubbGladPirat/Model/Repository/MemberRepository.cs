using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BåtklubbGladPirat.Model.Repository
{
    class MemberRepository : Repository
    {
        private List<string> memberList;
        public void CreateMember(string name, int personNumber)
        {

            using (StreamWriter writer = new StreamWriter(memberTextFile, true))
            {
                string medlemsnummer = createUniqueNumber();

                using (StreamWriter writer2 = new StreamWriter(unikTextFile, true))
                {
                    writer2.WriteLine(medlemsnummer);
                }
                writer.Write(medlemsnummer + " " + name + ";" + personNumber + ";" + "\n");
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
            } while (ifNumberExists == true);

            return ret;
        }

        public List<string> ViewCompactListMembers() //Visar en kompakt lista av medlemmarna och hur många båtar dom har var
        {
            string[] lines = File.ReadAllLines(memberTextFile);
            List<string> strArr = new List<string>();

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
                strArr.Add(info[0] + " " + count);//Lägger till hur många båtar som varje ensklid medlem har.
            }
            return strArr;//Returnar en lista med medlemmar och hur många båtar de har
        }

        public List<string> ViewAllMembers()//Visar alla medlemmar utan båtar
        {
            string[] lines = File.ReadAllLines(memberTextFile);
            List<string> strArr = new List<string>();

            foreach (string memberLine in lines)
            {
                strArr.Add(memberLine);
            }
            return strArr;
        }

        public List<string> ViewCompleteMembers()//Visar medlemmar med deras båtar 
        {
            string[] lines = File.ReadAllLines(memberTextFile);
            List<string> strArr = new List<string>();

            string[] numberOfBoats = File.ReadAllLines(boatTextFile);
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
            memberList = ViewAllMembers();
            memberList.RemoveAt(member);
            var lineCount = File.ReadLines(memberTextFile).Count();

            using (StreamWriter writer = new StreamWriter(memberTextFile))
            {
                for (int i = 0; i < lineCount - 1; i++)
                {
                    writer.WriteLine(memberList[i]);
                }
            }
        }

        public void EditMember(int member, string name, int personalID)
        {
            int memberID = int.Parse(memberList[member].Substring(0, 6));

            DeleteMember(member);

            using (StreamWriter writer = new StreamWriter(memberTextFile, true))
            {
                writer.Write(memberID + " " + name + " ;" + personalID + ";" + "\n");
            }
        }


    }
}
