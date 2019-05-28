using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Classes
{
    /// <summary>
    /// A two-dimensional shape that can be drawn on the screen
    /// </summary>
    class Shape
    {
        public Shape()
        {
            this.color = ConsoleColor.White;
            this.IsFilled = false;
        }

        public bool IsFilled { get; set; }

        // A place to save the current color for restoring after the draw
        private ConsoleColor savedColor = ConsoleColor.White;

        protected ConsoleColor color;
        public string Color
        {
            get
            {
                return color.ToString();
            }
            set
            {
                color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), value);
            }
        }

        protected void SetConsoleColor()
        {
            this.savedColor = Console.ForegroundColor;
            Console.ForegroundColor = this.color;
        }

        protected void ResetConsoleColor()
        {
            Console.ForegroundColor = savedColor;
        }

        virtual public void Draw()
        {
            SetConsoleColor();
            Console.WriteLine("*** Nothing to Draw! ***");
            ResetConsoleColor();

        }

        virtual public int Area()
        {
            return 0;
        }
    }
}

