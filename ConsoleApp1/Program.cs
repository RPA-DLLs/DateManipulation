using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();

            //string result = obj.AddSecondsToinputdate(@"10Aug18", @"DDMMMYY", @"MM/YY/DD");


        }

        public string ChangeDateFormat(string inputdate, string inputformat, string outputformat)
        {
            string outputtime = "";
            string[] arrinputdate = new string[3];
            string[] outformatcheck = null;
            string[] formatcheck = null;
            string delimiter = "";

            if (inputformat.Contains("/"))
            {
                formatcheck = inputformat.Split('/');
                arrinputdate = inputdate.Split('/');

            }
            else if (inputformat.Contains("-"))
            {
                formatcheck = inputformat.Split('-');
                arrinputdate = inputdate.Split('-');

            }
            else if (inputformat.Contains("."))
            {
                formatcheck = inputformat.Split('.');
                arrinputdate = inputdate.Split('.');

            }
            else if (inputformat.Contains(" "))
            {
                formatcheck = inputformat.Split(' ');
                arrinputdate = inputdate.Split(' ');
            }
            else
            {
                formatcheck = inputformat
                    .Aggregate(" ", (seed, next) => seed + (seed.Last() == next ? "" : " ") + next)
                    .Trim()
                    .Split(' ');

                int start = 0;
                int i = 0;
                foreach (var datetype in formatcheck)
                {
                    arrinputdate[i] = inputdate.Substring(start, datetype.Length);
                    start += datetype.Length;
                    i++;
                }
            }

            if (outputformat.Contains("/"))
            {
                outformatcheck = outputformat.Split('/');
                delimiter = "/";
            }
            else if (outputformat.Contains("-"))
            {
                outformatcheck = outputformat.Split('-');
                delimiter = "-";
            }
            else if (outputformat.Contains("."))
            {
                outformatcheck = outputformat.Split('.');
                delimiter = ".";
            }
            else if (outputformat.Contains(" "))
            {
                outformatcheck = outputformat.Split(' ');
                delimiter = " ";
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
                    if (item == "MMM" && formatcheck[x].Contains("MMM") == false || item == "MM" && formatcheck[x].Contains("MMM") == true)
                    {
                        if (formatcheck[x] == "MM")
                        {
                            formatcheck[x] = "MMM";
                            int month = Int32.Parse(arrinputdate[x]);
                            arrinputdate[x] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
                        }
                        else if (formatcheck[x] == "MMM")
                        {
                            formatcheck[x] = "MM";
                            int month = DateTime.ParseExact(arrinputdate[x], "MMM", CultureInfo.CurrentCulture).Month;
                            arrinputdate[x] = month.ToString();
                        }
                    }
                    else if (item == "YYYY" && formatcheck[x].Contains("YYYY") == false || item == "YY" && formatcheck[x].Contains("YYYY") == true)
                    {
                        if (formatcheck[x] == "YY")
                        {
                            formatcheck[x] = "YYYY";
                            int year = Int32.Parse(arrinputdate[x]);
                            int fourDigitYear = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(year);
                            arrinputdate[x] = fourDigitYear.ToString();
                        }
                        else if (formatcheck[x] == "YYYY")
                        {
                            formatcheck[x] = "YY";
                            int year = Int32.Parse(arrinputdate[x]);
                            int TwoDigitsOfYear = year % 100;
                            arrinputdate[x] = TwoDigitsOfYear.ToString();
                        }
                    }
                    if (formatcheck[x] == item)
                    {
                        if (Array.FindIndex(outformatcheck, author => author.Contains(item)) <= 1)
                        {
                            outputtime += arrinputdate[x] + delimiter;
                        }
                        else
                        {
                            outputtime += arrinputdate[x];
                        }
                    }
                }

            }


            return outputtime;
        }

    }
}
