using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Opdracht1
{
    public class Task
    {
        // Properties for task attributes
        public bool IsComplete { get; set; } = false;
        public string Title { get; set; }
        public string Description { get; set; }
        public int Identifier { get; private set; }

        // Constructor to initialize task
        public Task(int identifier, string title, string description)
        {
            Identifier = identifier;
            Title = title;
            Description = description;
        }
    }

    class Program
    {
        // List of tasks
        public List<Task> TaskList { get; private set; }
        // Validation messages list
        public List<string> ValidationMessages { get; private set; } = new List<string>();
        // Flag to control program flow
        private bool isActive = true;

        static void Main(string[] args)
        {
            var program = new Program();
            program.GetTasks();

            while (program.isActive)
            {
                Console.Clear();
                program.DisplayCurrentState();
                program.AwaitUserInput();
            }

            // Display validation messages, if any
            if (program.ValidationMessages.Count != 0)
            {
                foreach (string message in program.ValidationMessages)
                {
                    Console.WriteLine(message);
                }
            }
        }

        // Display current tasks
        public void DisplayCurrentState()
        {
            Console.WriteLine("Current Tasks:");
            Console.WriteLine("   Id | Done | Title           | Description");
            foreach (Task task in TaskList)
            {
                Console.WriteLine($"   {task.Identifier.ToString().PadRight(2).Substring(0, 2)}"
                                 + $" |  [{(task.IsComplete ? "X" : " ")}]"
                                 + $" | {task.Title.PadRight(15).Substring(0, 15)}"
                                 + $" | {task.Description.PadRight(35).Substring(0, 35)}");
            }
        }

        // Wait for user input
        public void AwaitUserInput()
        {
            Console.WriteLine("Please press a number to proceed:");
            Console.WriteLine("[0] View a task");
            Console.WriteLine("[1] Add a task");
            Console.WriteLine("[2] Clear the task list");
            Console.WriteLine("[3] Exit the application");

            // Continue awaiting user input until valid input is received
            var awaiting = true;
            while (awaiting)
            {
                var pressedKey = Console.ReadKey(true).KeyChar.ToString();
                switch (pressedKey)
                {
                    case "0":
                        ViewTask();
                        awaiting = false;
                        break;
                    case "1":
                        AddTask();
                        awaiting = false;
                        break;
                    case "2":
                        if (RequestConfirmation()) TaskList.Clear();
                        awaiting = false;
                        break;
                    case "3":
                        SetTasks();
                        isActive = false;
                        awaiting = false;
                        break;
                    default:
                        Console.WriteLine($"Unknown Character {pressedKey} received, please try again!");
                        break;
                }
            }
        }

        // Add a task
        public void AddTask()
        {
            Console.WriteLine("Please enter the title for your task:");
            var title = Console.ReadLine();
            Console.WriteLine("Please enter the description for your task:");
            var description = Console.ReadLine();
            TaskList.Add(new Task(identifier: TaskList.Select(t => t.Identifier).DefaultIfEmpty(0).Max() + 1,
                                  title: title,
                                  description: description));
        }

        // View a specific task
        public void ViewTask()
        {
            Console.WriteLine("Please enter the Id of the task you'd like to view:");
            var hasTask = false;
            while (!hasTask && TaskList.Count != 0)
            {
                var id = Convert.ToInt32(Console.ReadLine());
                var matchingTask = TaskList.FirstOrDefault(t => t.Identifier == id);
                if (matchingTask != null)
                {
                    hasTask = true;
                    DisplayTask(pTaskId: id);
                }
                else
                {
                    Console.WriteLine($"Invalid Id {id} received, please try again");
                }
            }
        }

        // Display details of a specific task
        public void DisplayTask(int pTaskId)
        {
            Console.Clear();
            var task = TaskList.FirstOrDefault(t => t.Identifier == pTaskId);
            Console.WriteLine($"Title: {task.Title} | {(task.IsComplete ? "Complete" : "Incomplete")}");
            Console.WriteLine();
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine();
            Console.WriteLine("Please press a number to proceed:");
            Console.WriteLine($"[0] Mark the task as {(task.IsComplete ? "Incomplete" : "Complete")}");
            Console.WriteLine("[1] Remove the task");
            Console.WriteLine("[2] Return to the menu");

            // Continue awaiting user input until valid input is received
            var awaiting = true;
            while (awaiting)
            {
                var pressedKey = Console.ReadKey(true).KeyChar.ToString();
                switch (pressedKey)
                {
                    case "0":
                        task.IsComplete = !task.IsComplete;
                        awaiting = false;
                        break;
                    case "1":
                        if (RequestConfirmation()) TaskList.Remove(task);
                        awaiting = false;
                        break;
                    case "2":
                        awaiting = false;
                        break;
                    default:
                        Console.WriteLine($"Unknown Character {pressedKey} received, please try again!");
                        break;
                }
            }
        }

        // Make the user confirm their action.
        public bool RequestConfirmation()
        {
            Console.WriteLine("Are you sure you want to proceed with this action? Y/N");
            // Continue awaiting user input until valid input is received
            var awaiting = true;
            while (awaiting)
            {
                var pressedKey = Console.ReadKey(true).KeyChar.ToString().ToLower();
                switch (pressedKey)
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.WriteLine($"Unknown Character {pressedKey} received, please try again!");
                        break;
                }
            }
            return false;
        }

        // Retrieve tasks from file
        public void GetTasks(bool reset = false)
        {
            if (reset || !File.Exists("data.json"))
            {
                TaskList = new List<Task>();
                return;
            }

            try
            {
                TaskList = JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText("data.json"));
            }
            catch
            {
                ValidationMessages.Add("JSON Data file exists but the contents are not valid.");
            }
        }

        // Save tasks to file
        public void SetTasks()
        {
            try
            {
                File.WriteAllText("data.json", JsonConvert.SerializeObject(TaskList));
            }
            catch
            {
                ValidationMessages.Add("Data failed to serialize to JSON or JSON failed to write to file.");
            }
        }
    }
}