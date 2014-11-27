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
        
        MemberRepository memberRepository = new MemberRepository();


        public List<Member> ViewAllMembers() {
            return memberRepository.ViewAllMembers();
        }

        public void CreateMember(string name, int personNumber)
        {
            memberRepository.CreateMember(name, personNumber);
        }

        public List<Unique> createUniqueNumber()
        {
           return memberRepository.createUniqueNumber();
        }

        public List<Member> ViewCompactListMembers() //Visar en kompakt lista av medlemmarna och hur många båtar dom har var
        {
            return memberRepository.ViewCompactListMembers();//Returnar en lista med medlemmar och hur många båtar de har
        }

        public void DeleteMember(int member)//Tar bort medlem beroende på radnummer
        {
            memberRepository.DeleteMember(member);
        }

        public void EditMember(int member, string name, int personalID)
        {
            memberRepository.EditMember(member, name, personalID);
        }
    }
}