class Program
{
    static void Main(string[] args)
    {
        Pay pay = new Pay();
        Product product = new PhysicalProduct("Laptop", 999.99m);
        Product product2 = new DigitalProduct("E-Book", 99.99m);
        Customer cst = new Customer("John Doe", "john.doe@example.com");
        Database db = new Database();
        OrderService orderService = new OrderService(db);
        cst.MakeOrder(orderService, product, 3);
        cst.MakeOrder(orderService, product2, 1);
        Order[] orders = cst.GetOrders();
        foreach (var order in orders)
        {
            Console.WriteLine(order.GetOrderId());
            Product[] products = order.GetOrderLines().Select(ol => ol.GetProduct()).ToArray();
            foreach (var prod in products)
            {
                Console.WriteLine($" {prod.Name} - {prod.CalculatePrice():C}");
            }
            order.PayOrder(pay);
        }

    }
}