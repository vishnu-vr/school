﻿namespace school
{
    public class Support : Staff
    {
        public string Department { get; set; }

        public Support(string name, string email, int empCode, string department) : base(name, email, empCode, "support")
        {
            this.Department = department;
        }
    }
}
