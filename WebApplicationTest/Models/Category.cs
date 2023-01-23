namespace WebApplicationTest.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Pizza> PizzaList { get; set; }

        public Category() { }
    }
}
