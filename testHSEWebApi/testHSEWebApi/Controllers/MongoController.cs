using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testHSEWebApi.Models;
using testHSEWebApi.Repository;

namespace testHSEWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoController : ControllerBase
    {
        private readonly MongoDbRepository _repository;
        public MongoController(MongoDbRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("getAll")]
        public async Task<IEnumerable<UserItem>> Get()
        {
            return await _repository.GetAllUsers();
        }

        [HttpPost("add")]
        public async void Add([FromBody] UserItem item)
        {
            await _repository.AddUserAsync(item);
        }
        
        [HttpPost("check/{name}/{pass}")]
        public async Task<bool> Check(string name, string pass)
        {
            var item = new UserItem()
            {
                Name = name,
                Password = pass
            };
            return await _repository.CheckUserExists(item);
        }
    }
}