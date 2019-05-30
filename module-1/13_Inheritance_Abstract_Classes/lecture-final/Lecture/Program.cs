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
            // Put them all in a collection and sing the entire song
            List<ISingable> singableObjects = new List<ISingable>();

            Object obj = new Horse();

            singableObjects.Add(new Horse());
            // Let's create a couple more animals. Maybe a Pig, Dog, Cow, Chicken?
            singableObjects.Add(new Cow());
            singableObjects.Add(new Chicken(4.0M, 30.00M));
            singableObjects.Add(new Tractor());
            singableObjects.Add(new Pig(120M, 400.00M));
            singableObjects.Add(new Sheep());
            foreach (ISingable singable in singableObjects)
            {
                SingVerse(singable);

                if (singable is ISellable)
                {
                    ISellable thingToSell = (ISellable)singable;
                    thingToSell.Sell();
                }
            }

            // What if Farm Animals are to be sold? (add a weight and a price)

            // What if we want to sell Produce?

            Console.ReadLine();
        }

        static void SingVerse(ISingable singable)
        {
            //
            // OLD MACDONALD
            //
            Console.WriteLine("Old MacDonald had a farm. ee aye ee aye oh");

            Console.WriteLine($"And on his farm there was a {singable.Name}. ee ay ee ay oh");
            Console.WriteLine($"With a {singable.MakeSoundTwice()} here and a {singable.MakeSoundTwice()} there.");
            Console.WriteLine($"Here a {singable.MakeSoundOnce()}, there a {singable.MakeSoundOnce()}, everywhere a {singable.MakeSoundTwice()}.");
            Console.WriteLine($"Old Macdonald had a farm. ee aye ee aye oh");
            Console.WriteLine();

        }
    }
}