using System.Runtime.InteropServices;

namespace Livecode.Payment
{
    class NewPayment
    {
        public NewPayment()
        {
            
        }

        public bool CreateTransaction(byte user, int price, string currency)
        {
            if ( currency == "DKK")
            {
                return true;
            }
            return false;
        }

    }
}