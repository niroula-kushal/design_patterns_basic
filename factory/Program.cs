var userPreference = "Esewa"; // This could be dynamically set based on user input or configuration

var paymentGateway = PaymentGatewayFactory.GetPaymentGateway(userPreference);
paymentGateway.Pay(1000); // Example amount

var secondUserPreference = "Khalti";
var secondPaymentGateway = PaymentGatewayFactory.GetPaymentGateway(secondUserPreference);
secondPaymentGateway.Pay(2000); // Example amount

public class PaymentGatewayFactory
{
    public static IPaymentGateway GetPaymentGateway(string gatewayType)
    {
        if(gatewayType == "Esewa")
        {
            return new Esewa();
        }
        else if(gatewayType == "Khalti")
        {
            return new Khalti();
        }
        else if(gatewayType == "NepalPay")
        {
            return new NepalPay();
        }
        else
        {
            throw new NotImplementedException($"Payment gateway {gatewayType} is not implemented.");
        }

        return gatewayType switch
        {
            "Esewa" => new Esewa(),
            "Khalti" => new Khalti(),
            _ => throw new NotImplementedException($"Payment gateway {gatewayType} is not implemented.")
        };
    }
}

/// Product
public interface IPaymentGateway
{
    void Pay(decimal amount);
}

/// Concrete Product
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

public class NepalPay : IPaymentGateway
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Payment of {amount} made using NepalPay.");
    }   
}
