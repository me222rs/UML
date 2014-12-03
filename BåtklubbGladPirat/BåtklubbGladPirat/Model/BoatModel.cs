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
        private int high = 9999;
        private int low = 1111;
        MemberModel memberModel;
        MemberRepository memberRepository;

        public BoatModel() 
        {
            memberModel = new MemberModel();
            memberRepository = new MemberRepository();
        }

        public void AddBoat(Member member, BoatTypes type, int length, List<Member> memberList)
        {
            member.Boat.Add(new Boat
            {
                BoatID = memberRepository.createUniqueNumber(low, high),
                Type = type.ToString(),
                Length = length,
            });
        }

        public void RemoveBoat(Member member, Boat boat)
        {   //Tar bort en båt som matchar båtid
            member.Boat.RemoveAll(x => x.BoatID == boat.BoatID);
        }

        public void Editboat(Member member, Boat boat, BoatTypes type, int length)
        {
            member.Boat.RemoveAll(x => x.BoatID == boat.BoatID);

            member.Boat.Add(new Boat
            {
                BoatID = boat.BoatID,
                Type = type.ToString(),
                Length = length,
            });
        }
    }
}
