namespace school
{
    public class Teacher : Staff
    {
        public string Subject { get; set; }

        public Teacher(string name, string email, int empCode, string subject) : base(name, email, empCode, Type.teacher)
        {
            this.Subject = subject;
        }
    }
}
