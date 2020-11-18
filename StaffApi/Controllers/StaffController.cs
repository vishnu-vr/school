using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school;

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

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            dynamic staff = db.GetOne(id);
            if (staff == null) return NotFound();
            else return Ok(staff);
        }

        // POST api/<StaffController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
