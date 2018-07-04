using MongoDB.Driver;
using testHSEWebApi.Models;

namespace testHSEWebApi.DbContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            _database = client.GetDatabase("DevelopDB");
        }
        
        public IMongoCollection<UserItem> UsersCollection => _database.GetCollection<UserItem>("UsersCollection");
        
        /*
        public IMongoCollection<User> UsersCollection => _database.GetCollection<User>("UsersCollection");
        public IMongoCollection<Portfolio> PortfolioCollection => _database.GetCollection<Portfolio>("PortfolioCollection");
        public IMongoCollection<PortfolioAction> PortfolioActionCollection => _database.GetCollection<PortfolioAction>("PortfolioActionCollection");
        public IMongoCollection<BalanceState> BalanceStateCollection => _database.GetCollection<BalanceState>("BalanceStateCollection");
        public IMongoCollection<BalanceState> UnusedBalanceStateCollection => _database.GetCollection<BalanceState>("UnusedBalanceStateCollection");
        public IMongoCollection<CourseState> CourseStateCollection => _database.GetCollection<CourseState>("CourseStateCollection");
        */
    }
}