using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Fearless.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fearless.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private static readonly List<Person> _People = new List<Person>();

        // GET: api/<ItemController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_People);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public ActionResult GetItem(int id)
        {
            var person = _People.FirstOrDefault(x => x.ID == id);
            if (person == null)
                return NotFound(id);
            
            return Ok(person);
        }

        [HttpPut("{name}")]
        public ActionResult AddItem(string name)
        {
            //add new item to the list
            var maxId = 1;
            if (_People.Count() > 0)
                maxId = _People.Max(x => x.ID) + 1;

            var newItem = new Person()
            {
                ID = maxId,
                Name = name
            };
            _People.Add(newItem);

            return Ok(newItem.ID);
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var person = _People.FirstOrDefault(x => x.ID == id);
            if (person == null)
                return NotFound(id);

            _People.Remove(person);
            return Ok();
        }
    }
}
