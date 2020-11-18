using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using school;
using StaffApi.Models;

namespace StaffApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        readonly DBManageStaff db;

        public StaffController()
        {
             db = new DBManageStaff();
        }

        [HttpGet()]
        public ActionResult Get(string type)
        {
            List<dynamic> staffs = db.GetAll();

            if (type == "teacher") return Ok(staffs.Where(staff => staff.Type == StaffType.teacher));
            else if (type == "administrator") return Ok(staffs.Where(staff => staff.Type == StaffType.administrator));
            else if (type == "support") return Ok(staffs.Where(staff => staff.Type == StaffType.support));
            else if (type == null) return Ok(db.GetAll());
            else return NotFound();
        }

        [HttpGet("{empcode:int}")]
        public ActionResult Get(int empCode)
        {
            dynamic staff = db.GetOne(empCode);
            if (staff == null) return NotFound();
            else return Ok(staff);
        }

        [HttpPost]
        public ActionResult Post([FromBody] StaffAddObject staff)
        {
            db.AddStaff(staff.Type, staff.Name, staff.Email, staff.EmpCode, staff.Extra);
            return Created("Staff Added", new Staff(staff.Name, staff.Email, staff.EmpCode, staff.Type));
        }   

        [HttpPut("{empcode:int}")]
        public ActionResult Put(int empCode, [FromBody] StaffUpdateObject staff)
        {
            dynamic st = db.GetOne(empCode);
            if (st == null) return NotFound();

            return Ok(db.Update(empCode, staff.Name, staff.Email, staff.Extra));
        }

        [HttpDelete("{empcode}")]
        public ActionResult Delete(int empCode)
        {
            dynamic st = db.GetOne(empCode);
            if (st == null) return NotFound();

            return Ok(db.Delete(empCode));
        }
    }
}
