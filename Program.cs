using System.Threading.Tasks.Dataflow;

namespace TaskForces
{
    public class TaskForce
    {
        public int battleships { get; set; }
       
        // Overload unary operators ++ and -- 
        public static TaskForce operator ++(TaskForce tf)
        {
            tf.battleships += 1;
            return tf;
        }

        public static TaskForce operator --(TaskForce tf)
        {
            tf.battleships -= 1;
            return tf;
        }

        // Overload Comparison Operators > and <
        public static bool operator >(TaskForce tf1, TaskForce tf2)
        {
            return tf1.battleships > tf2.battleships;
        }

        public static bool operator <(TaskForce tf1, TaskForce tf2)
        {
            return tf1.battleships < tf2.battleships;
        }

        // Overload Binary Operators + and -
        public static TaskForce operator +(TaskForce tf1, TaskForce tf2)
        {
            tf1.battleships += tf2.battleships;
            return tf1;
        }

        public static TaskForce operator -(TaskForce tf1, TaskForce tf2)
        {
            tf1.battleships -= tf2.battleships;
            return tf1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Operator Overloading with Task Forces");
            
            Console.WriteLine("=====================================");
            const int TF_LIMIT = 5;
            const int MAX_SIZE = 20;
            const int MIN_SIZE = 1;
            const int ADD_SHIPS = 5;
            const int SUB_SHIPS = 5;

            Console.WriteLine($"NOTE: Task Forces are limited to having no less than {MIN_SIZE} battleship(s), ");
            Console.WriteLine($"and no more than {MAX_SIZE} battleships.");
            Console.WriteLine($"The Current Task Force Limit is set to {TF_LIMIT} Task Forces");
            Console.WriteLine("=====================================");

            Random r = new Random();
            TaskForce[] taskForces = new TaskForce[TF_LIMIT];

            // Display the # of Battleships in each task force
            Console.WriteLine("               # of Battleships:");
            for (int i = 0; i < taskForces.Length; i++)
            {
                taskForces[i] = new TaskForce();                    
                taskForces[i].battleships = r.Next(1, MAX_SIZE); 
                Console.Write("Task Force #" + (i + 1) + " | " + taskForces[i].battleships);
                Console.WriteLine("");
            }

            Console.WriteLine("=====================================");

            // Add or subtract 1 Battleship from each TaskForce object
            // But only if doing so will not violate the limits
            // Display the new number of Battleships in the Task Force


            for (int i = 0; i < taskForces.Length; i++)
            {
                int plusMinus = r.Next(1, 3);
                if (plusMinus == 1)
                {
                    Console.WriteLine($"Random add battleship to Task Force # {i+1}");
                    if (taskForces[i].battleships + 1 <= MAX_SIZE)
                    {
                        taskForces[i].battleships++;
                    }
                    else
                    {
                        Console.WriteLine("Cannot add 1 battleship to Task Force #" + (i + 1) + " because it would exceed the maximum size of " + MAX_SIZE);
                    }
                }
                else 
                {
                    Console.WriteLine($"Random subtract battleship from Task Force {i+1}");
                    if (taskForces[i].battleships - 1 >= MIN_SIZE)
                    {
                        taskForces[i].battleships--;
                    }
                    else
                    {
                        Console.WriteLine("Cannot subtract 1 battleship from Task Force #" + (i + 1) + " because it would be less than the minimum size of " + MIN_SIZE);
                    }
                }
            }

            Console.WriteLine("");
            // Display the # of Battleships in each task force
            Console.WriteLine("               # of Battleships:");
            for (int i = 0; i < taskForces.Length; i++)
            {
                Console.Write("Task Force #" + (i + 1) + " | " + taskForces[i].battleships);
                Console.WriteLine("");
            }

            Console.WriteLine("=====================================");

            // random TaskForce object to add
            TaskForce numToAdd = new TaskForce();
            numToAdd.battleships = r.Next(1, ADD_SHIPS);
            Console.WriteLine();
            Console.WriteLine($"Adding {numToAdd.battleships} to Each Task Force...");
            for (int i = 0; i < taskForces.Length; i++)
            {
                if (taskForces[i].battleships + numToAdd.battleships <= MAX_SIZE)
                {
                    taskForces[i] = taskForces[i] + numToAdd;
                }
                else
                {
                    Console.WriteLine("Cannot add " + numToAdd.battleships + " battleships to Task Force #" + (i + 1) + " because it would exceed the maximum size of " + MAX_SIZE);
                }
            }

            // Display the # of Battleships in each task force
            Console.WriteLine("               # of Battleships:");
            for (int i = 0; i < taskForces.Length; i++)
            {
                Console.Write("Task Force #" + (i + 1) + " | " + taskForces[i].battleships);
                Console.WriteLine("");
            }

            Console.WriteLine();

            // random TaskForce object to subtract
            TaskForce numToSub = new TaskForce();
            numToSub.battleships = r.Next(1, SUB_SHIPS);
            Console.WriteLine($"Subtracting {numToSub.battleships} from each Task Force...");
            for (int i = 0; i < taskForces.Length; i++)
            {
                if (taskForces[i].battleships - numToSub.battleships >= MIN_SIZE)
                {
                    taskForces[i] = taskForces[i] - numToSub;
                }
                else
                {
                    Console.WriteLine("Cannot subtract " + numToSub.battleships + " battleships from Task Force #" + (i + 1) + " because it would be less than the minimum size of " + MIN_SIZE);
                }
            }

            // Display the # of Battleships in each task force
            Console.WriteLine("               # of Battleships:");
            for (int i = 0; i < taskForces.Length; i++)
            {
                Console.Write("Task Force #" + (i + 1) + " | " + taskForces[i].battleships);
                Console.WriteLine("");
            }


            Console.WriteLine("=====================================");
            Console.WriteLine("");
            // random TaskForce object for comparison
            TaskForce numToCompare = new TaskForce();
            numToCompare.battleships = r.Next(1, 10);
            Console.WriteLine($"Task Forces with #of battleships above or below {numToCompare.battleships}:");
            for (int i = 0; i < taskForces.Length; i++)
            {
                if (taskForces[i] > numToCompare)
                {
                    Console.WriteLine($"Task Force #{i + 1} has more than {numToCompare.battleships} Battleships.");
                }
                else if (taskForces[i] < numToCompare)
                {
                    Console.WriteLine($"Task Force #{i + 1} has fewer than {numToCompare.battleships} Battleships.");
                }
                else
                {
                    Console.WriteLine($"Task Force #{i + 1} has exactly {numToCompare.battleships} Battleships.");
                }
            }
        }
    }
}