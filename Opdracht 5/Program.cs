namespace Hospital
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Doctor Harmsen
            var tmpDoctor = new Doctor("Hendrik Harmsen");
            tmpDoctor.SetSalary(62.52f);

            // Nurses
            var tmpNurse1 = new Nurse("Emily Brandsema");
            tmpNurse1.SetSalary(17.21f);

            var tmpNurse2 = new Nurse("Charlie Grutto");
            tmpNurse1.SetSalary(19.12f);

            // Patient
            var tmpPatient = new Patient("Matthew Crystler");
            
            // Appointment
            var tmpAppointment = new Appointment(rPatient: ref tmpPatient
                                               , pDoctor: tmpDoctor
                                               , pStartTime: new DateTime(2024, 3, 7, 10, 15, 0)
                                               , pEndTime: new DateTime(2024, 3, 7, 11, 45, 0)
												);

            

            tmpAppointment.AddNurse(tmpNurse1);
            tmpAppointment.AddNurse(tmpNurse2);

            tmpAppointment.Save();

            Console.WriteLine(tmpAppointment.GetTimeDifference());
            Console.WriteLine(tmpAppointment.GetCost());
            Console.WriteLine(tmpPatient.Payment);
		}
    }
}