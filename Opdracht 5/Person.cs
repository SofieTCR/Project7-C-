namespace Hospital
{
    public abstract class Person
    {
        public string Name { get; protected set; }

        public Person(string pName)
        {
            Name = pName;
        }
    }

    public class Patient : Person
    {
        public float Payment => Appointments.Select(a => a.GetCost()).Sum();

        public List<Appointment> Appointments = new List<Appointment>();
        public Patient(string pName) : base(pName)
        {
        }
    }
}