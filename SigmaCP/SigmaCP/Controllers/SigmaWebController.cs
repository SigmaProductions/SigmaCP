using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SigmaCP.Model;

namespace SigmaCP.Controllers
{
    [Route("api/[controller]")]
    public class SigmaWebController : Controller
    {
        SocketServer socketServer;

        public SigmaWebController()
        {
            socketServer = new SocketServer();
        }

        // GET api/values/5
        [HttpGet]
        public string Get()
        {
            return "testString";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] JsonInterpreter JsonData)
        {
            try
            {
                Interpreter MyInterpreter = new Interpreter(JsonData);
                MyInterpreter.Run();
                return "Is ok";

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
