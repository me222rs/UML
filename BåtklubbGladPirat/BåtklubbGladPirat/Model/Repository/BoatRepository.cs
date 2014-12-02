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
        private List<Boat> boatList;

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
    }
}
