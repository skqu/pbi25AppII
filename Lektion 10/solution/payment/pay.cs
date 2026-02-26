class Pay
{
    private CreditCardPayment _creditCard;
    private InvoicePayment _invoice;
    private MobilePayment _mobile;
    private byte _counter = 0;

    public Pay()
    {
        _creditCard = new CreditCardPayment();
        _invoice = new InvoicePayment();
        _mobile = new MobilePayment();
    }

    public IPayment GetPaymentMethod()
    {
        switch (_counter)
        {
            case 0:
                _counter++;
                return _creditCard;
            case 1:
                _counter++;
                return _invoice;
            case 2:
                _counter = 0;
                return _mobile;
            default:
                throw new InvalidOperationException("Invalid payment method");
        }
    }

}