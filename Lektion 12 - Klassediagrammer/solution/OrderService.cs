class OrderService
{
    private string OrderId { get; set; }
    private Database _db;

    public OrderService(Database db)
    {
        OrderId = "";
        _db = db;
    }

    private void validateOrder()
    {
        // some validation logic
    }

    public Order createOrder(Customer customer, Product product, byte quantity)
    {
        validateOrder();

        Order order = new Order(customer);
        order.AddOrderLine(product, quantity);

        OrderId = _db.saveOrder();
        order.SetOrderId(OrderId);

        return order;
    }

    public string GetOrderId()
    {
        return OrderId;
    }


}