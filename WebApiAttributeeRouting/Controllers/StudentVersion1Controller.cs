using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAttributeeRouting.Models;

namespace WebApiAttributeeRouting.Controllers
{
    public class StudentVersion1Controller : ApiController
    {
        List<StudentVersion1> studentVersion1 = new List<StudentVersion1>()
        {
            new StudentVersion1{Id=1, Name= "Version1 Student 1"},
            new StudentVersion1{Id=2, Name= "Version1 Student 2"},
            new StudentVersion1{Id=3, Name= "Version1 Student 3"},
        };

       public IEnumerable<StudentVersion1> Get()
        {
            return studentVersion1;
        }

       public IHttpActionResult Get(int id)
        {
            var response = studentVersion1.FirstOrDefault(e => e.Id == id);
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
