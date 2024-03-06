using Newtonsoft.Json;
using System.IO;

namespace Opdracht1
{
    public class Task
    {
        public bool isComplete { get; set; } = false;

        public string title { get; set; }

        public string description { get; set; }

        public int identifier { get; private set; }

        public Task (int pIdentifier, string pTitle, string pDescription)
        {
            identifier = pIdentifier;
            title = pTitle;
            description = pDescription;
        }
    }


    class Program {
        public List<Task> TaskList { get; private set; }

        public List<string> VML { get; private set;} = new List<string>();

        private bool isActive = true;
        static void Main(string[] args)
        {
            var program = new Program();
            program.GetTasks();

            while (program.isActive) {
                Console.Clear();
                program.DisplayCurrentState();
                program.AwaitUserInput();
            }
            if (program.VML.Count != 0) {
                foreach (string vm in program.VML) {
                    Console.WriteLine(vm);
                }
            }
        }

        public void DisplayCurrentState() {
            Console.WriteLine("Current Tasks:");
            Console.WriteLine("   Id | Done | Title           | Description");
            foreach (Task task in TaskList) {
                Console.WriteLine($"   {task.identifier.ToString().PadRight(2).Substring(0, 2)}"
                                 +$" |  [{(task.isComplete ? "X" : " ")}]" 
                                 +$" | {task.title.PadRight(15).Substring(0, 15)}"
                                 +$" | {task.description.PadRight(35).Substring(0,35)}");
            }
        }

        public void AwaitUserInput() {
            Console.WriteLine("Please press a number to proceed:");
            Console.WriteLine("[0] View a task");
            Console.WriteLine("[1] Add a task");
            Console.WriteLine("[2] Clear the tasklist");
            Console.WriteLine("[3] Exit the application");
            var awaiting = true;
            while (awaiting) {
                var pressedKey = Console.ReadKey(true).KeyChar.ToString();
                switch (pressedKey) {
                    case "0" :
                        ViewTask();
                        awaiting = false;
                        break;
                    case "1" :
                        AddTask();
                        awaiting = false;
                        break;
                    case "2" :
                        TaskList = new List<Task>();
                        awaiting = false;
                        break;
                    case "3" :
                        SetTasks();
                        isActive = false;
                        awaiting = false;
                        break;
                    default : 
                        Console.WriteLine($"Unknown Character {pressedKey} received, please try again!");
                        break;
                }
            }
        }
        public void AddTask()
        {
            Console.WriteLine("Please enter the title for your task");
            var title = Console.ReadLine();
            Console.WriteLine("Please enter the description for your task");
            var description = Console.ReadLine();
            TaskList.Add(new Task(pIdentifier: TaskList.Select(t => t.identifier).DefaultIfEmpty(0).Max() + 1
                                , pTitle: title
                                , pDescription: description));
        }

        public void ViewTask() {
            Console.WriteLine("Please enter the Id of the task you'd like to view");
            var hasTask = false;
            Task task;
            while (!hasTask) {
                var Id = Convert.ToInt32(Console.ReadLine());
                var matchingTask = TaskList.FirstOrDefault(t => t.identifier == Id);
                if (matchingTask != null) {
                    hasTask = true;
                    task = matchingTask;
                }
                else {
                    Console.WriteLine($"Invalid Id {Id} received, please try again");
                }
            }

        }
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
                return;
            }
            catch
            {
                VML.Add("JSON Data file exists but the contents are not valid.");
            }
        }

        public void SetTasks()
        {
            if (TaskList != null)
            try
            {
                File.WriteAllText("data.json", JsonConvert.SerializeObject(TaskList));
            }
            catch
            {
                VML.Add("Data failed to serialise to JSON or JSON failed to write to file.");
            }
        }
    }
}