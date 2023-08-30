
using Microservicio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio.Controllers
{
    [ApiController]
    [Route("client")]

    public class ClientsController : ControllerBase
    {
        [HttpGet]
        [Route("showclients")]
        public dynamic ShowClients()
        {
            List<Client> clients = new List<Client>
            {
                new Client
                {
                    id =1,
                    email = "maicol@gmail.com",
                    edad = 20,
                    name = "Maicol Arroyave"
                },
                new Client
                {
                    id =2,
                    email = "daniel@gmail.com",
                    edad = 25,
                    name = "Daniel Arroyave"
                }

            };

            return clients;
        }

        //[HttpPost]
        //[Route("saveclient")]
        //public dynamic SaveClient()
        //{

        //}
    }
}
