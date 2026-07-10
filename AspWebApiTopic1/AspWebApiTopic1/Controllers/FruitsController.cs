using Microsoft.AspNetCore.Mvc;

namespace AspWebApiTopic1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FruitsController : ControllerBase
    {
        private readonly List<string> fruits = new()
        {
            "Apple",
            "Banana",
            "Cherry",
            "Mango",
            "Orange"
        };

        [HttpGet]
        public IActionResult GetFruits()
        {
            return Ok(fruits);
        }

        [HttpGet("{id}")]
        public IActionResult GetFruitsByIndex(int id)
        {
            if (id < 0 || id >= fruits.Count)
            {
                return NotFound("Fruit not found.");
            }

            return Ok(fruits[id]);
        }
    }
}