using System;
using System.Collections.Generic;


namespace Assignment_3
{
    class Program
    {
        static Dictionary<int, string> studentDatabase = new Dictionary<int, string>();
        static void Main(string[] args)
        {
            
            Greet();  
            Greet("Hello", "Alice"); 

   
            double area1 = CalculateArea(); 
            double area2 = CalculateArea(5.0); 
            double area3 = CalculateArea(3.0, 4.0); 
            Console.WriteLine($"Area 1: {area1}, Area 2: {area2}, Area 3: {area3}");

           
            int sum1 = AddNumbers(3, 4); 
            int sum2 = AddNumbers(1, 2, 3); 
            Console.WriteLine($"Sum 1: {sum1}, Sum 2: {sum2}");

            
            Book book1 = new Book("The Great Book");
            Book book2 = new Book("Another Book", "John Doe");

            Console.WriteLine($"Book 1: {book1.Title}, Author: {book1.Author}");
            Console.WriteLine($"Book 2: {book2.Title}, Author: {book2.Author}");



            MyList<int> intList = new MyList<int>();
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            Console.WriteLine("Integer List:");
            intList.Display();

            
            MyList<string> stringList = new MyList<string>();
            stringList.Add("Sami Ullah Saleem");
            stringList.Add("Kabeer Ali");
            stringList.Add("Shahzada Tayyab Tanveer");
            Console.WriteLine("\nString List:");
            stringList.Display();



            int[] intArray = { 1, 2, 3, 4, 5 };
            double[] doubleArray = { 1.5, 2.5, 3.5, 4.5, 5.5 };
            string[] stringArray = { "Hello", "World" };

            Console.WriteLine("Sum of integers: " + Sum(intArray));
            Console.WriteLine("Sum of doubles: " + Sum(doubleArray));

            //Console.WriteLine("Sum of strings: " + Sum(stringArray)); Un comment it to see it's functionality

            
            studentDatabase.Add(101, "Alice");
            studentDatabase.Add(102, "Bob");
            studentDatabase.Add(103, "Charlie");
            studentDatabase.Add(104, "David");

            while (true)
            {
                Console.WriteLine("\nStudent Database Management System");
                Console.WriteLine("1. View the student database");
                Console.WriteLine("2. Search for a student by ID");
                Console.WriteLine("3. Update a student's name");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice (1-4): ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ViewStudentDatabase();
                            break;
                        case 2:
                            SearchStudentByID();
                            break;
                        case 3:
                            UpdateStudentName();
                            break;
                        case 4:
                            Console.WriteLine("Exiting the program.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            string wait = Console.ReadLine();


        }

       
        static void Greet(string greeting = "Hello", string name = "World")
        {
            Console.WriteLine($"{greeting}, {name}!");
        }

       
        static double CalculateArea(double length = 1.0, double width = 1.0)
        {
            return length * width;
        }

        static int AddNumbers(int num1, int num2)
        {
            return num1 + num2;
        }
        static int AddNumbers(int num1, int num2, int num3 = 0)
        {
            return num1 + num2 + num3;
        }
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static T Sum<T>(T[] array)
        {
            if (typeof(T).IsPrimitive)
            {
                dynamic sum = default(T);
                foreach (var item in array)
                {
                    sum += item;
                }
                return sum;
            }
            else
            {
                throw new Exception("Unsupported data type");
            }
        }

        static void ViewStudentDatabase()
        {
            Console.WriteLine("\nStudent Database:");
            foreach (var student in studentDatabase)
            {
                Console.WriteLine($"Student ID: {student.Key}, Name: {student.Value}");
            }
        }

        // Search for a student by ID
        static void SearchStudentByID()
        {
            Console.Write("Enter the student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentID))
            {
                if (studentDatabase.ContainsKey(studentID))
                {
                    string studentName = studentDatabase[studentID];
                    Console.WriteLine($"Student ID: {studentID}, Name: {studentName}");
                }
                else
                {
                    Console.WriteLine("Student ID not found in the database.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }
        }

        // Update a student's name
        static void UpdateStudentName()
        {
            Console.Write("Enter the student ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int studentID))
            {
                if (studentDatabase.ContainsKey(studentID))
                {
                    Console.Write($"Enter the new name for student ID {studentID}: ");
                    string newName = Console.ReadLine();
                    studentDatabase[studentID] = newName;
                    Console.WriteLine($"Student ID {studentID} updated with the new name: {newName}");
                }
                else
                {
                    Console.WriteLine("Student ID not found in the database.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }
        }
    }


}

    class Book
    {
        public string Title { get; }
        public string Author { get; }

        public Book(string title, string author = "Unknown")
        {
            Title = title;
            Author = author;
        }
    }



    class MyList<T>
    {
        private List<T> elements;

        public MyList()
        {
            elements = new List<T>();
        }

        
        public void Add(T item)
        {
            elements.Add(item);
        }

       
        public bool Remove(T item)
        {
            return elements.Remove(item);
        }

        public void Display()
        {
            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }
        }
    }