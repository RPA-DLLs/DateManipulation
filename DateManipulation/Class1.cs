using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DateManipulation
{
    public class Calculations
    {

            public static string AddDaysToInputDate(string inputdate, int AddDays)
            {

                DateTime datecal = DateTime.Parse(inputdate);
                return datecal.AddDays((double)AddDays).ToShortDateString();
            }

            public static string AddDaysToToday(int aadays)
            {
                DateTime today = DateTime.Today;
                int num = Convert.ToInt32(aadays);
                return today.AddDays((double)num).ToShortDateString();
            }

            public static int DiffeenceBetweenTwoDates(string inputdate, string inputdate2)
            {
                DateTime date1 = DateTime.Parse(inputdate);
                DateTime date2 = DateTime.Parse(inputdate2);

                int diff = date2.Subtract(date1).Days;

                return diff;
            }

            public static int DiffBetweenTodayAndInputDate(string inputdate)
            {
                DateTime date1 = DateTime.Parse(inputdate);
                DateTime today = DateTime.Today;
                int diff = date1.Subtract(today).Days;

                return diff;
            }

            public string AddMinutesToCurrentTime(double addminutes)
            {
                DateTime currenttime = DateTime.Now;

                string outputtime = currenttime.AddMinutes(addminutes).ToString("HH:mm:ss tt");

                return outputtime;
            }

            public string AddSecondsToCurrentTime(double addseconds)
            {
                DateTime currenttime = DateTime.Now;

                string outputtime = currenttime.AddSeconds(addseconds).ToString("HH:mm:ss tt");

                return outputtime;
            }

            public string AddHoursToCurrentTime(double addhours)
            {
                DateTime currenttime = DateTime.Now;

                string outputtime = currenttime.AddHours(addhours).ToString("HH:mm:ss tt");

                return outputtime;
            }

            public string AddHoursToInputTime(string inputtime, double addhours)
            {
                DateTime currenttime = DateTime.Parse(inputtime);

                string outputtime = currenttime.AddHours(addhours).ToString("HH:mm:ss tt");

                return outputtime;
            }

            public string AddMinutesToInputTime(string inputtime, double addminutes)
            {
                DateTime currenttime = DateTime.Parse(inputtime);

                string outputtime = currenttime.AddMinutes(addminutes).ToString("HH:mm:ss tt");

                return outputtime;
            }

            public string AddSecondsToInputTime(string inputtime, double addseconds)
            {
                DateTime currenttime = DateTime.Parse(inputtime);

                string outputtime = currenttime.AddSeconds(addseconds).ToString("HH:mm:ss tt");

                return outputtime;
            }


        }
    }


