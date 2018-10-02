using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAttributeeRouting.Models;

namespace WebApiAttributeeRouting.Controllers
{
    public class IHttpActionResultController : ApiController
    {
        static List<MaleStudent> maleStudents = new List<MaleStudent>()
        {
            new MaleStudent(){Id=1, Name="Male Student 1"},
            new MaleStudent(){Id=2, Name="Male Student 2"},
            new MaleStudent(){Id=3, Name="Male Student 3"},
        };

        public IHttpActionResult Get()
        {
            return Ok(maleStudents);
        }

        public IHttpActionResult Get(int id)
        {
            var response = maleStudents.FirstOrDefault(e => e.Id == id);
            if (response == null)
            {
                //return NotFound(); //without error message
                return Content(HttpStatusCode.NotFound, "student with id " + id + " not found"); //witherror message

                // return Request.CreateResponse(HttpStatusCode.NotFound, "Some error message");// if Ihttpresponse message then this many lines have to be written, unit testing also becomes difficult with this.
            }
            else
            {
                var std = maleStudents.FirstOrDefault(e => e.Id == id);
                return Ok(std);
            }
        }
        
        //Post
        [HttpPost]
       [Route(Name ="AddMaleStudent")]
        public IHttpActionResult AddStudent( MaleStudent maleStudent)
        {
            maleStudents.Add(maleStudent);
            return Content(HttpStatusCode.Created, "Item created");
          
        }
    }
}
