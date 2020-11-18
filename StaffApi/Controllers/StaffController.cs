using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school;
using Newtonsoft.Json.Linq;
using StaffApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET api/<StaffController>/teaching
        //[HttpGet("{type}")] 
        public ActionResult Get(string type)
        {
            List<dynamic> ret = db.GetAll();

            if (type == "teacher") return Ok(ret.Where(staff => staff.Type == StaffType.teacher));
            else if (type == "administrator") return Ok(ret.Where(staff => staff.Type == StaffType.administrator));
            else if (type == "support") return Ok(ret.Where(staff => staff.Type == StaffType.support));
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

        // POST api/<StaffController>
        [HttpPost]
        public ActionResult Post([FromBody] StaffAddObject staff)
        {
            db.AddStaff(staff.Type, staff.Name, staff.Email, staff.EmpCode, staff.Extra);
            return Created("Staff Added", new Staff(staff.Name, staff.Email, staff.EmpCode, staff.Type));
        }   

        // PUT api/<StaffController>/5
        [HttpPut("{empcode:int}")]
        public ActionResult Put(int empCode, [FromBody] StaffUpdateObject staff)
        {
            dynamic st = db.GetOne(empCode);
            if (st == null) return NotFound();

            return Ok(db.Update(empCode, staff.Name, staff.Email, staff.Extra));
        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{empcode}")]
        public ActionResult Delete(int empCode)
        {
            dynamic st = db.GetOne(empCode);
            if (st == null) return NotFound();

            return Ok(db.Delete(empCode));
        }
    }
}
