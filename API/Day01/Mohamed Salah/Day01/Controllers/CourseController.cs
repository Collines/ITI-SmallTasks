using Day01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public CourseDBContext DB { get; }
        public CourseController(CourseDBContext DB)
        {
            this.DB = DB;
        }


        [HttpGet]
        public ActionResult Get()
        {
            if(DB.Courses.ToList().Count>0)
            {
                return Ok(DB.Courses.ToList());
            }
            return NotFound();
        }

        [HttpDelete]
        public ActionResult DeleteCourse(int id)
        {
            Course? course = DB.Courses.Find(id);
            if(course != null)
            {
                DB.Courses.Remove(course);
                DB.SaveChanges();
                return Ok(course);
            }
            return NotFound();
        }

        [HttpPut]
        public ActionResult Put(int id,[FromBody] Course course)
        {
            if(id != course.ID)
            {
                //return StatusCode(400);
                return BadRequest();
            }
            Course? currCrs = DB.Courses.Where(C=>C.ID==id).FirstOrDefault();
            if(currCrs != null)
            {
                currCrs.Name = course.Name ?? currCrs.Name;
                currCrs.Description = course.Description ?? currCrs.Description;
                currCrs.Duration = course?.Duration ?? currCrs.Duration;
                DB.SaveChanges();
                return Ok(course);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Course course)
        {
            if(ModelState.IsValid)
            {
                if (course != null)
                {
                    DB.Add(course);
                    DB.SaveChanges();
                    return Ok(course);
                }
                return NotFound();
            }
                return NotFound();
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            Course? course = DB.Courses.Find(id);
            if(course!=null)
            {
                return Ok(course);
            }
            return NotFound();
        }

        [HttpGet("{name:alpha}")]
        public ActionResult CourseByName(string name)
        {
            Course? course = DB.Courses.Where(C=>C.Name == name).FirstOrDefault();
            if (course != null)
            {
                return Ok(course);
            }
            return NotFound();
        }
    }
}
