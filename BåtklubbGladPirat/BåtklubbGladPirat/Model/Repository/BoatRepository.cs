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

        public BoatRepository(MemberModel memberModel)
        {
            this.memberModel = memberModel;
        }

        public void AddBoat(int member, BoatTypes type, int length)
        {
            List<string> memberList = memberModel.ViewCompactListMembers();

            int memberID = int.Parse(memberList[member].Substring(0, 6));
            
            using (StreamWriter writer = new StreamWriter(boatTextFile, true))
            {
                writer.Write(memberID + ";" + type +";" + length + ";" + "\n");
            }
        }

        public void RemoveBoat(int boat)
        {
            List<string> boatList = ViewAllboats();

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

        public List<string> ViewAllboats()//Visar alla båtar som finns
        {
            string[] numberOfBoats = File.ReadAllLines(boatTextFile);
            List<string> boats = new List<string>();

            foreach (string boatLine in numberOfBoats)
            {
                boats.Add(boatLine);
            }
            return boats;
        }

        public void Editboat(int boat, BoatTypes type, int length)
        {
            List<string> boatList = ViewAllboats();

            int memberID = int.Parse(boatList[boat].Substring(0, 6));

            RemoveBoat(boat);

            using (StreamWriter writer = new StreamWriter(boatTextFile, true))
            {
                writer.Write(memberID + ";" + type + ";" + length + ";" + "\n");
            }
        }
    }
}
