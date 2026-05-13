class PhysicalProduct : Product
{
    public PhysicalProduct(string name, decimal price)
    {
        _tax = 0.25m;
        Name = name;
        _price = price;
    }


}