
using MyTaskPlanner.Domain.Models.Enums;
using MyTaskPlanner.Domain.Models.Models;

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введіть кількість :");
        int amount = int.Parse(Console.ReadLine());

        WorkItem[] items = new WorkItem[amount];

        for (int i = 0; i < amount; i++)
            items[i] = CreateEvent();
    }

    public static WorkItem CreateEvent()
    {
        try
        {
            WorkItem workItem = new WorkItem();
            Console.WriteLine("Title:");
            workItem.Title = Console.ReadLine();

            workItem.CreationDate = DateTime.Now;
            workItem.IsCompleted = false;

            while (true)
            {
                Console.WriteLine("Due Date (yyyy-MM-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                {
                    workItem.DueDate = dueDate;
                    break;
                }
                else
                {
                    Console.WriteLine("Некоректний формат дати. Спробуйте ще раз.");
                }
            }

            Console.WriteLine("Description");
            workItem.Description = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Complexity (0 - Simple, 1 - Moderate, 2 - Complex):");
                if (Enum.TryParse<Complexity>(Console.ReadLine(), out Complexity complexity))
                {
                    workItem.Complexity = complexity;
                    break;
                }
                else
                {
                    Console.WriteLine("Некоректне значення складності. Спробуйте ще раз.");
                }
            }

            while (true)
            {
                Console.WriteLine("Priority (0 - Low, 1 - Medium, 2 - High):");
                if (Enum.TryParse<Priority>(Console.ReadLine(), out Priority priority))
                {
                    workItem.Priority = priority;
                    break;
                }
                else
                {
                    Console.WriteLine("Некоректне значення пріоритету. Спробуйте ще раз.");
                }
            }

            return workItem;
        }
        catch (Exception)
        {
            Console.WriteLine("Помилка введення!");
            throw;
        }

    }
}