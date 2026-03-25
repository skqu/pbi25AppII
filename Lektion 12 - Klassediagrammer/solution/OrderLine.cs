class OrderLine
{
    public byte Quantity { get; private set; } = 0;
    private Product _product;
    public OrderLine(Product product, byte quantity)
    {
        _product = product;
        Quantity = quantity;
    }

    public Product GetProduct()
    {
        return _product;
    }
}