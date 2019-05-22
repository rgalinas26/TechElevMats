using System;
using System.Collections.Generic;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //

            // Creating lists of integers
            List<int> numbers = new List<int>() { 10, 20, 30 };
            List<int> numbers2 = new List<int>() { 111, 222, 333 };

            // Creating lists of strings
            List<string> strings = new List<string>();


            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////
            bool areEqual = (numbers == numbers2);
            Console.WriteLine("Are the lists equal? {0}", areEqual);

            numbers = numbers2;
            numbers[1] = 500;


            areEqual = (numbers == numbers2);
            Console.WriteLine("Are the lists equal? {0}", areEqual);



            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            numbers.Add(444);
            numbers.Add(555);
            strings.Add("Red");
            strings.Add("Orange");

            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////
            int[] newNumbers = new int[] { 1000, 2000, 3000 };
            List<int> moreNumbers = new List<int>() { 1111, 2222 };
            numbers.AddRange(newNumbers);
            numbers.AddRange(moreNumbers);


            //////////////////
            // ACCESSING BY INDEX
            //////////////////
            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}




            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            foreach (int num in newNumbers)
            {
                Console.WriteLine(num);
            }

            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////
            strings.Add("green");
            strings.Add("Blue");

            foreach (string color in strings)
            {
                Console.WriteLine(color);
            }

            strings.Insert(2, "Yellow");
            Console.WriteLine("============================");
            foreach (string color in strings)
            {
                Console.WriteLine(color);
            }

            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////
            strings.Sort();
            Console.WriteLine("============================");
            foreach (string color in strings)
            {
                Console.WriteLine(color);
            }


            string[] colors = strings.ToArray();
            strings[0] = "Fire Engine Red";

            //strings.Reverse();
            Console.WriteLine("============================");
            foreach (string color in strings)
            {
                Console.WriteLine(color);
            }

            Console.WriteLine("============================");
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }




            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.


            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            Queue<string> checkoutQueue = new Queue<string>();

            checkoutQueue.Enqueue("Thomas");
            checkoutQueue.Enqueue("Bobby");
            checkoutQueue.Enqueue("El");


            Console.WriteLine("============================");
            foreach (string person in checkoutQueue)
            {
                Console.WriteLine(person);
            }

//            string p = checkoutQueue.Peek();
            string p = checkoutQueue.Dequeue();

            Console.WriteLine("============================");
            Console.WriteLine("The next person will be {0}", p);
            Console.WriteLine("============================");
            foreach (string person in checkoutQueue)
            {
                Console.WriteLine(person);
            }


            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 


            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 
            Stack<string> browserStack = new Stack<string>();
            browserStack.Push("http://www.google.com");
            browserStack.Push("https://docs.microsoft.com");
            browserStack.Push("https://techelevator.com");

            foreach (string website in browserStack)
            {
                Console.WriteLine(website);
            }

            //string url = browserStack.Pop();

            //Console.WriteLine("============================");
            //Console.WriteLine("Item popped: {0}", url);
            //Console.WriteLine("============================");

            //foreach (string website in browserStack)
            //{
            //    Console.WriteLine(website);
            //}

            while (browserStack.Count > 0)
            {
                Console.WriteLine("Next Item is {0}", browserStack.Pop());
            }

            ////////////////////
            // POPPING THE STACK
            ////////////////////


            Console.ReadLine();

        }
    }
}
