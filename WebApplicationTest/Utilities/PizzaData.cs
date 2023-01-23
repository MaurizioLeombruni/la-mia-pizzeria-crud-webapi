using WebApplicationTest.Models;

namespace WebApplicationTest.Utilities
{
    public static class PizzaData
    {
        private static List<Pizza> pizzas;

        public static List<Pizza> ConstructPizzas()
        {
            if(pizzas != null )
            {
                return pizzas;
            }

            pizzas = new List<Pizza>();

            for(int i=0; i<10; i++)
            {
                Pizza newPizza = new(i, "Nome Pizza", "Descrizione della pizza", "https://picsum.photos/200/?random=" + i, "" + i + ",50€");
                pizzas.Add(newPizza);
            }


            return pizzas;
        }
    }
}
