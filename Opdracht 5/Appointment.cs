namespace Hospital
{
    public class Appointment
    {
        public Patient refPatient { get; }

        public Doctor refDoctor { get; }

        public List<Nurse> Nurses { get; private set; } = new List<Nurse>();
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public Appointment(ref Patient rPatient, Doctor pDoctor, DateTime pStartTime, DateTime pEndTime)
        {
            refPatient = rPatient;
            refDoctor = pDoctor;
            StartTime = pStartTime;
            EndTime = pEndTime;
        }

        public void AddNurse(Nurse pNurse)
        {
            Nurses.Add(pNurse);
        }

        public void Save()
        {
            refPatient.AddAppointment(this);
        }

        public float GetCost()
        {
            var tmpDoctorRate = refDoctor.Salary;
            var tmpNursesRate = Nurses.Select(n => n.Salary).Sum();

            return GetTimeDifference() * (tmpDoctorRate + tmpNursesRate);
        }
        
        public float GetTimeDifference()
        {
            TimeSpan tmpSpan = EndTime - StartTime;
            return (float) tmpSpan.TotalHours;
        }
    }
}