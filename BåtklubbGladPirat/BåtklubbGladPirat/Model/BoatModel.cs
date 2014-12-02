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
using BåtklubbGladPirat.Model.Repository;

namespace BåtklubbGladPirat.Model
{
    public enum BoatTypes
    {
        Segelbåt,
        Motorseglare,
        Motorbåt,
        Kajak,
        Övrigt
    };

    class BoatModel
    {
        MemberModel memberModel;
        BoatRepository boatRepository;

        public BoatModel() 
        {
            memberModel = new MemberModel();
            boatRepository = new BoatRepository();
        }

        public void SaveBoats(List<Boat> boatList) 
        {
            boatRepository.SaveBoats(boatList);
        }

        public void AddBoat(Member member, BoatTypes type, int length, List<Boat> boatList)
        {
            boatList.Add(new Boat
            {
                MemberID = member.MemberID,
                BoatID = boatRepository.createBoatUniqueNumber(),
                Type = type.ToString(),
                Length = length,
            });
        }

        public void RemoveBoat(Boat boat, List<Boat> boatList)
        {
            boatList.RemoveAll(x => x.BoatID == boat.BoatID);//Tar bort en båt som matchar båtid
        }

        public void Editboat(Boat boat, BoatTypes type, int length, List<Boat> boatList)
        {
            boatList.RemoveAll(x => x.BoatID == boat.BoatID);

            boatList.Add(new Boat
            {
                MemberID = boat.MemberID,
                Type = type.ToString(),
                Length = length,
                BoatID = boat.BoatID
            });
        }

        public List<Boat> getAllBoats()//Visar alla båtar som finns
        {
            return boatRepository.ViewAllboats();
        }
    }
}
