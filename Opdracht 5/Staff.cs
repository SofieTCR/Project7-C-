namespace Hospital
{
    public abstract class Staff : Person
    {
        public float Salary { get; protected set; }

        public Staff(string pName) : base(pName)
        {
        }
        public abstract void SetSalary(float pAmount);
    }

    public class Nurse : Staff
    {
        public Nurse(string pName) : base(pName)
        {
        }

        public override void SetSalary(float pAmount)
        {
            Salary = pAmount;
        }
    }

    public class Doctor : Staff
    {
        public Doctor(string pName) : base(pName)
        {
        }

        public override void SetSalary(float pAmount)
        {
            Salary = pAmount;
        }
    }
}