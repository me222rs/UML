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
                MemberID = memberRepository.createUniqueNumber(),
                Name = name,
                PersonalNumber = personNumber,
            });
        }

        public void SaveMembers(List<Member> memberList) {
            memberRepository.SaveMembers(memberList);
        }

        public void DeleteMember(Member member, List<Member> memberList, List<Boat> boatList)//Tar bort medlem beroende på radnummer
        {
            memberList.RemoveAll(x => x.MemberID == member.MemberID);
            boatList.RemoveAll(x => x.MemberID == member.MemberID);
           
        }

        public void EditMember(Member member, string name, int personalID, List<Member> memberList)
        {
            memberList.RemoveAll(x => x.MemberID == member.MemberID);
            
            memberList.Add(new Member
            {
                MemberID = member.MemberID,
                Name = name,
                PersonalNumber = personalID,
            });
        }
    }
}