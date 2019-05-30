using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Cow : FarmAnimal
    {
        public Cow() : base("COW")
        { }

        public override string MakeSoundOnce()
        {
            return "MOO";
        }

        public override string MakeSoundTwice()
        {
            return "MOO MOO";
        }
    }
}
