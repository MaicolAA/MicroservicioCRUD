using Microsoft.AspNetCore.Mvc;
using Microservicio.Data;
using Microservicio.Models;

namespace Microservicio.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientsController : ControllerBase
    {
        private readonly DbConnector _dbConnector;

        public ClientsController(DbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        [HttpGet]
        [Route("showclients")]
        public IActionResult ShowClients()
        {
            var clients = _dbConnector.GetClients();
            return Ok(clients);
        }

        [HttpGet]
        [Route("getclient/{id}")]
        public IActionResult GetClientById(int id)
        {
            var client = _dbConnector.GetClientById(id);

            if (client == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            return Ok(client);
        }

        [HttpPost]
        [Route("saveclient")]
        public IActionResult SaveClient([FromBody] Client client)
        {

            _dbConnector.InsertClient(client);

            return Ok("Cliente guardado exitosamente.");
        }

        [HttpPut]
        [Route("updateclient")]
        public IActionResult UpdateClient([FromBody] Client client)
        {

            _dbConnector.UpdateClient(client);

            return Ok("Cliente actualizado exitosamente.");
        }

        [HttpDelete]
        [Route("deleteclient/{id}")]
        public IActionResult DeleteClient(int id)
        {

            _dbConnector.DeleteClient(id);

            return Ok("Cliente eliminado exitosamente.");
        }
    }
}
