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
    class MemberModel
    {
        MemberRepository memberRepository;
        private int high = 999999;
        private int low = 111111;

        public MemberModel() 
        {
            memberRepository = new MemberRepository();
        }


        public List<Member> getAllMembers() {
            return memberRepository.getAllMembers();
        }

        public void CreateMember(string name, int personNumber, List<Member> memberList)
        {
            memberList.Add(new Member
            {
                MemberID = memberRepository.createUniqueNumber(low, high, memberList),
                Name = name,
                PersonalNumber = personNumber,
            });
        }

        public void SaveMembers(List<Member> memberList) {
            memberRepository.SaveMembers(memberList);
        }

        public void DeleteMember(Member member, List<Member> memberList)//Tar bort medlem beroende på radnummer
        {
            memberList.RemoveAll(x => x.MemberID == member.MemberID);
        }

        public void EditMember(Member member, string name, int personalID, List<Member> memberList)
        {
            memberList.RemoveAll(x => x.MemberID == member.MemberID);
            List<Boat> boatlist = new List<Boat>(100);
            foreach (Boat b in member.Boat)
            {
                boatlist.Add(new Boat 
                {
                    BoatID = b.BoatID,
                    Type = b.Type,
                    Length = b.Length,
                });
            }
            memberList.Add(new Member
            {
                MemberID = member.MemberID,
                Name = name,
                PersonalNumber = personalID,
                Boat = boatlist,                
            });
        }
    }
}