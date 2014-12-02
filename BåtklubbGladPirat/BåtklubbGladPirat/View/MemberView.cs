using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BåtklubbGladPirat.Model;
using BåtklubbGladPirat.Model.Repository;

namespace BåtklubbGladPirat.View
{
    class MemberView
    {
        private string _fName;
        private int _personId;
        private Member _member;

        public string getFName() 
        {
            return _fName;
        }

        public int getPersonId() 
        {
            return _personId;
        }

        public Member getMember()
        {
            return _member;
        }

        public void ShowMember(List<Member> memberList, List<Boat>boatList)//Visa enskild medlem 
        {
            List<Boat> strArr = new List<Boat>(100);
            int count = 0;
            foreach (Member line in memberList)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.MemberID, line.Name);
                count++;
            }
            do
            {
                try {

                    Console.Write("Vilken medlem vill du visa?: ");
                    _member = memberList[int.Parse(Console.ReadLine())];

                    if (!memberList.Exists(x => x.MemberID == _member.MemberID))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }catch {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);

            if (boatList.Exists(x => x.MemberID == _member.MemberID))//Om man har båtar, lägg dom i en lista 
            {
                foreach(Boat x in boatList)
                {
                    if (x.MemberID == _member.MemberID)
                    {
                        strArr.Add(new Boat
                        {
                            Type = x.Type,
                            Length = x.Length,
                            BoatID = x.BoatID,
                        });
                    }
               }
            }

            Console.Clear();
            Console.WriteLine(_member.MemberID + " " + _member.Name + " " + _member.PersonalNumber);

            foreach(Boat x in strArr){
                Console.WriteLine(x.Type + " " + x.Length + " " + x.BoatID);
            }
        }

        public void EditMember(List<Member> memberList) //Frågar vilken medlem du vill redigera
        {
            int count = 0;
            foreach (Member line in memberList)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.MemberID, line.Name);
                count++;
            }
            do
            {
                try
                {
                    Console.Write("Vilken medlem vill du redigera?: ");
                    _member = memberList[int.Parse(Console.ReadLine())];

                    if (!memberList.Exists(x => x.MemberID == _member.MemberID))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }
                catch {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);
            Console.Clear();
            Console.WriteLine(_member.Name);

            Console.WriteLine("Fyll i de nya uppgifterna");
            do
            {
                try
                {

                    Console.Write("Nytt namn: ");
                    _fName = Console.ReadLine();
                    if (_fName == "" || _fName == null || _fName.Length > 40)
                    {
                        throw new Exception();
                    }
                    else {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);

            do
            {
                try
                {
                    Console.Write("Nytt personnummer<8 nummer>: ");
                    _personId = int.Parse(Console.ReadLine());

                    if (Math.Ceiling(Math.Log10(_personId)) != 8)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }
                catch {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);
        }
        //***
        public void DeleteMember(List<Member> memberList)//Frågar vilken medlem man vill ta bort
        {
            int count = 0;
            foreach (Member line in memberList)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.MemberID, line.Name); //lägger till radnummer framför
                count++;
            }

            do
            {
                try
                {
                    Console.Write("Vilken medlem vill du ta bort?: ");
                    _member = memberList[int.Parse(Console.ReadLine())];

                    if (!memberList.Exists(x => x.MemberID == _member.MemberID))
                    {
                        throw new Exception();
                    }
                    else{
                        break;
                    }

                }catch {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);
        }

        public void ViewCompactListMembers(List<Member> memberList)
        {
            foreach (Member r in memberList)
            {
                Console.WriteLine(r.MemberID + " " + r.Name + " " + r.NumberOfBoats + " Båt(ar)");
            }
        }

        public void ViewAllMembers(List<Member>members)//visar alla medlemmar med deras båtar
        {
            Console.WriteLine("{0, 10}"+ "{1, 10}" + "{2, 20}" ,"ID", "Namn", "Personnummer");
            foreach (Member line in members)
            {
                Console.WriteLine("{0, 10}"+"{1, 10}"+"{2, 20}", line.MemberID,line.Name,line.PersonalNumber);
            }
        }

        public void CreateMember()
        {
            do{
                try
                {
                    Console.Write("Förnamn: ");
                    _fName = Console.ReadLine();

                    if (_fName == "" || _fName == null || _fName.Length > 40)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }catch {
                    Console.WriteLine("Felaktig inmatning!");
                }
            }while(true);

            do
            {
                try
                {
                    Console.Write("Personnummer(yyyymmdd): ");
                    _personId = int.Parse(Console.ReadLine());

                    if (Math.Ceiling(Math.Log10(_personId)) != 8)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }
                catch {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);
        }
    }
}
