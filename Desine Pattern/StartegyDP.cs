using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public class Program
    {
        // 1. Product interface
        public interface IPaymentStrategy
        {
            void Pay(decimal amount);
        }

        // 2. Concreate products
        public class CreditCardsPyment : IPaymentStrategy
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine("Paid {amount} using credit card");
            }
        }

        public class UPIPayment : IPaymentStrategy
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine($"Paid {amount} using UPI Payment");
            }
        }

        //3. Context class of startegy 

        public class PaymentService
        {
            private IPaymentStrategy _paymentStrategy;

            public PaymentService(IPaymentStrategy paymentStrategy)
            {
                _paymentStrategy = paymentStrategy;
            }

            public void MakePayment(decimal amount)
            {
                _paymentStrategy.Pay(amount);
            }
        }
        public static void Main(string[] args)
        {
            IPaymentStrategy startegy = new UPIPayment();
            PaymentService paymentService = new PaymentService(startegy);
            paymentService.MakePayment(5000);
        }
    }
}