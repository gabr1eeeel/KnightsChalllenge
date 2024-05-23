using KnightsChallenge.Models;
using KnightsChallenge.Utils;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace KnightsChallenge.Services
{
    public class KnightService
    {
        private readonly IMongoCollection<Knight> _knightCollection;

        public KnightService(IOptions<DatabaseSettings> knightServices)
        {
            var mongoClient = new MongoClient(knightServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(knightServices.Value.DatabaseName);

            _knightCollection = mongoDatabase.GetCollection<Knight>
                (knightServices.Value.CollectionName);
        }

        public async Task<List<Knight>> GetAsync() =>
            await _knightCollection.Find(x => true).ToListAsync();

        public async Task<List<Knight>> GetHeroesAsync() =>
        await _knightCollection.Find(knight => knight.IsHero == true).ToListAsync();

        public async Task<Knight> GetAsync(string id) =>
            await _knightCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Knight knight) =>
            await _knightCollection.InsertOneAsync(knight);
        public async Task UpdateAsync(string id, string newNickName)
        {
            var filter = Builders<Knight>.Filter.Eq(x => x.Id, id);
            var knight = Builders<Knight>.Update.Set(x => x.Nickname, newNickName);

            await _knightCollection.UpdateOneAsync(filter, knight);
        }
        public async Task RemoveAsync(string id)
        {
            var filter = Builders<Knight>.Filter.Eq(x => x.Id, id);
            var knight = Builders<Knight>.Update.Set(x => x.IsHero, true);

            await _knightCollection.UpdateOneAsync(filter, knight);
        }


    }
}
