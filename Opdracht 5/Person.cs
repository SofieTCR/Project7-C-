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

        public static List<Appointment> Appointments = new List<Appointment>();
        public Patient(string pName) : base(pName)
        {
        }

        public void AddAppointment(Appointment pAppointment)
        {
            Appointments.Add(pAppointment);
        }
    }
}