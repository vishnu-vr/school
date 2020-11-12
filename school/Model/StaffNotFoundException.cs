using System;
namespace school
{
    public class StaffNotFoundException : Exception
    {
        public StaffNotFoundException()
            : base(String.Format("Staff Not Found!!!")) { }
    }
}
