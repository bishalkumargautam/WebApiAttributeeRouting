using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAttributeeRouting.Models;

namespace WebApiAttributeeRouting.Controllers
{
    [RoutePrefix("api/students")] // adding routeprefix to controller
    public class StudentsController : ApiController
    {

        static List<Student> students = new List<Student>()
        {
            new Student(){Id=1,Name="Anthony"},
            new Student(){Id=2,Name="Mark"},
            new Student(){Id=3,Name="Harshal"},
            new Student(){Id=4,Name="Gulliver"},

        };

       [Route("~/api/teachers")] //overriding route prefix 
        public IEnumerable<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(){Id=1,Name="Hari"},
                new Teacher(){Id=2,Name="Ram"},
                new Teacher(){Id=3,Name="Shyam"},
            };
            return teachers;
        }

        [Route("")]
        public IEnumerable<Student> Get()
        {
            return students.ToList();
        }

        [Route("{id:int:min(1):max(100)}")] // constraints with paramaters
        //constraints to add what type of id is passed. If this constraint is not defined then the controller will be
        //confused between this method and Get(string name) method
        public Student Get(int id)
        {
            return students.FirstOrDefault(e => e.Id == id);
        }

        [Route("{name:alpha}")]//alpha denotes upper or lower case alphabetic characters. Others type of constraints are double , booleadn, float etc.
        public Student Get(string name)
        {
            return students.FirstOrDefault(e => e.Name.ToLower() == name.ToLower());
        }

        [Route("{id}/courses")]//User of [Route] to define routes is called attribute based routing.
        //in attribute based routing we define routes. If this route had not been defined, the controller
        //gets confused when http://localhost:57392/api/students/1 is sent, because both the get request for student and get request for 
        //course starts with keyword get, so it gets confused.
        public IEnumerable<string> GetStudentCourse(int id)
        {
            if (id == 1)
            {
                return new List<string>() { "C#", "ASP.NET", "SQL" };
            }
            else if (id == 2)
            {
                return new List<string>() { "C#", "ASP.NET Web API", "SQL" };
            }
            else
            {
                return new List<string>() { "C#", "Angular", "Bootstrap", "ASP.NET", "SQL" };
            }
        }


        //Post
        [Route("~/api/students",Name ="GetStudentsById")]
        public HttpResponseMessage Post(Student student)
        {
            students.Add(student);
            var response= Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("GetStudentsById",new { id=student.Id}));//adding Uri to response that will get the link for this created student object.
            return response;
        }

    }

}
