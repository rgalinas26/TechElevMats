using Shapes.Classes;
using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"#     #                                                               #####                                     ### ");
            Console.WriteLine(@"#  #  # ###### #       ####   ####  #    # ######    #####  ####     #     # #    #   ##   #####  ######  ####  ### ");
            Console.WriteLine(@"#  #  # #      #      #    # #    # ##  ## #           #   #    #    #       #    #  #  #  #    # #      #      ### ");
            Console.WriteLine(@"#  #  # #####  #      #      #    # # ## # #####       #   #    #     #####  ###### #    # #    # #####   ####   #  ");
            Console.WriteLine(@"#  #  # #      #      #      #    # #    # #           #   #    #          # #    # ###### #####  #           #     ");
            Console.WriteLine(@"#  #  # #      #      #    # #    # #    # #           #   #    #    #     # #    # #    # #      #      #    # ### ");
            Console.WriteLine(@" ## ##  ###### ######  ####   ####  #    # ######      #    ####      #####  #    # #    # #      ######  ####  ### ");

            //Shape shape1 = new Shape();
            //Rectangle rect = new Rectangle(10, 5, "Red", true);
            //Circle circle = new Circle(8, "Blue", false);

            //Console.WriteLine($"The area of the Shape is {shape1.Area()}");
            //Console.WriteLine($"The area of the Rectangle is {rect.Area()}");
            //Console.WriteLine($"The area of the Circle is {circle.Area()}");

            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Shape());
            shapes.Add(new Rectangle(10, 5, "Red", true));
            shapes.Add(new Circle(8, "Blue", false));
            shapes.Add(new Circle(12, "Cyan", true));
            shapes.Add(new Circle(14, "Magenta", false));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"The area of the shape is {shape.Area()}");
                shape.Draw();
            }
            Console.ReadKey();
        }
    }
}
