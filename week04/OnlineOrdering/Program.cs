using System;
using OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("John Doe", new Address("123 Main Street", "Los Angeles", "CA", "USA"));
        Customer customer2 = new Customer("Maria González", new Address("Calle Mayor 15", "Madrid", "Madrid", "Spain"));
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Headphones", "P1001", 99.99, 2));
        order1.AddProduct(new Product("Laptop Stand", "P1002", 45.50, 1));
        order1.AddProduct(new Product("Mechanical Keyboard", "P1003", 120.00, 1));
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartwatch", "P2001", 199.99, 1));
        order2.AddProduct(new Product("Bluetooth Speaker", "P2002", 89.50, 1));
        order2.AddProduct(new Product("External Hard Drive (1TB)", "P2003", 89.50, 1));
        order2.AddProduct(new Product("USB-C Hub", "P2004", 34.99, 1));
        
        order1.DisplayShippingLabel();
        order1.DisplayPackingLabel();
        order1.DisplayTotalPrice();
        
        Console.WriteLine("--------------------------------------------\n");
        
        order2.DisplayShippingLabel();
        order2.DisplayPackingLabel();
        order2.DisplayTotalPrice();
    }
}