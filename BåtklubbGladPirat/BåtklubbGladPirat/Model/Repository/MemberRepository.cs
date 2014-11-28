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
        private List<Member> memberList;
        private List<Unique> uniqueNumberList;

        public void CreateMember(string name, int personNumber)
        {
            using (StreamWriter writer = new StreamWriter(memberTextFile, true))
            {
                List<Unique> medlemsnummer = createUniqueNumber();

                using (StreamWriter writer2 = new StreamWriter(unikTextFile, true))
                {
                    writer2.WriteLine(medlemsnummer[0].UniqueNumber);
                }
                writer.Write(medlemsnummer[0].UniqueNumber + ";" + name + ";" + personNumber + ";" + "\n");
            }
        }

        public List<Unique> createUniqueNumber()
        {
            uniqueNumberList = new List<Unique>(100);
            bool ifNumberExists;

            do//Om ett nummer redan finns, ge användaren ett nytt utan att visa några errors
            {
                Random random = new Random();
                uniqueNumberList.Add(new Unique
                {
                    UniqueNumber = random.Next(111111, 999999),
                });

                string[] lines = File.ReadAllLines(unikTextFile);
                ifNumberExists = false;

                    if (lines.Contains(uniqueNumberList[0].UniqueNumber.ToString()))
                    {
                        ifNumberExists = true;
                        throw new Exception();
                    }
            } while (ifNumberExists == true);

            return uniqueNumberList;
        }

        public List<Member> ViewCompactListMembers() //Visar en kompakt lista av medlemmarna och hur många båtar dom har var
        {
            string[] lines = File.ReadAllLines(memberTextFile);
            string[] numberOfBoats = File.ReadAllLines(boatTextFile);
            memberList = new List<Member>(100);
            Member member = new Member();

            foreach (string memberLine in lines)
            {
                string[] memberId = memberLine.Split(';');
                int count = 0;
                foreach (string boatLine in numberOfBoats)
                {
                    string[] boatId = boatLine.Split(';');
                    if (memberId[0] == boatId[0])//Kollar om medlemsnummer i en rad är lika med båtars medlemsnummer
                    {
                        count++;
                    }
                }
                memberList.Add(new Member
                {
                    MemberID = int.Parse(memberId[0]),
                    Name = memberId[1],
                    PersonalNumber = int.Parse(memberId[2]),
                    NumberOfBoats = count,
                });
                //Lägger till hur många båtar som varje ensklid medlem har.
            }
            return memberList;//Returnar en lista med medlemmar och hur många båtar de har
        }




        public void DeleteMember(int member)//Tar bort medlem beroende på radnummer
        {
            memberList = ViewCompactListMembers();
            memberList.RemoveAt(member);
            var lineCount = File.ReadLines(memberTextFile).Count();

            using (StreamWriter writer = new StreamWriter(memberTextFile))
            {
                for (int i = 0; i < lineCount - 1; i++)
                {
                    writer.WriteLine(memberList[i].MemberID + ";" + memberList[i].Name + ";" + memberList[i].PersonalNumber + ";");
                }
            }
        }

        public void EditMember(int member, string name, int personalID)
        {
            memberList = ViewCompactListMembers();
            int memberID = memberList[member].MemberID;

            DeleteMember(member);

            using (StreamWriter writer = new StreamWriter(memberTextFile, true))
            {
                writer.WriteLine(memberID + ";" + name + ";" + personalID + ";");
            }
        }
    }
}
