namespace PizzaCalories.Exception
{
    public static class ExceptionMessage
    {
        public static string InvalidTypeOfDough = "Invalid type of dough.";

        public static string InvalidDoughWeight = "Dough weight should be in the range [1..200].";

        public static string InvalidToppingWeight = "{0} weight should be in the range [1..50].";

        public static string InvalidToppingName = "Cannot place {0} on top of your pizza.";

        public static string InvalidPizzaName = "Pizza name should be between 1 and 15 symbols.";

        public static string InvalidNuberToppingPizza = "Number of toppings should be in range [0..10].";
    }
}
