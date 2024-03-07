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
        public float Payment { get; private set; }
        public Patient(string pName, float pPayment) : base(pName)
        {
        }
    }
}