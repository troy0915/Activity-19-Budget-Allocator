using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_19_Budget_Allocator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const decimal monthlyIncome = 25000m;
            string[] categories = { "Food", "Rent", "Utilities", "Transport", "Others" };
            decimal[] budgets = new decimal[categories.Length];

            Console.WriteLine("Family Budget Planner");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Monthly Income: {monthlyIncome:C}");
            Console.WriteLine("Enter your budget for each category:");

            for (int i = 0; i < categories.Length; i++)
            {
                Console.Write($"{categories[i]}: ");
                while (!decimal.TryParse(Console.ReadLine(), out budgets[i]) || budgets[i] < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                    Console.Write($"{categories[i]}: ");
                }
            }

            decimal totalBudget = 0;
            foreach (decimal budget in budgets)
            {
                totalBudget += budget;
            }

            Console.WriteLine($"\nTotal Budget: {totalBudget:C}");

            if (totalBudget > monthlyIncome)
            {
                decimal overspend = totalBudget - monthlyIncome;
                Console.WriteLine($"\nWarning: You are over budget by {overspend:C}");

                // Find category with highest budget to suggest cuts
                decimal maxBudget = 0;
                int maxIndex = 0;

                for (int i = 0; i < budgets.Length; i++)
                {
                    if (budgets[i] > maxBudget)
                    {
                        maxBudget = budgets[i];
                        maxIndex = i;
                    }
                }

                Console.WriteLine($"Suggested Action: Consider reducing your {categories[maxIndex]} budget (current: {maxBudget:C})");
            }
            else
            {
                Console.WriteLine("\nGood news! Your budget is within your monthly income.");
            }
        }
    }
}
