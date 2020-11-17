namespace school
{
    public class Administrator : Staff
    {
        public string Role { get; set; }

        public Administrator() { }

        public Administrator(string name, string email, int empCode, string role) : base(name, email, empCode, StaffType.administrator)
        {
            this.Role = role;
        }
    }
}
