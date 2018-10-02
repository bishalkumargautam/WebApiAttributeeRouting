using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAttributeeRouting.Models;

namespace WebApiAttributeeRouting.Controllers
{
    public class StudentVersion2Controller : ApiController
    {
        List<StudentVersion2> studentVersion2 = new List<StudentVersion2>()
        {
            new StudentVersion2{Id=1,FirstName="second version 1", LastName="gautam" },
            new StudentVersion2{Id=2,FirstName="Second Version 2", LastName="gautam" },
            new StudentVersion2{Id=3,FirstName="Second version 3", LastName="gautam" }


        };

       public IEnumerable<StudentVersion2> Get()
        {
            return studentVersion2;
        }

       public IHttpActionResult Get(int id)
        {
            var response = studentVersion2.FirstOrDefault(e => e.Id == id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
