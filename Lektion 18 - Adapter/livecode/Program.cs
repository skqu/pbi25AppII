using Livecode.Payment;
namespace Livecode
{
    class Program
    {
        public static void Main()
        {
            IPayment payment = new PaymentAdapter();

            Console.WriteLine(payment.Action());
        }
    }

}