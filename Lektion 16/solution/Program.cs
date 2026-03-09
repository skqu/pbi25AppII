using Livecode.Payment;
namespace Livecode
{
    class Program
    {
        public static void Main()
        {
            IPayment payment = new PaymentAdapter();

            bool cardStatus =  payment.VerifyCard();
            bool paymentStatus = payment.CreateTransaction(2, 10, "DKK");
            bool verification = payment.VerifyPayment();

            Console.WriteLine("cardStatus = " + cardStatus.ToString());
            Console.WriteLine("paymentStatus = " + paymentStatus.ToString());
            Console.WriteLine("Payment Verification = " + verification.ToString());
        }
    }

}