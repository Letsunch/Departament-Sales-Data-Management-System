using System;

namespace Question2
{
    public class RunDepartment
    {
        static void Main(string[] args)
        {
            Department department = new Department();

            department.PopulateArray();

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Calculate and Display Average Sales per Department");
            Console.WriteLine("2. Calculate and Display Average Sales per Month");
            Console.WriteLine("3. Determine the Month with the Highest Sales per Department");
            Console.WriteLine("4. Determine the Department with the Highest Sales per Month");
            Console.WriteLine("5. Exit");

            bool exit = false;
            while (!exit)
            {
                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        DisplayAvgSalesPerDepartment(department);
                        break;
                    case 2:
                        DisplayAvgSalesPerMonth(department);
                        break;
                    case 3:
                        DisplayHighestSalesPerDepartment(department);
                        break;
                    case 4:
                        DisplayHighestSalesPerMonth(department);
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;
                }
            }
        }

        static void DisplayAvgSalesPerDepartment(Department department)
        {
            Console.WriteLine("\nAverage Sales per Department:");
            double[] avgSalesPerDepartment = department.CalculateAvgSalesPerDepart();
            for (int i = 0; i < avgSalesPerDepartment.Length; i++)
            {
                Console.WriteLine($"Department {i + 1}: {avgSalesPerDepartment[i]}");
            }
        }

        static void DisplayAvgSalesPerMonth(Department department)
        {
            Console.WriteLine("\nAverage Sales per Month:");
            double[] avgSalesPerMonth = department.CalculateAvgSalesPerMonth();
            for (int i = 0; i < avgSalesPerMonth.Length; i++)
            {
                Console.WriteLine($"Month {i + 1}: {avgSalesPerMonth[i]}");
            }
        }

        static void DisplayHighestSalesPerDepartment(Department department)
        {
            Console.WriteLine("\nMonth with the Highest Sales per Department:");
            for (int i = 1; i <= 3; i++)
            {
                int highestMonth = department.DetermineHighestDepartSales(i);
                Console.WriteLine($"Department {i}: Month {highestMonth}");
            }
        }

        static void DisplayHighestSalesPerMonth(Department department)
        {
            Console.WriteLine("\nDepartment with the Highest Sales per Month:");
            for (int i = 1; i <= 3; i++)
            {
                int highestDepartment = department.DetermineHighestMonthlySales(i);
                Console.WriteLine($"Month {i}: Department {highestDepartment}");
            }
        }
    }

    public class Department
    {
        private double[][] sales;

        public Department()
        {
            sales = new double[4][];
            for (int i = 0; i < sales.Length; i++)
            {
                sales[i] = new double[3];
            }
        }

        public void PopulateArray()
        {
            Console.WriteLine("Enter sales data for each department for the last three months:");
            for (int i = 0; i < sales.Length; i++)
            {
                Console.WriteLine($"Department {i + 1}:");
                for (int j = 0; j < sales[i].Length; j++)
                {
                    Console.Write($"Month {j + 1}: ");
                    sales[i][j] = double.Parse(Console.ReadLine());
                }
            }
        }

        public double[] CalculateAvgSalesPerMonth()
        {
            double[] avgSales = new double[3];
            for (int i = 0; i < sales[0].Length; i++)
            {
                double total = 0;
                int count = 0;
                for (int j = 0; j < sales.Length; j++)
                {
                    if (sales[j][i] > 0)
                    {
                        total += sales[j][i];
                        count++;
                    }
                }
                avgSales[i] = total / count;
            }
            return avgSales;
        }

        public double[] CalculateAvgSalesPerDepart()
        {
            double[] avgSales = new double[sales.Length];
            for (int i = 0; i < sales.Length; i++)
            {
                double total = 0;
                int count = 0;
                for (int j = 0; j < sales[i].Length; j++)
                {
                    if (sales[i][j] > 0)
                    {
                        total += sales[i][j];
                        count++;
                    }
                }
                avgSales[i] = total / count;
            }
            return avgSales;
        }

        public int DetermineHighestMonthlySales(int month)
        {
            int highestDepartment = -1;
            double highestSales = double.MinValue;
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i][month - 1] > highestSales)
                {
                    highestSales = sales[i][month - 1];
                    highestDepartment = i + 1;
                }
            }
            return highestDepartment;
        }

        public int DetermineHighestDepartSales(int department)
        {
            int highestMonth = -1;
            double highestSales = double.MinValue;
            for (int i = 0; i < sales[department - 1].Length; i++)
            {
                if (sales[department - 1][i] > highestSales)
                {
                    highestSales = sales[department - 1][i];
                    highestMonth = i + 1;
                }
            }
            return highestMonth;
        }
    }
}
