
using ApiMongoDb.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiMongoDb.services
{
    public class ClienteService
    {

        private readonly IMongoCollection<Cliente> _clienteCollection;

        public ClienteService(IOptions<produtoDatabaseSetting> clienteService)
        {
            var mongoClient = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            var mongoDatabase = mongoClient.GetDatabase(Environment.GetEnvironmentVariable("DATABASE_NAME"));
            _clienteCollection = mongoDatabase.GetCollection<Cliente>("clientes");
        }

        public async Task<List<Cliente>> GetAsync() =>
            await _clienteCollection.Find(el => true).ToListAsync();

        public async Task<Cliente> GetAsyncById(string name) =>
            await _clienteCollection.Find(el => el.Id == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Cliente cliente) {
                await _clienteCollection.InsertOneAsync(cliente);
        }
        public async Task UpdateAsync(string name, Cliente cliente){
                await _clienteCollection.ReplaceOneAsync(el => el.Id == name, cliente);
        }

        public async Task DeleteAsync(string name) =>
            await _clienteCollection.DeleteOneAsync(el => el.Id == name);
    }
}
