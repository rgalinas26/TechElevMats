using Lecture.Farming;
using System;
using System.Collections.Generic;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let's try singing about a Farm Animal
            FarmAnimal animal = new Horse();
            SingVerse(animal);

            // Let's create a couple more animals. Maybe a Pig, Dog, Cow, Chicken?
            // Can we swap out any animal in place here?
               
            // Put them all in a collection and sing the entire song

            // What if we wanted to sing about other things on the farm that were 
            // singable but not farm animals?
            // Can it be done? 

            Console.ReadLine();
        }

        static void SingVerse(FarmAnimal animal)
        {
            //
            // OLD MACDONALD
            //
            Console.WriteLine("Old MacDonald had a farm. ee aye ee aye oh");

            Console.WriteLine($"And on his farm there was a {animal.Name}. ee ay ee ay oh");
            Console.WriteLine($"With a {animal.MakeSoundTwice()} here and a {animal.MakeSoundTwice()} there.");
            Console.WriteLine($"Here a {animal.MakeSoundOnce()}, there a {animal.MakeSoundOnce()}, everywhere a {animal.MakeSoundTwice()}.");
            Console.WriteLine($"Old Macdonald had a farm. ee aye ee aye oh");
            Console.WriteLine();

        }
    }
}