using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Sheep : FarmAnimal
    {
        public Sheep() : base("SHEEP") { }

        public override string MakeSoundOnce()
        {
            return "BAA";
        }

        public override string MakeSoundTwice()
        {
            return "BAA BAA";
        }
    }
}
