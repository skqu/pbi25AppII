class Order
{
    private string _orderId = "";
    private readonly Customer _customer;
    private readonly List<OrderLine> _orderLines = new List<OrderLine>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public void AddOrderLine(Product product, byte quantity)
    {
        _orderLines.Add(new OrderLine(product, quantity));
    }

    public OrderLine[] GetOrderLines()
    {
        return _orderLines.ToArray();
    }

    public void SetOrderId(string orderId)
    {
        _orderId = orderId;
    }

    public string GetOrderId()
    {
        return _orderId;
    }

    public void PayOrder(Pay pay)
    {
        decimal amount = GetOrderLines().Sum(ol => ol.GetProduct().CalculatePrice() * ol.Quantity);
        IPayment paymentMethod = pay.GetPaymentMethod();
        paymentMethod.ProcessPayment(amount);
    }

}