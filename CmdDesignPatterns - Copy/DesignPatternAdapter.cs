using System;

namespace DesignPatternsDemo
{
    /// <summary>
    /// The Adapter Design Pattern
    ///The goal of the Adapter design pattern is to convert one interface to another.
    /// </summary>
    public class DesignPatternAdapter
    {

        public static void XXX_Main()
        {
            //var prov = new StwipeProvider("Amazon");
            //MakeAPayment(prov);//first place to make a change in code
            //prov.Pay("wetWET","12.03.2001",545454);

            MakeAPayment(new PaySalAdapter()); // only one place to make a change in code
        }

        private static void MakeAPayment(IPaymentProcessorAdapter provider)
        {
            provider.ProcessProviderPayType("Emag", "BRDNOIUOI65656566", "12.03.2155", 213424);
        }

        private static void MakeAPayment(StwipeProvider provider)//second change
        {
            provider.Pay("WERWERWER", "23", 200);//third change
        }
    }

    public class StwipeProvider
    {
        public StwipeProvider(string merchantKey)
        {

        }

        // returns false if payment is rejected
        public bool Pay(string cardNumber, string expiration, decimal amount)
        {
            if (amount < 0)
                return false;

            Console.WriteLine("Pay something");
            return true;
        }
    }

    public class PaySalProvider
    {
        // throws exception if payment is rejected
        public void ProcessPayment(string merchantId, CreditCardDetails cardInfo, decimal amount)
        {
            if (amount < 0)
                throw new Exception("The amount value must be positive !");

            Console.WriteLine("Process payment");



        }
    }

    public class CreditCardDetails
    {

        public CreditCardDetails(string cardNumber, string expiration)
        {

        }
    }

    public interface IPaymentProcessorAdapter
    {
        // returns false if payment is rejected
        bool ProcessProviderPayType(string merchantId, string cardNumber, string expiration,
                            decimal amount);
    }

    public class StwipeAdapter : IPaymentProcessorAdapter
    {
        public bool ProcessProviderPayType(string merchantId, string cardNumber, string expiration,
                            decimal amount)
        {
            var provider = new StwipeProvider(merchantId);
            return provider.Pay(cardNumber, expiration, amount);
        }
    }

    public class PaySalAdapter : IPaymentProcessorAdapter
    {
        public bool ProcessProviderPayType(string merchantId,
            string cardNumber, string expiration,
            decimal amount)
            {
                var provider = new PaySalProvider();
                try
                {
                    var cardInfo = new CreditCardDetails(cardNumber, expiration);
                    provider.ProcessPayment(merchantId, cardInfo, amount);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
    }

}
