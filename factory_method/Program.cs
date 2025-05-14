IPaymentGatewayFactory esewaGatewayFactory = new EsewaFactory();
// esewa
IPaymentGateway esewaGateway = esewaGatewayFactory.CreatePaymentGateway();
// Calls Esewa's Pay method
esewaGateway.Pay(1000);

// Product
public interface IPaymentGateway
{
    void Pay(decimal amount);
}

// Concrete Product
public class Esewa : IPaymentGateway
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Payment of {amount} made using Esewa.");
    }
}

public class Khalti : IPaymentGateway
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Payment of {amount} made using Khalti.");
    }
}

// Creator
public interface IPaymentGatewayFactory
{
    IPaymentGateway CreatePaymentGateway();
}

// Concrete Creator
public class EsewaFactory : IPaymentGatewayFactory
{
    public IPaymentGateway CreatePaymentGateway()
    {
        return new Esewa();
    }
}

public class KhaltiFactory : IPaymentGatewayFactory
{
    public IPaymentGateway CreatePaymentGateway()
    {
        return new Khalti();
    }
}