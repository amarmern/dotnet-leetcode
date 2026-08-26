// Strategy
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

// Concrete Strategy 1
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine("Paid using Credit Card: " + amount);
    }
}

// Concrete Strategy 2
public class UPIPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine("Paid using UPI: " + amount);
    }
}

// Context
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