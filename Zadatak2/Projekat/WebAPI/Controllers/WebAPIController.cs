using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class WebAPIController : ApiController
    {
        public class Person
        {
            public int id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int age { get; set; }

        }
        List<Person> people = new List<Person>() {
            new Person() {id = 1, FirstName = "Dino", LastName = "Sarlija", age = 23},
            new Person() {id = 2, FirstName = "Marko", LastName = "Duvnjak", age = 22},
            new Person() {id = 3, FirstName = "Ivan", LastName = "Kovac", age = 24},
            new Person() {id = 4, FirstName = "Sara", LastName = "Horvat", age = 21}
        };

        [HttpGet]
        public IHttpActionResult Get()
        {
            if (!people.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        public Person Get(int id)
        {
            Person D = new Person();
            foreach(var i in people)
            {
                if (id == i.id)
                {
                    D = i;
                }
            }
            return D;
        }

        [HttpPost]
        public void Post([FromBody] Person person)
        {
            people.Add(person);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] string value)
        {

            foreach (var i in people)
            {
                if (id == i.id)
                {
                    i.LastName = value;
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            foreach (var i in people)
            {
                if (id == i.id)
                {
                    people.Remove(i);
                    return Ok();
                }
            }
            return BadRequest("Not a valid Person id");
        }
    }
}
