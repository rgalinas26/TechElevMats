using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LectureExample example = new LectureExample();

            int number = example.ReturnNotOne();
            Console.WriteLine(number);

            double doubleNumber = example.ReturnNotHalf();
            Console.WriteLine(doubleNumber);

            string name = example.ReturnName();
            Console.WriteLine(name);

            double singleValue = 10;
            double product = example.ReturnDoubleOf(singleValue);
            Console.WriteLine(product);

            int age = 25;
            string category = example.ReturnAdultOrMinor(age);
            Console.WriteLine("Age " + age + " is a " + category);

            age = 17;
            category = example.ReturnAdultOrMinor(age);
            Console.WriteLine("Age " + age + " is a " + category);

            age = 18;
            category = example.ReturnAdultOrMinor(age);
            Console.WriteLine("Age " + age + " is a " + category);

            Console.ReadKey();
        }
    }
}
