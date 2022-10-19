using ApiMongoDb.attributes;
using ApiMongoDb.models;
using ApiMongoDb.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMongoDb.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("listarProdutos")]
        [ApiKey]
        public async Task<List<Produto>> GetProdutos() =>
            await _produtoService.GetAsync();

        [HttpGet("listarProdutos/{id}")]
        [ApiKey]
        public async Task<Produto> GetProdutoById(string id) =>
            await _produtoService.GetAsyncById(id);

        [HttpPost("adicionarProduto")]
        [ApiKey]
        public async Task<Produto> SetProduto(Produto produto)
        {
            await _produtoService.CreateAsync(produto);

            return produto;
        }

        [HttpPut("editarProduto/{id}")]
        [ApiKey]
        public async Task<Produto> UpdateProduto(string id, Produto produto)
        {
            await _produtoService.UpdateAsync(id, produto);
            return produto;
        }
        
        [HttpDelete("deletarProduto/{id}")]
        [ApiKey]
        public async Task<string> DeleteProduto(string id)
        {
            await _produtoService.DeleteAsync(id);
            return "Produto deletado com sucesso!!";
        }
    }
}
