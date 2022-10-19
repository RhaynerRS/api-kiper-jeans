using ApiMongoDb.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiMongoDb.services
{
    public class VendaService
    {
        private readonly IMongoCollection<Venda> _vendaCollection;

        public VendaService(IOptions<produtoDatabaseSetting> vendaService)
        {
            var mongoClient = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            var mongoDatabase = mongoClient.GetDatabase(Environment.GetEnvironmentVariable("DATABASE_NAME"));
            _vendaCollection = mongoDatabase.GetCollection<Venda>("vendas");
        }

        public async Task<List<Venda>> GetAsync() =>
            await _vendaCollection.Find(el => true).ToListAsync();

        public async Task<Venda> GetAsyncById(string name) =>
            await _vendaCollection.Find(el => el.Id == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Venda venda) =>
            await _vendaCollection.InsertOneAsync(venda);
        public async Task UpdateAsync(string name, Venda venda) =>
            await _vendaCollection.ReplaceOneAsync(el => el.Id == name, venda);

        public async Task DeleteAsync(string name) =>
            await _vendaCollection.DeleteOneAsync(el => el.Id == name);
    }
}
