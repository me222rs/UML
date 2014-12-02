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

        public void SaveMembers(List<Member> members) {
            File.WriteAllText(memberTextFile, String.Empty);
            using (StreamWriter writer = new StreamWriter(memberTextFile, true))
            {
                foreach (Member x in members) {
                    writer.WriteLine(x.MemberID + ";" + x.Name + ";" + x.PersonalNumber + ";");
                }
            }
        }

        public List<Member> getAllMembers() {

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
                });//Lägger till hur många båtar som varje ensklid medlem har.
            }
            memberList.TrimExcess();
            return memberList;//Returnar en lista med medlemmar och hur många båtar de har
        }

        public int createUniqueNumber()
        {
            bool ifNumberExists;
            int UniqueNumber;

            do//Om ett nummer redan finns, ge användaren ett nytt utan att visa några errors
            {
                Random random = new Random();

                UniqueNumber = random.Next(111111, 999999);

                string[] lines = File.ReadAllLines(unikTextFile);
                ifNumberExists = false;

                if (lines.Contains(UniqueNumber.ToString()))
                {
                    ifNumberExists = true;
                    throw new Exception();
                }
            } while (ifNumberExists == true);

            return UniqueNumber;
        }
    }
}
