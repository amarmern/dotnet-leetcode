using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public class Program
    {
        // Component
        public interface IPayment
        {
            void Pay(decimal amount);
        }

        // Concrete Component
        public class Payment : IPayment
        {
            public void Pay(decimal amount)
            {
                Console.WriteLine("Payment processed: " + amount);
            }
        }

        // Decorator
        public class PaymentDecorator : IPayment
        {
            protected IPayment _payment;

            public PaymentDecorator(IPayment payment)
            {
                _payment = payment;
            }

            public virtual void Pay(decimal amount)
            {
                _payment.Pay(amount);
            }
        }

        // Concrete Decorator - Logging
        public class LoggingPaymentDecorator : PaymentDecorator
        {
            public LoggingPaymentDecorator(IPayment payment)
                : base(payment)
            {
            }

            public override void Pay(decimal amount)
            {
                Console.WriteLine("Payment started");

                _payment.Pay(amount);

                Console.WriteLine("Payment completed");
            }
        }

        public static void Main(string[] args)
        {
            IPayment payment = new Payment();

            payment = new LoggingPaymentDecorator(payment);

            payment.Pay(1000);


        }
    }
}