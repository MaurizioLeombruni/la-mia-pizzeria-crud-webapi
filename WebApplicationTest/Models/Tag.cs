using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace WebApplicationTest.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [JsonIgnore]
        public List<Pizza>? Pizzas { get; set; }

        public Tag()
        {

        }
    }
}
