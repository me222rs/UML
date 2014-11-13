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
        //private const string memberTextFile = "medlem.txt";
        //private const string boatTextFile = "boat.txt";

        //public static string[] boatType = new string[] { "Segelbåt", "Motorseglare", "Motorbåt", "Kajak/Kanot", "Övrigt" };

        static void Main(string[] args)
        {
            MenuController mc = new MenuController();
            mc.MenuChoice();
        }


   
    }
}
