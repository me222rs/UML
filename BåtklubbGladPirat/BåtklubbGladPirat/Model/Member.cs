using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BåtklubbGladPirat.Model
{
    class Member
    {
        private List<Boat> _boat;
        public int MemberID { get; set; }
        public string Name { get; set; }
        public int PersonalNumber { get; set; }
        public List<Boat> Boat 
        {
            get { return _boat; }
            set { _boat = value;}
        }
        

        public Member() 
        {
            _boat = new List<Boat>(100);
        }

        
        public void Addd(Boat nBoat)   
        {
            Boat.Add(nBoat);

        }
    }
}
