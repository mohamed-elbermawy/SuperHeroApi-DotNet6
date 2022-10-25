using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> HEROES = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "BatMan",
                FirstName = "Mohamed",
                LastName = "Ashraf",
                Place = "Cairo"
            },
            new SuperHero
            {
                Id = 2,
                Name = "BatMan 1",
                FirstName = "Mohamed 1",
                LastName = "Ashraf 1",
                Place = "Cairo 1"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(HEROES);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<SuperHero>> Get(int Id)
        {
            var obj = HEROES.Find(e => e.Id == Id);
            if (obj == null)
                return BadRequest("Hero Not Found");
            return Ok(obj);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Add(SuperHero wrapper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(wrapper);
            }
            HEROES.Add(wrapper);
            return Ok(HEROES);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero wrapper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(wrapper);
            }
            var obj = HEROES.Find(e => e.Id == wrapper.Id);
            if (obj == null)
                return BadRequest("Hero Not Found");

            obj.Name = wrapper.Name;
            obj.FirstName = wrapper.FirstName;
            obj.LastName = wrapper.LastName;
            obj.Place = wrapper.Place;
            return Ok(HEROES);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int Id)
        {
            var obj = HEROES.Find(e => e.Id == Id);
            if (obj == null)
                return BadRequest("Hero Not Found");

            HEROES.Remove(obj);
            return Ok(HEROES);
        }
    }
}
