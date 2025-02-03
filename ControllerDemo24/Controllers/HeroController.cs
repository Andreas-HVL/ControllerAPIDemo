using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControllerDemo24.Models;

namespace ControllerDemo24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private static List<Hero> listOfHeroes = new List<Hero>()
        {
            new Hero() {id = 1, name = "Clark Kent", superHeroName = "Superman", team = "DC" },
            new Hero() {id = 2, name = "Bruce Wayne", superHeroName = "BatMan", team = "DC" },
            new Hero() { id = 3, name = "Diana Prince", superHeroName = "Wonder Woman", team = "DC" },
            new Hero() { id = 4, name = "Peter Parker", superHeroName = "Spider-Man", team = "Marvel" },
            new Hero() { id = 5, name = "Tony Stark", superHeroName = "Iron Man", team = "Marvel" },
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(listOfHeroes);
        }

        [HttpPost]
        public IActionResult Post(Hero hero)
        {
            listOfHeroes.Add(hero);
            return Ok(listOfHeroes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(listOfHeroes.FirstOrDefault(h => h.id == id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(listOfHeroes.Remove(listOfHeroes.FirstOrDefault(h => h.id == id)));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Hero hero)
        {
            var chosen = listOfHeroes.FindIndex(h => h.id == id);
            if(chosen == null) { return NotFound(); }
            listOfHeroes[chosen] = hero;
            return Ok(hero);
        }

    }
}
