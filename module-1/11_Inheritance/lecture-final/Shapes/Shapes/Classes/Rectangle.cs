using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Classes
{
    class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height, string color, bool isFilled)
        {
            this.Width = width;
            this.Height = height;
            this.Color = color;
            this.IsFilled = isFilled;
        }

        public override void Draw()
        {
            SetConsoleColor();

            #region Do the math to calculate which symbols to draw
            double thickness = .8;
            char symbol = '*';
            char fillSymbol = '*';

            // Do the math to calculate which symbols to draw
            for (int y = 0; y < this.Height; y++)
            {
                for (double x = 0; x < this.Width; x += .4)
                {
                    if (y < thickness || y >= (this.Height - 1 - thickness) ||
                        x < thickness || x >= (this.Width - thickness))
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        if (this.IsFilled &&
                            y >= thickness && y < (this.Height - thickness) &&
                        x >= thickness && x < (this.Width - thickness)
                            )
                        {
                            Console.Write(fillSymbol);

                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
            #endregion

            ResetConsoleColor();
        }

        public override int Area()
        {
            return this.Height * this.Width;
        }

    }
}
