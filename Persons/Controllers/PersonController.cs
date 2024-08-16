using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persons.Services;
using Persons.Models;
using MongoDB.Driver;

namespace Persons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly MongoService mongo;
        private readonly IMongoCollection<Person> people;

        public PersonController(MongoService ms)
        {
            mongo = ms;
            people = mongo.GetCollection<Person>("People");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(people.Find(p => true).ToList());
        }


        [HttpPost]
        public ActionResult Post(Person person)
        {
            people.InsertOne(person);
            return Ok(person);
        }
    }
}
