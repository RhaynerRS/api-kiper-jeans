using ApiMongoDb.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiMongoDb.services
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _produtoCollection;

        public ProdutoService(IOptions<produtoDatabaseSetting> produtoService)
        {
            var mongoClient = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            var mongoDatabase = mongoClient.GetDatabase(Environment.GetEnvironmentVariable("DATABASE_NAME"));
            _produtoCollection = mongoDatabase.GetCollection<Produto>("produtos");
        }

        public async Task<List<Produto>> GetAsync() =>
            await _produtoCollection.Find(el => true).ToListAsync();

        public async Task<Produto> GetAsyncById(string name) =>
            await _produtoCollection.Find(el => el.Id == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Produto produto) =>
            await _produtoCollection.InsertOneAsync(produto);
        public async Task UpdateAsync(string name, Produto produto) =>
            await _produtoCollection.ReplaceOneAsync(el => el.Id == name, produto);

        public async Task DeleteAsync(string name) =>
            await _produtoCollection.DeleteOneAsync(el => el.Id == name);
    }
}
