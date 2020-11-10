namespace school
{
    public class Administartor : Staff
    {
        string Role;

        public Administartor(string name, string email, int empCode, string role) : base(name, email, empCode)
        {
            this.Role = role;
        }
    }
}
