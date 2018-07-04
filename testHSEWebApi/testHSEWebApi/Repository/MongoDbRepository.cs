using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using testHSEWebApi.DbContext;
using testHSEWebApi.Models;

namespace testHSEWebApi.Repository
{
    public class MongoDbRepository
    {
        private readonly MongoDbContext _context;
        
        public MongoDbRepository()
        {
            _context = new MongoDbContext();
        }
        
        public async Task<bool> CheckUserExists(UserItem user)
        {
            FilterDefinition<UserItem> nameFilter = Builders<UserItem>.Filter.Eq("Name", user.Name);
            FilterDefinition<UserItem> passwordFilter = Builders<UserItem>.Filter.Eq("Password", user.Password);
            FilterDefinition<UserItem> concatFilter = Builders<UserItem>.Filter.And(nameFilter, passwordFilter);
            List<UserItem> tmp = await _context.UsersCollection.Find(concatFilter).ToListAsync();
            
            return tmp != null && tmp.Count == 1;
        }
        
        public async Task AddUserAsync(UserItem user)
        {
            await _context.UsersCollection.InsertOneAsync(user);
        }
        
        public async Task<IEnumerable<UserItem>> GetAllUsers()
        {
            FilterDefinition<UserItem> filter = Builders<UserItem>.Filter.Empty;
            List<UserItem> tmp = await _context.UsersCollection.Find(filter).ToListAsync();
            return tmp;
        }
    }
}