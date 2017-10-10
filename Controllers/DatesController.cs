using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReminderApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReminderApi.Controllers
{
    [Route("api/[controller]")]
    public class DatesController : Controller
    {
        private readonly DatesContext _context;

        public DatesController(DatesContext context)
        {
            _context = context;

            if (_context.Dates.Count() == 0)
            {

                _context.Dates.Add(new Dates { Date = DateTime.Parse("2017-01-01") });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Dates> GetAll()
        {
            return _context.Dates.ToList();
        }

        [HttpGet("{id}", Name = "GetDate")]
        public IActionResult GetById(long id)
        {
            var item = _context.Dates.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Dates item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Dates.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.ID }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Dates item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var todo = _context.Dates.FirstOrDefault(t => t.ID == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Date = item.Date;
           
            _context.Dates.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Dates.FirstOrDefault(t => t.ID == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Dates.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
        