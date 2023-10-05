using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignment_2
{

    class Program
    {
        static void tempCity(double temperature, string city)
        {
            Console.WriteLine($"The temperature in {city} is {temperature} degrees Celsius.");
        }

        static void ScoreSum()
        {
            int[] scores = { 85, 92, 78, 95, 89, 72, 88, 94, 90, 81 };
            int sum = 0;
            int i = 0;

            do
            {
                sum += scores[i];
                i++;
            } while (i < scores.Length);

            Console.WriteLine("Sum of test scores: " + sum);

        }

        static void maxValue()
        {

            int[] values = { 10, 25, 6, 42, 8, 55 };
            int max = int.MinValue;
            int i = 0;

            while (i < values.Length)
            {
                if (values[i] > max)
                {
                    max = values[i];
                }
                i++;
            }

            Console.WriteLine("Maximum value: " + max);

        }

        static void reverseArray(int[] array)
        {
            Array.Reverse(array);
            foreach (int number in array)
            {
                Console.WriteLine(number);
            }
        }

        static void intBoxing()
        {
            int x = 42;
            object boxedX = x; // Boxing an integer into an object
            int y = (int)boxedX; // Unboxing an objecy to an integer
            Console.WriteLine("Unboxed value: " + y);

        }

        static void doubleBoxing()
        {
            double x = 3.14159;
            object ox1 = x;
            double y = (double)ox1;
            Console.WriteLine("Unboxed Value" + y);
        }
        static void Main(string[] args)
        {

            // Task 1
            Console.WriteLine("Task 1\n");
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();

            string fullName = firstName + " " + lastName;
            Console.WriteLine("Full Name: " + fullName);



            // Task 2
            Console.WriteLine("\nTask 2\n");
            Console.WriteLine("Enter any sentence");
            string sentence = Console.ReadLine();
            string lastFiveChars = sentence.Substring(sentence.Length - 5);
            Console.WriteLine("Last 5 characters: " + lastFiveChars);

            // Task 3

            Console.WriteLine("\nTask 3\n");
            Console.Write("Enter the current temperature: ");
            double temperature = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the name of your city: ");
            string city = Console.ReadLine();
            tempCity(temperature, city);

            // Task 4
            Console.WriteLine("\nTask 4\n");
            int[] numbers = { 1, 2, 3, 4, 5 };

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }


            // Task 5
            Console.WriteLine("\nTask 5\n");
            string[] fruits = { "Apple", "Banana", "Orange", "Grapes" };

            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine(fruits[i]);
            }

            string[] colors = { "Red", "Blue", "Green" };

            foreach (string color in colors)
            {
                Console.Write(color + ", ");
            }

            // Task 6
            Console.WriteLine("\nTask 6\n");
            ScoreSum();

            // Task 7
            Console.WriteLine("\nTask 7\n");
            maxValue();

            // Task 8
            Console.WriteLine("\nTask 8\n");
            int[] arr1 = { 1, 2, 3, 4, 5 };
            reverseArray(arr1);

            // Task 9
            Console.WriteLine("\nTask 9\n");
            intBoxing();

            doubleBoxing();


            // Task 10 (a)
            Console.WriteLine("\nTask 10\n");
            int[] num = { 2, 4, 6, 8, 10 };

            foreach (object obj in num)
            {
                int original = (int)obj;
                int squared = original * original;
                Console.WriteLine($"Original: {original}, Squared: {squared}");
            }

            // (b)
            List<object> mixedList = new List<object>();

            mixedList.Add(42);
            mixedList.Add(3.14);
            mixedList.Add('A');
            mixedList.Add("Hello");

            foreach (object item in mixedList)
            {
                Console.WriteLine($"Value: {item}, Type: {item.GetType()}");

            }
            // Task 11 
            Console.WriteLine("\nTask 11\n");
            // (a)
            dynamic myVariable = 42;
            Console.WriteLine(myVariable);
            myVariable = "Hello, Dynamic!";
            Console.WriteLine(myVariable);

            // (b)

            dynamic myVariable2 = 42;
            Console.WriteLine(myVariable2.GetType());

            myVariable2 = 3.14;
            Console.WriteLine(myVariable2.GetType());

            myVariable2 = DateTime.Now;
            Console.WriteLine(myVariable2.GetType());

            myVariable2 = "Hello, Dynamic!";
            Console.WriteLine(myVariable2.GetType());


            string wait = Console.ReadLine();
        }
    }
}

