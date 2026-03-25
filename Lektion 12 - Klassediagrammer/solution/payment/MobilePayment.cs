class MobilePayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing mobile payment of {amount:C}");
    }
}