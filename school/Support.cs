namespace school
{
    public class Support : Staff
    {
        string Department;

        public Support(string name, string email, int empCode, string department) : base(name, email, empCode)
        {
            this.Department = department;
        }
    }
}
