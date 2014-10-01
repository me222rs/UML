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


namespace BåtklubbGladPirat
{
    class Model
    {
        private string _path;
        public string Path      //Validerar sökvägen så att den inte referarar till null, är tom eller bara innehåller whitespaces
        {
            get { return _path; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Strängen är tom eller innehåller mellanslag!");
                }
                _path = value;
            }
        }

       
        public Model(string path) 
        {
            Path = path;        //initierar fältet _path så att det instansierade objektet innehåller en sökväg
        }

        public void CreateMember(string namn, int personnummer)
        {
            using (StreamWriter writer = new StreamWriter("medlem.txt", true))
            {
                string medlemsnummer = createUniqueNumber();

                using (StreamWriter writer2 = new StreamWriter("UniktNummer.txt", true))
                {
                    writer2.WriteLine(medlemsnummer);
                }

                writer.Write("\n" + medlemsnummer + " " +namn +";" + personnummer  + ";");

            }
        }


        

        private static string createUniqueNumber()      //Fungerar bra
        {
            bool ifNumberExists = false;
            int uniqueNumber;
            string uniqueNumber2 = "";
            Random random = new Random();
            uniqueNumber = random.Next(1, 999999);
            //uniqueNumber = 666;
            uniqueNumber2 = uniqueNumber.ToString();

            string[] lines = File.ReadAllLines("UniktNummer.txt");

            foreach (string r in lines)
            {
                if (r.Equals(uniqueNumber2))
                {
                    ifNumberExists = true;
                    Console.WriteLine("Detta nummer finns redan: " + r);
                }

            }

            if (ifNumberExists == false)
            {
                return uniqueNumber2;
            }
            else
            {
                createUniqueNumber();
                return "fel";
            }



        }

        public List<string> ViewCompactListMembers()        //Fungerar utmärkt
        {
            string[] lines = File.ReadAllLines("medlem.txt");
            List<string>strArr = new List<string>();
            foreach (string r in lines)
            {

                string[] info = r.Split(';');
                //List<string> arrlist = new List<string>(strArr);
                strArr.Add(info[0]);
               
                //Console.WriteLine("{0}", info[0]);
            }

            return strArr;
            
        }

        public List<string> ViewAllMembers()
        {
            string[] lines = File.ReadAllLines("medlem.txt");
            List<string> strArr = new List<string>();
            foreach (string r in lines)
            {

                
                strArr.Add(r);

                //Console.WriteLine("{0}", info[0]);
            }

            return strArr;

        }
    }
}
