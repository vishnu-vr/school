using System.Collections.Generic;

namespace school
{
    public interface IManageStaff
    {
        //add new staff
        public void AddStaff(StaffType type, string name, string email, int empCode, string extra);

        //get all details
        public List<dynamic> GetAll();

        //get specific detail
        public dynamic GetOne(int empCode);

        //update
        public bool Update(int empCode, string name, string email, string extra);

        //delete
        public bool Delete(int empCode);
    }
}
