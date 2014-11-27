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
            boatRepository = new BoatRepository(memberModel);
        }


        public List<Boat> GetBoatsById(int memberID) {
            return boatRepository.GetBoatsById(memberID);
        }

        public void AddBoat(int member, BoatTypes type, int length)
        {
            boatRepository.AddBoat(member, type, length);
        }

        public void RemoveBoat(int boat)
        {
            boatRepository.RemoveBoat(boat);
        }

        public void Editboat(int boat, BoatTypes type, int length)
        {
            boatRepository.Editboat(boat, type, length);
        }

        public List<Boat> ViewAllboats()//Visar alla båtar som finns
        {
            return boatRepository.ViewAllboats();
        }
    }
}
