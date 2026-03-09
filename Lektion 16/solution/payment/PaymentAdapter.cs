using System.IO.Compression;
using System.Runtime.InteropServices;

namespace Livecode.Payment
{
    class PaymentAdapter : IPayment
    {
        public PaymentAdapter()
        {
            
        }

        public bool VerifyCard()
        {
            return true;
        }

        public bool VerifyPayment()
        {
            return false;
        }

        public bool CreateTransaction(byte user, int price, string currency)
        {
            NewPayment pay = new NewPayment();
            return pay.CreateTransaction(user, price, currency);

        }
    }
}