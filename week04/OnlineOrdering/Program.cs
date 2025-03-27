using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P1001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "P1002", 49.99, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Keyboard", "P2001", 79.99, 1));
        order2.AddProduct(new Product("Monitor", "P2002", 199.99, 1));
        order2.AddProduct(new Product("USB Cable", "P2003", 9.99, 3));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
