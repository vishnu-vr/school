namespace school
{
    public class Teacher : Staff
    {
        public string Subject { get; set; }

        public Teacher() { }

        public Teacher(string name, string email, int empCode, string subject) : base(name, email, empCode, StaffType.teacher)
        {
            this.Subject = subject;
        }
    }
}
