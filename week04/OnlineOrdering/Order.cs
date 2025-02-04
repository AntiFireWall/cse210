namespace OnlineOrdering;

public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double OrderTotalPrice()
    {
        double totalPrice = 0;
        foreach (Product product in _products)
        {
            totalPrice += product.TotalPrice();
        }
        if (_customer.InUsa())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }
        return totalPrice;
    }

    public void DisplayShippingLabel()
    {
        Console.WriteLine($"Name: {_customer.GetFullName()}\n"
            + $"Address: {_customer.GetAddress()}");
        Console.WriteLine();
    }

    public void DisplayPackingLabel()
    {
        int itemNumber = 1;
        Console.WriteLine($"Product List: \n"
            + $"0. Name : ID - Quantity\n");
        foreach (Product product in _products)
        {
            Console.WriteLine($"{itemNumber}. {product.GetProductName()} : {product.GetProductId()} - {product.GetQuantity()}");
        }
        Console.WriteLine($"{_products.Count} Items");
        Console.WriteLine();
    }

    public void DisplayTotalPrice()
    {
        double shipping = 0;
        if (_customer.InUsa())
        {
            shipping = 5;
        }
        else
        {
            shipping = 35;
        }
        Console.WriteLine($"Total Price: ${OrderTotalPrice() - shipping}\n"
            + $"Shipping Cost: ${shipping}\n"
            + $"Total Amount: ${OrderTotalPrice()}\n");
    }
    
}