using System;
using Newtonsoft.Json;

namespace SampleProject.Models
{
    public class UserItem
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}