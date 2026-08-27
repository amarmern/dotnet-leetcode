// Interface
public interface IPayment
{
    void Pay(decimal amount);
}

// Implementation
public class UPIPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine("Payment done using UPI: " + amount);
    }
}
public class VisaPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine("Payment done using Visa: " + amount);
    }
}

// Service
public class PaymentService
{
    private readonly IPayment _payment;

    // Dependency Injection through constructor
    public PaymentService(IPayment payment)
    {
        _payment = payment;
    }

    public void MakePayment(decimal amount)
    {
        _payment.Pay(amount);
    }
}

class Program
{
    static void Main()
    {
        IPayment payment = new UPIPayment();

        PaymentService service = new PaymentService(payment);

        service.MakePayment(1000);
    }
}