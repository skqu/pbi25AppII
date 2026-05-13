class InvoicePayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing invoice payment of {amount:C}");
    }
}