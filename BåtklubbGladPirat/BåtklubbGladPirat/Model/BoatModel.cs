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
        //private List<BoatTypes> types = new List<BoatTypes>();
        //public IEnumerable<BoatTypes> GetBoatTypes()
        //{
        //    return types.Cast<BoatTypes>();
        //}

        MemberModel memberModel;
        BoatRepository boatRepository;

        public BoatModel() 
        {
            memberModel = new MemberModel();
            boatRepository = new BoatRepository(memberModel);
        }

        public void AddBoat(int member, BoatTypes type, int length)
        {
            boatRepository.AddBoat(member, type, length);
        }

        public void RemoveBoat(int boat)
        {
            boatRepository.RemoveBoat(boat);
        }

        /*
        *   ANVÄNDS DENNA????
         */
        //public BoatTypes BoatType(int type) 
        //{
        //    switch (type)
        //    {
        //        case 0:
        //            return BoatTypes.Segelbåt;
        //            break;
        //        case 1:
        //           return BoatTypes.Motorseglare;
        //            break;
        //        case 2:
        //            return BoatTypes.Motorbåt;
        //            break;
        //        case 3:
        //            return BoatTypes.Kajak;
        //            break;
        //        default:
        //            return BoatTypes.Övrigt;
        //            break;
        //    }
        //}

        public void Editboat(int boat, BoatTypes type, int length)
        {
            boatRepository.Editboat(boat, type, length);
        }

        public List<string> ViewAllboats()//Visar alla båtar som finns
        {
            return boatRepository.ViewAllboats();
        }
    }
}
