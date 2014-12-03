using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BåtklubbGladPirat.Model;

namespace BåtklubbGladPirat.View
{
    class BoatView
    {
        private int _length;
        private Member _member;
        private Boat _boat;
        private BoatTypes selectedBoatType;

        public int getLength()
        {
            return _length;
        }

        public BoatTypes getSelectedBoatType() 
        {
            return selectedBoatType;
        }

        public Member getMember()
        {
            return _member;
        }

        public Boat getBoat()
        {
            return _boat;
        }

        public void EditBoat(List<Member> memberList) //Frågar vilken båt du vill redigera
        {
            int count = 0;
            foreach (Member line in memberList)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.MemberID, line.Name);
                count++;
            }
            Console.Write("Vilken medlem ska ta bort en båt??!?: ");
            _member = memberList[int.Parse(Console.ReadLine())];
            count = 0;
            foreach (Boat line in _member.Boat)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.Type, line.Length); //lägger till radnummer framför
                count++;
            }
            do
            {
                try
                {
                    Console.Write("Vilken båt vill du redigera?: ");
                    _boat = _member.Boat[int.Parse(Console.ReadLine())];

                    if (!_member.Boat.Exists(x => x.BoatID == _boat.BoatID))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }catch {
                    Console.WriteLine("felaktig inmatning!");
                }

            } while (true);
            Console.Clear();
            Console.WriteLine(_boat.Type + " " + _boat.Length);

            Console.WriteLine("Fyll i de nya uppgifterna");

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");

            var values = Enum.GetValues(typeof(BoatTypes));
            foreach (BoatTypes r in values)
            {
                Console.WriteLine("{0}: {1}", countBoatType, r);
                countBoatType++;
            }

            do
            {
                try
                {
                    selectedBoatType = (BoatTypes)int.Parse(Console.ReadLine());
                    if (Convert.ToInt32(selectedBoatType) > Enum.GetNames(typeof(BoatTypes)).Length - 1)
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

            do
            {
                try
                {
                    Console.WriteLine("Ny längd i cm (Max 1000): ");
                    _length = int.Parse(Console.ReadLine());

                    if (_length > 1000)
                    {
                        throw new Exception();
                    }
                    else{
                        break;
                    }
                }
                catch {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);
        }
        //***
        public void RemoveBoat(List<Member> memberList)//Frågar vilken båt man vill ta bort
        {
            int count = 0;
            foreach (Member line in memberList)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.MemberID, line.Name);
                count++;
            }
            Console.Write("Vilken medlem ska ta bort en båt??!?: ");
            _member = memberList[int.Parse(Console.ReadLine())];
            count = 0;
            foreach (Boat line in _member.Boat)
            {
                Console.WriteLine("{0}: {1} {2}", count, line.Type, line.Length); //lägger till radnummer framför
                count++;
            }

            do
            {
                try
                {
                    Console.Write("Vilken båt vill du ta bort?: ");
                    _boat = _member.Boat[int.Parse(Console.ReadLine())];

                    if (!_member.Boat.Exists(x => x.BoatID == _boat.BoatID))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);
        }
        //***
        public void AddBoat(List<Member> memberList)
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
                    Console.Write("Lägga till en båt på vem?: ");
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
                catch
                {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);

            int countBoatType = 0;
            Console.WriteLine("Vilken båttyp: ");
            var values = Enum.GetValues(typeof(BoatTypes));
            foreach (BoatTypes line in values)
            {
                Console.WriteLine("{0}: {1}", countBoatType, line);
                countBoatType++;
            }
            do
            {
                try
                {
                    selectedBoatType = (BoatTypes)int.Parse(Console.ReadLine());
                    if (Convert.ToInt32(selectedBoatType) > Enum.GetNames(typeof(BoatTypes)).Length - 1)
                    {
                        throw new Exception();
                    }
                    else{
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
                    Console.Write("Hur lång är båten i CM? (Max 1000): ");
                    _length = int.Parse(Console.ReadLine());

                    if (_length > 1000)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Felaktig inmatning!");
                }
            } while (true);
        }
    }
}
