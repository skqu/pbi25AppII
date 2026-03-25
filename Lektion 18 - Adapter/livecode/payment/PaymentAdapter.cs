namespace Livecode.Payment
{
    class PaymentAdapter : IPayment
    {
        public PaymentAdapter()
        {
            
        }


        public string Action()
        {
            NewPayment pay = new NewPayment();
            return pay.smth();
        }
    }
}