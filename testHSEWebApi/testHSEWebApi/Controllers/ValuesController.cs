using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using testHSEWebApi.Repository;

namespace testHSEWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private FakeDataBase _dataBase;
        public ValuesController(FakeDataBase dataBase)
        {
            _dataBase = dataBase;
        }
        
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(_dataBase.GetListString());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
           _dataBase.AddSomeString(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
