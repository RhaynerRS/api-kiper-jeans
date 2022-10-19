using ApiMongoDb.attributes;
using ApiMongoDb.models;
using ApiMongoDb.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMongoDb.Controllers
{
    [Route("api/vendas")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly VendaService _vendasService;

        public VendasController(VendaService vendasService)
        {
            _vendasService = vendasService;
        }

        [HttpGet("listarVendas")]
        [ApiKey]
        public async Task<List<Venda>> GetVendas() =>
            await _vendasService.GetAsync();

        [HttpGet("listarVendas/{id}")]
        [ApiKey]
        public async Task<Venda> GetProdutoById(string id) =>
            await _vendasService.GetAsyncById(id);

        [HttpPost("adicionarVenda")]
        [ApiKey]
        public async Task<IActionResult> SetProduto(Venda venda)
        {
            if ((DateTime.Now - venda.data).TotalDays > 30)
            {
                return BadRequest("Somente vendas dos ultimos 30 dias podem ser cadastradas.");
            }
            else if (venda.data > DateTime.Now)
            {
                return BadRequest("Uma venda não pode ter uma data maior que a atual.");
            }
            else
            {
                await _vendasService.CreateAsync(venda);
                return Ok(venda);
            }
        }

        [HttpPut("editarVenda/{id}")]
        [ApiKey]
        public async Task<IActionResult> UpdateProduto(string id, Venda venda)
        {
            if ((DateTime.Now - venda.data).TotalDays > 30)
            {
                return BadRequest("Somente vendas dos ultimos 30 dias podem ser cadastradas.");
            }
            else if (venda.data > DateTime.Now)
            {
                return BadRequest("Uma venda não pode ter uma data maior que a atual.");
            }
            else
            {
                await _vendasService.UpdateAsync(id, venda);
                return Ok(venda);
            }
        }

        [HttpDelete("deletarVenda/{id}")]
        [ApiKey]
        public async Task<string> DeleteProduto(string id)
        {
            await _vendasService.DeleteAsync(id);
            return "Produto deletado com sucesso!!";
        }
    }
}
