using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BåtklubbGladPirat.Controller;

namespace BåtklubbGladPirat
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuController mc = new MenuController();
            mc.MenuChoice();
        }
    }
}
