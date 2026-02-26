class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    private List<Order> Orders = new List<Order>();

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void MakeOrder(OrderService orderService, Product product, byte quantity)
    {
        Order order = orderService.createOrder(this, product, quantity);
        Orders.Add(order);
        Console.WriteLine("Success : " + order.GetOrderId());
    }

    public Order[] GetOrders()
    {
        return Orders.ToArray();
    }
}