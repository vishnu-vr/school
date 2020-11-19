using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using school;
using System;
using System.Collections.Generic;
using System.Linq;

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

            if (type == nameof(StaffType.teacher))
            {
                return Ok(staffs.Where(staff => staff.Type == StaffType.teacher));
            }
            else if (type == nameof(StaffType.administrator))
            {
                return Ok(staffs.Where(staff => staff.Type == StaffType.administrator));
            }
            else if (type == nameof(StaffType.support))
            {
                return Ok(staffs.Where(staff => staff.Type == StaffType.support));
            }
            else if (type == null)
            {
                return Ok(db.GetAll());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{empcode:int}")]
        public ActionResult Get(int empCode)
        {
            dynamic staff = db.GetOne(empCode);
            if (staff == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(staff);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] JObject staff)
        {
            dynamic st = db.GetOne((int)staff["empcode"]);

            //if such staff exsists then its duplicate entry
            if (st != null)
            {
                return Conflict();
            }

            dynamic returnObject;
            string extra;

            if ((int)staff["type"] == (int)StaffType.teacher)
            {
                extra = (string)staff["subject"];
                returnObject = new Teacher((string)staff["name"],
                                            (string)staff["email"], 
                                            (int)staff["empcode"], 
                                            (string)staff["subject"]);
            }
            else if ((int)staff["type"] == (int)StaffType.administrator)
            {
                extra = (string)staff["role"];
                returnObject = new Administrator((string)staff["name"],
                                                (string)staff["email"], 
                                                (int)staff["empcode"], 
                                                (string)staff["role"]);
            }
            else if ((int)staff["type"] == (int)StaffType.support)
            {
                extra = (string)staff["department"];
                returnObject = new Support((string)staff["name"], 
                                            (string)staff["email"], 
                                            (int)staff["empcode"], 
                                            (string)staff["department"]);
            }
            else
            {
                return BadRequest();
            }

            //incorrect format
            if (extra == null)
            {
                return BadRequest();
            }

            db.AddStaff((StaffType)Enum.ToObject(typeof(StaffType), (int)staff["type"]), 
                        (string)staff["name"], 
                        (string)staff["email"], 
                        (int)staff["empcode"], 
                        extra);

            return Created("Staff Added", returnObject);
        }

        [HttpPut("{empcode:int}")]
        public ActionResult Put(int empCode, [FromBody] JObject staff)
        {
            dynamic st = db.GetOne(empCode);

            if (st == null)
            {
                return NotFound();
            }

            string extra = null;

            if (typeof(Teacher) == st.GetType())
            {
                extra = (string)staff["subject"];
            }
            else if (typeof(Support) == st.GetType())
            {
                extra = (string)staff["department"];
            }
            else if (typeof(Administrator) == st.GetType())
            {
                extra = (string)staff["role"];
            }

            //incorrect format
            if (extra == null)
            {
                return BadRequest();
            }

            db.Update(empCode, (string)staff["name"], (string)staff["email"], extra);

            return Ok();
        }

        [HttpDelete("{empcode}")]
        public ActionResult Delete(int empCode)
        {
            dynamic st = db.GetOne(empCode);
            if (st == null)
            {
                return NotFound();
            }

            db.Delete(empCode);

            return Ok();
        }
    }
}
