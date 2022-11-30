namespace ioetNETexercise.Model
{
    //Class that will be used as model to obtain a collection of Shifts as objects
    internal class Shift
    {
        public string day { get; private set; }//2 types: {Working days : "MF"}, {Weekend days : "SS"}
        public int start { get; private set; }//Starting hour of the shift.
        public int end { get; private set; }//Ending hour of the shift.
        public int payHour { get; private set; }//Fee per hour.

        public Shift(string d, int s, int e, int ph)
        {
            day = d;
            start = s;
            end = e;
            payHour = ph;
        }
    }
}
