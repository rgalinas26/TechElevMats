using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Tractor : ISingable
    {
        public string Name
        {
            get
            {
                return "TRACTOR";
            }
        }

        public string MakeSoundOnce()
        {
            return "CLANK";
        }

        public string MakeSoundTwice()
        {
            return "CLANK CLANK";
        }
    }
}
