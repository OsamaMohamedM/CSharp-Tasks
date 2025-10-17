namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> studentNames = new List<string>();
            List<double> studentGrades = new List<double>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter name {i + 1}: ");
                string name = Console.ReadLine();
                studentNames.Add(name);
                Console.Write($"Enter grade for {name}: ");
                double grade = Convert.ToDouble(Console.ReadLine());
                studentGrades.Add(grade);
            }

            double averageGrade = studentGrades.Average();
            double highestGrade = studentGrades.Max();
            double lowestGrade = studentGrades.Min();
            Console.WriteLine("\n--- Results ---");
            Console.WriteLine($"Average grade: {averageGrade}");
            Console.WriteLine($"Top student: {highestGrade}");
            Console.WriteLine($"Lowest student: {lowestGrade}");
        }
    }
}
