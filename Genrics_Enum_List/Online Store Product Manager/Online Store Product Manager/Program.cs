namespace Online_Store_Product_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository<Product> repository = new Repository<Product>();
            while (true)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    decimal.TryParse(Console.ReadLine(),out  decimal price);
                    if(price <= 0)
                    {
                        Console.WriteLine("Price cannot be negative. Product not added.");
                        continue;
                    }
                    Console.WriteLine("Select product category:");
                    foreach (var category in Enum.GetValues(typeof(ProductCategory)))
                    {
                        if(category.Equals(ProductCategory.Unkown))
                            continue;
                        Console.WriteLine($"{(int)category}. {category}");
                    }
                    Enum.TryParse(Console.ReadLine(), out ProductCategory categorySelected);
                    if(categorySelected == ProductCategory.Unkown)
                    {
                        Console.WriteLine("Invalid category selected. Product not added.");
                        continue;
                    }
                    Product product = new Product(name, price, categorySelected);
                    repository.Add(product);
                    Console.WriteLine("Product added successfully!");
                }
                else if (input == "2")
                {
                    Console.WriteLine("Products:");
                    foreach (var product in repository.GetAll())
                    {
                        Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Category: {product.Category}");
                    }
                }
                else if (input == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");

                }
            }
        }
    }
}
