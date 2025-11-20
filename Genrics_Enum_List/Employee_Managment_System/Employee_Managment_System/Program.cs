namespace Employee_Managment_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository<Employee> repository = new Repository<Employee>();
            while (true)
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int.TryParse(Console.ReadLine(),out int age);
                        if(age <= 0)
                        {
                            Console.WriteLine("Invalid age. Please try again.\n");
                            break;
                        }
                        Console.Write("Enter Job Title (1: Developer, 2: Manager, 3: Tester): ");
                        string titleInput = Console.ReadLine();
                        Enum.TryParse(titleInput, true, out JobTitleEnum title);
                        if(title == JobTitleEnum.Unkown)
                        {
                            Console.WriteLine("Invalid job title. Please try again.\n");
                            break;
                        }
                        Employee employee = new Employee (name, age,title );
                        repository.Add(employee);
                        Console.WriteLine("Employee added successfully.\n");
                        break;
                    case "2":
                        Console.WriteLine("Employees:");
                        foreach (var emp in repository.GetAll())
                        {
                            Console.WriteLine($"Name: {emp.Name}, Age: {emp.Age}, Title: {emp.Title}");
                        }
                        Console.WriteLine();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
                }
        }
    }
}
