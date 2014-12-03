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
        enum ReadStatus { Member, Boat }
        private string memberSeperator = "[Member]";
        private string boatSeperator = "[Boat]";

        private List<Member> memberList;

        public void SaveMembers(List<Member> members) {
            File.WriteAllText(memberTextFile, String.Empty);
            using (StreamWriter writer = new StreamWriter(memberTextFile, true))
            {
                foreach (Member m in members) {
                    writer.WriteLine(memberSeperator);
                    writer.WriteLine(m.MemberID + ";" + m.Name + ";" + m.PersonalNumber + ";");
                    writer.WriteLine(boatSeperator);
                    foreach (Boat b in m.Boat)
                    {
                        writer.WriteLine(b.BoatID + ";" + b.Type + ";" + b.Length);
                    }
                }
            }
        }

        public List<Member> getAllMembers() {
            string[] lines = File.ReadAllLines(memberTextFile);
            memberList = new List<Member>(100);
            ReadStatus status = new ReadStatus();
            var m = new Member();
            var b = new Boat();

            foreach (string memberLine in lines)
            {
                
                if(memberLine == memberSeperator)
                {
                    status = ReadStatus.Member;
                }
                else if (memberLine == boatSeperator)
                {
                    status = ReadStatus.Boat;
                }
                else
                {
                    if (status == ReadStatus.Member) 
                    {
                        string[] textSplit = memberLine.Split(';');
                        m = new Member 
                        {
                            MemberID = int.Parse(textSplit[0]),
                            Name = textSplit[1],
                            PersonalNumber = int.Parse(textSplit[2]),
                        };
                        memberList.Add(m);
                    }
                    else if (status == ReadStatus.Boat) 
                    {
                        string[] textSplit = memberLine.Split(';');
                        b = new Boat 
                        {
                            BoatID = int.Parse(textSplit[0]),
                            Type = textSplit[1],
                            Length = int.Parse(textSplit[2]),
                        };
                        memberList.Last().Addd(b);
                    } 
                } 
            }
            memberList.TrimExcess();
            return memberList;//Returnar en lista med medlemmar och hur många båtar de har
        }

        public int createUniqueNumber(int low, int high)
        {
            bool ifNumberExists;
            int UniqueNumber;

            do//Om ett nummer redan finns, ge användaren ett nytt utan att visa några errors
            {
                Random random = new Random();

                UniqueNumber = random.Next(low, high);

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
