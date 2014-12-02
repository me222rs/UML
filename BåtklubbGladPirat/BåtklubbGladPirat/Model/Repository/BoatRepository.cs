using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BåtklubbGladPirat.Model;

namespace BåtklubbGladPirat.Model.Repository
{
    class BoatRepository : Repository
    {
        private MemberModel memberModel;
        private List<Boat> boatList;

        public BoatRepository(MemberModel memberModel)
        {
            this.memberModel = memberModel;
        }

        public void SaveBoats(List<Boat> boats)
        {
            File.WriteAllText(boatTextFile, String.Empty);
            using (StreamWriter writer = new StreamWriter(boatTextFile, true))
            {
                foreach (Boat x in boats)
                {
                    writer.WriteLine(x.MemberID + ";" + x.Type + ";" + x.Length + ";" + x.BoatID + ";");
                }

            }
        }

        //public void AddBoat(int member, BoatTypes type, int length)
        //{
        //    List<Member> memberList = memberModel.ViewCompactListMembers();

        //    int memberID = memberList[member].MemberID;

        //    using (StreamWriter writer = new StreamWriter(boatTextFile, true))
        //    {
        //        writer.Write(memberID + ";" + type + ";" + length + ";" + "\n");
        //    }
        //}

        //public void RemoveBoat(int boat)
        //{
        //    List<Boat> boatList = ViewAllboats();

        //    boatList.RemoveAt(boat);
        //    var lineCount = File.ReadLines(boatTextFile).Count();

        //    using (StreamWriter writer = new StreamWriter(boatTextFile))
        //    {
        //        for (int i = 0; i < lineCount - 1; i++)
        //        {
        //            writer.WriteLine(boatList[i].MemberID + ";" + boatList[i].Type + ";" + boatList[i].Length + ";");
        //        }
        //    }
        //}

        public int createBoatUniqueNumber()
        {
            bool ifNumberExists;
            int UniqueNumber;

            do//Om ett nummer redan finns, ge användaren ett nytt utan att visa några errors
            {
                Random random = new Random();

                UniqueNumber = random.Next(1111, 9999);

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

        //Hämtar ut alla båtar
        public List<Boat> ViewAllboats()//Visar alla båtar som finns
        {
             string[] numberOfBoats = File.ReadAllLines(boatTextFile);
             boatList = new List<Boat>(100);

            foreach (string boatLine in numberOfBoats)
            {
                string[] boat = boatLine.Split(';');
                boatList.Add(new Boat
                {
                    MemberID = int.Parse(boat[0]),
                    Type = boat[1],
                    Length = int.Parse(boat[2]),
                    BoatID = int.Parse(boat[3]),
                });
            }
            boatList.TrimExcess();
            return boatList;
        }

        //Hämtar ut båtar som tillhör en medlem
        public List<Boat> GetBoatsById(int memberID)
        {
           string[] numberOfBoats = File.ReadAllLines(boatTextFile);

            boatList = new List<Boat>(100);
            foreach (string x in numberOfBoats)
            {
                string[] boat = x.Split(';');
                if(memberID == int.Parse(boat[0])){
                
                
                boatList.Add(new Boat
                {
                    MemberID = int.Parse(boat[0]),
                    Type = boat[1],
                    Length = int.Parse(boat[2]),
                });
                }
            }
            boatList.TrimExcess();
            return boatList;
        }

        public void Editboat(int boat, BoatTypes type, int length)
        {
            List<Boat> boatList = ViewAllboats();

            int memberID = boatList[boat].MemberID;

            //RemoveBoat(boat);

            using (StreamWriter writer = new StreamWriter(boatTextFile, true))
            {
                writer.Write(memberID + ";" + type + ";" + length + ";" + "\n");
            }
        }
    }
}
