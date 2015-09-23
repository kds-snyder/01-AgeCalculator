using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get the input birthday 
                Console.Write("What is your birthday? (Enter date in format MM/DD/YYYY): ");             
                DateTime birthday = getInputBirthday();
                //Console.WriteLine("Input birthday: " + birthday);
               
                DateTime todaysDate = DateTime.Now;
                //Console.WriteLine("Todays date: " + todaysDate);             
                
                /* Calculate age in years. 
                   If birthday has already occurred this year:
                        calculate the number of days since the birthday 
                   If birthday has not yet occurred this year:
                        -adjust the age in years
                        -calculate the number of days since the birthday last year
                */          
                int ageYears = todaysDate.Year - birthday.Year;
                int ageDifferenceDays = 0;                
                if (todaysDate.Month > birthday.Month || (todaysDate.Month == birthday.Month && todaysDate.Day >= birthday.Day))
                {
                    DateTime thisYearsBirthday = new DateTime(todaysDate.Year, birthday.Month, birthday.Day);
                    ageDifferenceDays = todaysDate.DayOfYear - thisYearsBirthday.DayOfYear;
                }
                else
                {
                    ageYears--;
                    DateTime lastYearsBirthday = birthday.AddYears(-1);
;                   ageDifferenceDays = 365 - lastYearsBirthday.DayOfYear + todaysDate.DayOfYear;
                }
                // Calculate the weeks and days from the total days
                int ageWeeks = ageDifferenceDays / 7;
                int ageDays = ageDifferenceDays % 7;
                // Console.WriteLine("ageDifferenceDays: " + ageDifferenceDays);

                Console.WriteLine("You are {0} years, {1} weeks, and {2} days old", ageYears, ageWeeks, ageDays);
                         
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        /* Get input birthday and check that it is not in future. Keep prompting 
            until a non-future birthday is entered, then return the birthday
        */
        static DateTime getInputBirthday()
        {
            bool birthdayValid = false;
            DateTime birthdayResult = default(DateTime);
            
            while (!birthdayValid)
            {
                birthdayResult = getInputDateTime();

                // If the input birthday is not in the future, set flag to exit loop, otherwise re-prompt
                //Console.WriteLine("Compare result: " + DateTime.Compare(birthdayResult, DateTime.Now));
                if (DateTime.Compare(birthdayResult, DateTime.Now) <= 0)
                {
                    birthdayValid = true;
                }
                else
                {
                     Console.WriteLine("The birthday cannot be in the future.");
                 }
            }
            return birthdayResult;
        }
        
        static DateTime getInputDateTime()
        {
            bool dateValid = false;
            DateTime dateTimeResult = default(DateTime);
            //string[] formats = { "MM/dd/yyyy" };

            while (!dateValid)
            {
               // try
                //{
                    // Read the input date                   
                    string inputDate = Console.ReadLine();
                    // Console.WriteLine("You entered " + inputDate);

                    // Parse date 
                    dateValid = DateTime.TryParseExact(inputDate, "MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out dateTimeResult);
                    if (!dateValid)
                        {
                            Console.WriteLine("Please enter the date in format MM/DD/YYYY.");
                        }
               

            }
            return dateTimeResult;
           
        }
    }
}
