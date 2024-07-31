public class Order
{
    public int Id { get; set; }
    public double Amount { get; set; }
}

public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
}

public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing credit card payment...");
    }
}

public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing PayPal payment...");
    }
}

public class BankTransferPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing bank transfer payment...");
    }
}

public class PaymentService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public PaymentService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void ProcessPayment(Order order)
    {
        _paymentProcessor.ProcessPayment(order);
    }
}

public interface IOrderRepository
{
    void Save(Order order);
    Order Load(int orderId);
}

public class OrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
        Console.WriteLine("Saving order to database...");
    }

    public Order Load(int orderId)
    {
        Console.WriteLine("Loading order from database...");
        return new Order { Id = orderId, Amount = 0 };
    }
}
