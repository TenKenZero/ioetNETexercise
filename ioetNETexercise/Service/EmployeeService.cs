using ioetNETexercise.Model;

namespace ioetNETexercise.Service
{
    public class EmployeeService
    {
        public EmployeeService() { }

        public int CalculateTotalHours(string[] days)
        {//To calculate the employee's total worked hours
            int tHours = 0;
            foreach (string day in days) //Iterating over the worked days
            {
                if (day.Length < 12) { continue; } //Cheks if the string for the day has a correct format
                DateTime start = DateTime.Parse("01/01/1901 " + day.Substring(2, 5) + ":00");
                DateTime end = DateTime.Parse("01/01/1901 " + day.Substring(8, 5) + ":00");
                tHours += end.Hour - start.Hour; //Adds the difference between ending and starting hours
            }
            return tHours;
        }

        public int CalculateTotalPayment(string[] days)
        {//To calculate the employee's total payment
            int total = 0;

            //Initializing the list of shifts
            List<Shift> shifts = new List<Shift>();
            //Three shifts for working days (day = "MF")
            shifts.Add(new Shift("MF", 0, 9, 25));
            shifts.Add(new Shift("MF", 9, 18, 15));
            shifts.Add(new Shift("MF", 18, 24, 20));
            //Three shifts for weekend days (day = "SS")
            shifts.Add(new Shift("SS", 0, 9, 30));
            shifts.Add(new Shift("SS", 9, 18, 20));
            shifts.Add(new Shift("SS", 18, 24, 25));

            foreach (string day in days) //Iterating over the worked days
            {
                if (day.Length < 12) { continue; } //Cheks if the string for the day has a correct format
                List<Shift> Lshifts = new List<Shift>();
                DateTime start = DateTime.Parse("01/01/1901 " + day.Substring(2, 5) + ":00");
                DateTime end = DateTime.Parse("01/01/1901 " + day.Substring(8, 5) + ":00");

                //If the worked day is Saturday or Sunday
                if (day.Substring(0, 2) == "SA" || day.Substring(0, 2) == "SU")
                {
                    Lshifts = shifts.FindAll(x => x.day.Contains("SS")); //We use the Weekend shifts             
                }
                else
                {
                    Lshifts = shifts.FindAll(x => x.day.Contains("MF")); //We use the Working days shifts
                }

                for (int i = 0; i < Lshifts.Count; i++) //Iterating over the selected shifts
                {
                    Shift shift = Lshifts[i];

                    if (start.Hour >= shift.start && start.Hour <= shift.end) //If starts within the shift
                    {
                        if (end.Hour <= shift.end) //If ends within the shift
                        {
                            total += shift.payHour * (end.Hour - start.Hour); //Add (feeHour * worked hours)
                        }
                        else if (i < Lshifts.Count) //If it is the last shift
                        {
                            int firstHours = shift.end - start.Hour;
                            Shift nextShift = Lshifts[i + 1];
                            total += shift.payHour * firstHours; //Add (feeHour * worked hours in first turn)
                            total += nextShift.payHour * (end.Hour - start.Hour - firstHours); //Add (feeHour * worked hours in second turn)
                        }
                    }
                }
            }

            return total;
        }
    }
}
