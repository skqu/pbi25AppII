class DigitalProduct : Product
{
    public DigitalProduct(string name, decimal price)
    {
        Name = name;
        _price = price;
        _tax = 0.15m; // Example tax rate for digital products
    }
}