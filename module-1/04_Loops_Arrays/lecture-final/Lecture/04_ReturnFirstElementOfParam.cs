using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureProblem
    {

        /*
        4. Return the first element of the array from the parameters
            TOPIC: Accessing Array Elements
        */
        public int ReturnFirstElementOfParam(int[] passedInArray)
        {
            if (passedInArray.Length > 0)
            {
                return passedInArray[0];
            }
            return 0;
        }

        /*
        4b. Set the first element in the array to 100.     
            TOPIC: Setting Array Elements
        */
        public void SetFirstElement(int[] passedInArray)
        {
            if (passedInArray.Length > 0)
            {
                passedInArray[0] = 100;
            }
        }
    }
}
