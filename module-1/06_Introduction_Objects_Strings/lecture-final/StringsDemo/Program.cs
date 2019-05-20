using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character. {0} and {1}", name[0], name[name.Length - 1]);
            Console.WriteLine("First and Last Character. {0} and {1}", name.Substring(0, 1), name.Substring(name.Length-3, 3));

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine("First 3 characters: {0}", name.Substring(0, 3));

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine("FirstLast 3 characters: {0}{1}", name.Substring(0,3), name.Substring(name.Length - 3));

            // 4. What about the last word?
            // Output: Lovelace

            int spaceIndex = name.LastIndexOf(" ");
            Console.WriteLine("Last Word: '{0}'", name.Substring(spaceIndex+1));

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            Console.WriteLine("Contains \"Love\": {0}", name.Contains("Love"));

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            Console.WriteLine("Index of \"lace\": {0} ", name.IndexOf("lace"));

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            int count = 0;
            string lowerAda = name.ToLower();

            for (int i = 0; i < name.Length; i++)
            {
                //if (name.Substring(i, 1).ToLower() == "a")
                //{
                //    count++;
                //}

                if (name[i] == 'a' || name[i] == 'A')
                {
                    count++;
                }
            }
            Console.WriteLine("Number of \"a's\": {0}", count);

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            string fullName = name.Replace("Ada", "Ada, Countess of Lovelace");
            Console.WriteLine(fullName);

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (name == null  || name == "")
            {
                Console.WriteLine("\"All done.\"");
            }

            Console.ReadLine();
        }
    }
}