﻿using System;
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

        public void ShowMember(List<Member> compactMemberList, List<Member> viewAllMemberList, List<Boat>viewAllBoats)//Visa enskild medlem 
        {
            List<Boat> strArr = new List<Boat>(100);
            int count = 0;
            foreach (Member line in compactMemberList)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.MemberID, line.Name);
                count++;
            }
            do
            {
                try {

                    Console.Write("Vilken medlem vill du visa?: ");
                    _memberNumber = int.Parse(Console.ReadLine());

                    if (_memberNumber > count - 1)
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
            BoatModel bm = new BoatModel();
            strArr = bm.GetBoatsById(viewAllMemberList[_memberNumber].MemberID);

            Console.Clear();
            Console.WriteLine(viewAllMemberList[_memberNumber].MemberID + " " +viewAllMemberList[_memberNumber].Name + " " + viewAllMemberList[_memberNumber].PersonalNumber);
            foreach(Boat x in strArr){
                Console.WriteLine(x.Type + " " + x.Length);
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
                    _memberNumber = int.Parse(Console.ReadLine());

                    if (_memberNumber > count - 1)
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
            Console.WriteLine(memberList[_memberNumber].Name);

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
                    Console.Write("Nytt personnummer: ");
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
                    _memberNumber = int.Parse(Console.ReadLine());

                    if (_memberNumber > count - 1)
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

        public void ViewCompactListMembers(List<Member> members)
        {
            foreach (Member r in members)
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
                    Console.Write("Felaktig inmatning!");
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
