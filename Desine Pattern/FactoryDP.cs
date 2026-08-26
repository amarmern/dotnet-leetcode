public interface IPayment
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine("Payment done using Credit Card: " + amount);
    }
}

public class UPIPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine("Payment done using UPI: " + amount);
    }
}

public class PaymentFactory
{
    public IPayment CreatePayment(string paymentType)
    {
        if (paymentType == "Card")
        {
            return new CreditCardPayment();
        }
        else if (paymentType == "UPI")
        {
            return new UPIPayment();
        }

        return null;
    }
}

////
/// usage
/// 
/// 
/// 
class Program
{
    static void Main()
    {
        PaymentFactory factory = new PaymentFactory();

        IPayment payment = factory.CreatePayment("UPI");

        payment.Pay(1000);
    }
}