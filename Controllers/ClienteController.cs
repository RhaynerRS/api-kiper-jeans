using ApiMongoDb.attributes;
using ApiMongoDb.models;
using ApiMongoDb.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMongoDb.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("listarClientes")]
        [ApiKey]
        public async Task<List<Cliente>> GetClientes() =>
            await _clienteService.GetAsync();

        [HttpGet("listarClientes/{id}")]
        [ApiKey]
        public async Task<Cliente> GetClienteById(string id) =>
            await _clienteService.GetAsyncById(id);

        [HttpPost("adicionarCliente")]
        [ApiKey]
        public async Task<IActionResult> SetCliente([FromBody] Cliente cliente)
        {
            if (cliente.datanascimento.Year <= (DateTime.Now.Year - 18))
            {
                await _clienteService.CreateAsync(cliente);
                return Ok(cliente);
            }
            else
            {
                return BadRequest("O cliente deve ser maior de 18 anos");
            }

        }

        [HttpPut("editarCliente/{id}")]
        [ApiKey]
        public async Task<IActionResult> UpdateCliente(string id, Cliente cliente)
        {
            if (cliente.datanascimento.Year <= (DateTime.Now.Year - 18))
            {
                await _clienteService.UpdateAsync(id, cliente);
                return Ok(cliente);
            }
            else
            {
                return BadRequest("O cliente deve ser maior de 18 anos");
            }
        }

        [HttpDelete("deletarCliente/{id}")]
        [ApiKey]
        public async Task<string> DeleteCliente(string id)
        {
            await _clienteService.DeleteAsync(id);
            return "Produto " + id + " deletado com sucesso!!";
        }
    }
}
