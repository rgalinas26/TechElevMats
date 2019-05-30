using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public interface ISellable
    {
        decimal Weight { get; set; }
        decimal Price { get; set; }
        void Sell();
    }
}
