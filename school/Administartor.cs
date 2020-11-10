namespace school
{
    public class Administartor : Staff
    {
        public string Role { get; set; }

        public Administartor(string name, string email, int empCode, string role) : base(name, email, empCode, "administrator")
        {
            this.Role = role;
        }
    }
}
