namespace Livecode.Payment
{
    interface IPayment
    {

        public bool VerifyCard();

        public bool VerifyPayment();

        public bool CreateTransaction(byte user, int price, string currency);
    }
}