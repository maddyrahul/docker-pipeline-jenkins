using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jenkins_pipeline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenkinsDemo : ControllerBase
    {
        private static List<string> _values = new List<string> { "value1", "value2", "value3" };
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_values);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id >= 0 && id < _values.Count)
            {
                return Ok(_values[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            _values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = _values.Count - 1 }, value);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id >= 0 && id < _values.Count)
            {
                _values[id] = value;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id >= 0 && id < _values.Count)
            {
                _values.RemoveAt(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
