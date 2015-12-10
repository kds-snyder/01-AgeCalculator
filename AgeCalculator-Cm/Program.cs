using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeCalculator_Cm
{
    class Program
    {
        // Take a message that will be displayed to the user
        // Return a DateTime variable
        static DateTime getInputDate(string message)
        {
            while (true)
            {
                try {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    DateTime returnDate = DateTime.Parse(input);
                    return returnDate;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid date");
                }
                
            }
            
        }
        static DateTime calculateDifference(DateTime a, DateTime b)
        {
            TimeSpan span = a - b;
            DateTime beginningOfTime = DateTime.MinValue;
            DateTime differenceAsDate = beginningOfTime + span;
           
            return differenceAsDate;
        }

        static void displayDate(DateTime date)
        {
            // Decrement values as beginning of time starts at 1 instead of 0
            Console.WriteLine("Years: {0}, months: {1}, days: {2}", date.Year-1, date.Month - 1, date.Day - 1);
                       
        }
        
        static void Main(string[] args)
        {
            DateTime birthDate = getInputDate("What is your date of birth?");

            DateTime diffAsDate = calculateDifference(DateTime.Now, birthDate);

            displayDate(diffAsDate);

            Console.ReadLine();
        }
    }
}
