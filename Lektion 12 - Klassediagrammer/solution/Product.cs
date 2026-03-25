abstract class Product
{
    public string Name { get; set; } = string.Empty;
    protected decimal _price  = 0;

    protected decimal _tax = 0;

    public Product()
    {
    }


    public decimal CalculatePrice()
    {
        return _price * (1 + _tax);
    }
}