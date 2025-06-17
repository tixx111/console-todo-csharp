using System;
using System.Linq;
using consoleApp.models;

class Program
{
    static void Main()
    {
        using var db = new dbContext();

        while (true)
        {
            Console.WriteLine("\n---ToDo List---");
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Show all");
            Console.WriteLine("3) Delete");
            Console.WriteLine("4) Exit");
            Console.Write("Choose action (1-4): ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter the task: ");
                    string taskText = Console.ReadLine();  
                    db.Task.Add(new TaskItem { Description = taskText });
                    db.SaveChanges();
                    Console.WriteLine("Task added");
                    break;

                case "2":
                    var tasks = db.Task.ToList();
                    if (!tasks.Any())
                        Console.WriteLine("ToDo list is empty");
                    else
                        Console.WriteLine("\nTasks:");
                        tasks.ForEach(t => Console.WriteLine($"{t.Id}. {t.Description}"));
                    break;

                case "3":
                    Console.Write("Task ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        var task = db.Task.Find(id);
                        if (task != null)
                        {
                            db.Task.Remove(task);
                            db.SaveChanges();
                            Console.WriteLine("Task deleted");
                        }
                        else Console.WriteLine("Task not found");
                    }
                    else Console.WriteLine("Invalid input");
                    break;

                case "4":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
