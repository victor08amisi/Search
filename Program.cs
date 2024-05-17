using System;
using System.Globalization;

namespace Search
{
    class Program
    {
        public List<int> Numbers = new List<int>() {17, 166, 288, 324, 531, 792, 946, 157, 276, 441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227, 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396, 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784, 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450, 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150};
        //Method to get integer from user
        public int EnterInteger()
        {
            string userOption;
            int userOption2;
            while (true)
            {
                try
                {
                    Console.Write("Enter an integer to search: ");
                    userOption = Console.ReadLine();
                    userOption2 = Convert.ToInt32(userOption);
                    return userOption2;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " +  e.Message);
                    Console.WriteLine("Please follow the instructions next time!");
                    Console.Write("");
                }
            }
        }
        //Method to get ranges
        public void GetRange()
        {
            //Create a new list and sort it 
            List<int> Numbers2 = new List<int>(Numbers);
            Numbers2.Sort();
            string lowerBound1;
            string upperBound1;
            int lowerBound2 = 0;
            int upperBound2 = Numbers.Count - 1;
            Console.WriteLine("");
            Console.WriteLine("//// Range Search ////");
            Console.WriteLine("");
            //---------------------
            Console.Write("Enter the lower bound: ");
            lowerBound1 = Console.ReadLine();
            Console.WriteLine("");
            //---------------------
            Console.Write("Enter the upper bound: ");
            upperBound1 = Console.ReadLine();
            Console.WriteLine("");
            try
            {
                lowerBound2 = string.IsNullOrEmpty(lowerBound1) ? 0 : Convert.ToInt32(lowerBound1);
                //-------------------
                upperBound2 = string.IsNullOrEmpty(upperBound1) ? Numbers2[Numbers.Count - 1] : Convert.ToInt32(upperBound1);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " +  e.Message);
                Console.WriteLine("Please follow the instructions next time!");
                Console.Write("");
                GetRange();
            }
            Console.WriteLine("lowerBound: " + lowerBound2);
            Console.WriteLine("UpperBound: " + upperBound2);
            List<int> numbersToShow = new List<int>();
            int inBetweenCounter = 0;
            foreach (var item in Numbers2)
            {
                if (item >= lowerBound2 && item < upperBound2)
                {
                    inBetweenCounter++;
                    numbersToShow.Add(item);
                    Console.WriteLine(item);
                }
                
            }
            Console.WriteLine(
                $"The search found {inBetweenCounter} integers greater than {lowerBound2} and less than {upperBound2}");
            Console.WriteLine("");
        }
        //Create a method that will ask the user what kind of operation they want
        public void OperationMethod()
        {
            Console.Write("Choose an operation (1 = Basic search, 2 = Range Search, 3 = Exit): ");
            string userInput = Console.ReadLine()!;
            switch (userInput.Trim())
            {
                case "1":
                    Console.WriteLine("");
                    Console.WriteLine("//// Basic Search ////");
                    Console.WriteLine("");
                   int returnInt =  EnterInteger();
                   int searchInt = SearchMethod(returnInt);
                   if (searchInt == -1)
                   {
                       Console.WriteLine("");
                       Console.WriteLine($"The integer {returnInt} is not found.");
                       Console.WriteLine("");
                       OperationMethod();
                   }
                    Console.WriteLine("");
                   Console.WriteLine($"The integer {Numbers[searchInt]} is found at index {searchInt}");
                   Console.WriteLine("");
                   OperationMethod();
                    break;
                case "2":
                    GetRange();
                    OperationMethod();
                    
                    break;
                case "3":
                    Console.WriteLine("Exiting the application....");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Follow the rules!");
                    Console.WriteLine("");
                    OperationMethod();
                    break;
                

            }
            


        }
        //Binary Search method
        public int SearchMethod(int numToSearch)
        {
            return Numbers.IndexOf(numToSearch);
        }

        static void Main(string[] args)
        {
            Program myObj = new Program();
            //Sort the List of Integers
            myObj.OperationMethod();
        }
    }
}

