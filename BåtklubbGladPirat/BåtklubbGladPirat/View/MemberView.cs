using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BåtklubbGladPirat.Model;

namespace BåtklubbGladPirat.View
{
    class MemberView
    {
        private string _fName;
        private int _personId;
        private int _memberNumber;

        public string getFName() 
        {
            return _fName;
        }

        public int getPersonId() 
        {
            return _personId;
        }

        public int getMemberNumber() 
        {
            return _memberNumber;
        }

        public void ShowMember(List<string> compactMemberList, List<string> viewAllMemberList)//Visa enskild medlem 
        {
            int count = 0;
            foreach (string line in compactMemberList)
            {
                Console.WriteLine("{0}: {1}", count, line);
                count++;
            }

            Console.Write("Vilken medlem vill du visa?: ");
            _memberNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine(viewAllMemberList[_memberNumber]);
        }

        public void EditMember(List<string> memberList) //Frågar vilken medlem du vill redigera
        {
            int count = 0;
            foreach (string line in memberList)
            {
                Console.WriteLine("{0}: {1}", count, line);
                count++;
            }

            Console.Write("Vilken medlem vill du redigera?: ");
            _memberNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine(memberList[_memberNumber]);

            Console.WriteLine("Fyll i de nya uppgifterna");

            Console.Write("Nytt namn: ");
            _fName = Console.ReadLine();

            Console.Write("Nytt personnummer: ");
            _personId = int.Parse(Console.ReadLine());
        }
        //***
        public void DeleteMember(List<string> memberList)//Frågar vilken medlem man vill ta bort
        {
            int count = 0;
            foreach (string line in memberList)
            {
                Console.WriteLine("{0}: {1}", count, line); //lägger till radnummer framför
                count++;
            }

            Console.Write("Vilken medlem vill du ta bort?: ");
            _memberNumber = int.Parse(Console.ReadLine());
        }

        public void ViewCompactListMembers(List<string> members)
        {
            foreach (string r in members)
            {
                Console.WriteLine(r);
            }
        }

        public void ViewAllMembers(List<string> members)//visar alla medlemmar med deras båtar
        {
            foreach (string line in members)
            {
                Console.WriteLine(line);
            }
        }

        public void CreateMember()
        {
            Console.Write("Förnamn: ");
            _fName = Console.ReadLine();

            if (_fName == "" || _fName == null)
            {
                throw new Exception();
            }

            Console.Write("Personnummer(yyyymmdd): ");
            _personId = int.Parse(Console.ReadLine());
            double numberOfDigits = Math.Floor(Math.Log10(_personId) + 1);
            if (numberOfDigits != 8)
            {
                throw new Exception();
            }
        }
    }
}
