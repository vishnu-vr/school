namespace school
{
    public class Teacher : Staff
    {
        private string Subject { get; set; }

        Teacher(string name, string email, int empCode, string subject) : base(name, email, empCode)
        {
            this.Subject = subject;
        }
    }
}
