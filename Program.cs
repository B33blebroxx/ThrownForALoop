List<Product> products = new()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        StockDate = new DateTime(2023, 10, 20),
        ManufacturerYear = 2010,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.00M,
        Sold = false,
        StockDate = new DateTime(2023, 11, 10),
        ManufacturerYear = 2015,
        Condition = 3.7

    },
    new Product()
    {
        Name = "Baseball Bat",
        Price = 16.00M,
        Sold = true,
        StockDate = new DateTime(2023, 12, 30),
        ManufacturerYear = 2007,
        Condition = 3.1
    },
    new Product()
    {
        Name = "Soccor Ball",
        Price = 13.50M,
        Sold = false,
        StockDate = new DateTime(2014, 06, 25),
        ManufacturerYear = 2010,
        Condition = 4.6
    },
    new Product()
    {
        Name = "Disc",
        Price = 21.00M,
        Sold = false,
        StockDate = new DateTime(2017, 04, 27),
        ManufacturerYear = 2014,
        Condition = 4.9
    }
};

string greeting = @"Welcome to Thrown for a Loop
Your one stop shop for used sporting equipment!";


Console.WriteLine(greeting);

string choice = null;

while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
0. Exit
1. View All Products
2. View Product Details
3. View Latest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }

    else if (choice == "2")
    {
        ViewProductDetails();
    }

    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}

void ViewProductDetails()
{
    decimal totalValue = 0.0M;
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");

    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }

    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine($@"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufacturerYear} years old.
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");

}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}.  {products[i].Name}");
    }

}

void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    //loop through the products
    foreach (Product product in products)
    {
        //Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}