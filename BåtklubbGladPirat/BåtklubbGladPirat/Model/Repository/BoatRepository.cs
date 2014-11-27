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

        public void AddBoat(int member, BoatTypes type, int length)
        {
            List<Member> memberList = memberModel.ViewCompactListMembers();

            int memberID = memberList[member].MemberID;

            using (StreamWriter writer = new StreamWriter(boatTextFile, true))
            {
                writer.Write(memberID + ";" + type + ";" + length + ";" + "\n");
            }
        }

        public void RemoveBoat(int boat)
        {
            List<Boat> boatList = ViewAllboats();

            boatList.RemoveAt(boat);
            var lineCount = File.ReadLines(boatTextFile).Count();

            using (StreamWriter writer = new StreamWriter(boatTextFile))
            {
                for (int i = 0; i < lineCount - 1; i++)
                {
                    writer.WriteLine(boatList[i].MemberID + ";" + boatList[i].Type + ";" + boatList[i].Length + ";");
                    //writer.WriteLine(boatList[i]);
                }
            }
        }

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
                });
            }
            return boatList;
        }


        public List<Boat> GetBoatsById(int memberID)
        {

            //int count = 0;
           string[] numberOfBoats = File.ReadAllLines(boatTextFile);

            //List<Boat> boatList2 = new List<Boat>(100);
            boatList = new List<Boat>(100);
            //boatList = ViewAllboats();
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
                //count++;
            }
            
            


            return boatList;
        }

        public void Editboat(int boat, BoatTypes type, int length)
        {
            List<Boat> boatList = ViewAllboats();

            int memberID = boatList[boat].MemberID;

            RemoveBoat(boat);

            using (StreamWriter writer = new StreamWriter(boatTextFile, true))
            {
                writer.Write(memberID + ";" + type + ";" + length + ";" + "\n");
            }
        }
    }
}
