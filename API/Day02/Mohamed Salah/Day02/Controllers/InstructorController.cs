using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : Controller
    {
        public InstructorController(IRepository<Instructor> IR)
        {
            this.IR = IR;
        }

        public IRepository<Instructor> IR { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(IR.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            if(IR.isExist(id))
            {
                return Ok(IR.GetById(id));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Instructor T)
        {
            if(ModelState.IsValid)
            {
                IR.Insert(T);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (IR.isExist(id))
            {
                var inst = IR.GetById(id);
                IR.Delete(id);
                return Ok(inst);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Instructor I)
        {
            if(ModelState.IsValid)
            {
                if (id != I.Id)
                    return BadRequest();

                IR.Update(id, I);
                return Ok(I);
            }

            return BadRequest();
        }
    }
}
