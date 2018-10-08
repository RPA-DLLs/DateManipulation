using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();

            string result = obj.AddSecondsToInputTime(@"10/8/2018", @"MM/DD/YYYY", @"DD/MM/YY");


        }

        public string AddSecondsToInputTime(string inputtime, string inputformat, string outputformat)
        {
            string outputtime = "";
            string[] arrinputtime = null;
            string[] outformatcheck = null;
            string[] formatcheck = null;
            string delimiter = "";

            if (inputformat.Contains("/"))
            {
                formatcheck = inputformat.Split('/');
                arrinputtime = inputtime.Split('/');
                delimiter = "/";


            }
            else if (inputformat.Contains("-"))
            {
                formatcheck = inputformat.Split('-');
                arrinputtime = inputtime.Split('-');
                delimiter = "-";

            }
            else if (inputformat.Contains("."))
            {
                formatcheck = inputformat.Split('.');
                arrinputtime = inputtime.Split('.');
                delimiter = ".";

            }
            else
            {
                formatcheck = inputformat
                    .Aggregate(" ", (seed, next) => seed + (seed.Last() == next ? "" : " ") + next)
                    .Trim()
                    .Split(' ');

                arrinputtime = inputtime
                    .Aggregate(" ", (seed, next) => seed + (seed.Last() == next ? "" : " ") + next)
                    .Trim()
                    .Split(' ');

            }

            if (outputformat.Contains("/"))
            {
                outformatcheck = outputformat.Split('/');
            }
            else if (outputformat.Contains("-"))
            {
                outformatcheck = outputformat.Split('-');
            }
            else if (outputformat.Contains("."))
            {
                outformatcheck = outputformat.Split('.');
            }
            else
            {
                outformatcheck = outputformat
                    .Aggregate(" ", (seed, next) => seed + (seed.Last() == next ? "" : " ") + next)
                    .Trim()
                    .Split(' ');
            }


            foreach (var item in outformatcheck)
            {
                for (int x = 0; x <= 2; x++)
                {
                    if (formatcheck[x] == item)
                    {

                            outputtime += arrinputtime[x] + delimiter;
                      
                    }
                }

            }


            return outputtime;
        }

    }
}
