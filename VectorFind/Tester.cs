using System;

namespace Vector
{
    class Tester
    {

        private static bool CheckIntSequence(int[] certificate, Vector<int> vector)
        {
            if (certificate.Length != vector.Count) return false;
            for (int i = 0; i < certificate.Length; i++)
            {
                if (certificate[i] != vector[i]) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Vector<int> vector = null;
            string result = "";

            // test 1
            try
            {
                Console.WriteLine("\nTest A: Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                vector = new Vector<int>(50);
                Console.WriteLine(" :: SUCCESS");
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 2
            try
            {
                Console.WriteLine("\nTest B: Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5");
                vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8); vector.Add(5); vector.Add(3); vector.Add(5);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 3
            try
            {
                Console.WriteLine("\nTest C: Run a sequence of operations: ");

                Console.WriteLine("Find number that is greater than 3 and less than 7, i.e. 'e => e > 3 && e < 7'");
                if (vector.Find(e => e > 3 && e < 7) == 6) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("The right number is 6");

                Console.WriteLine("Find number that is either 10 or 8, i.e. 'e => e == 10 || e == 8'");
                if (vector.Find(e => e == 10 || e == 8) == 8) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("The right number is 8");

                Console.WriteLine("Find number that is not 2, i.e. 'e => e != 2'"); ;
                if (vector.Find(e => e != 2) == 6) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("The right number is 6");

                Console.WriteLine("Find number that is greater than 20, i.e. 'e => e > 20'"); ;
                if (vector.Find(e => e > 20) == 0) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("There is no such number. The right number is 0 as zero is the 'default(T)' value for type 'int'");

                Console.WriteLine("Find the first odd number, i.e. 'e => (e % 2) == 1'"); ;
                if (vector.Find(e => (e % 2) == 1) == 5) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("The right number is 5");

                Console.WriteLine("Find the number that is divided by 11 without remainder, i.e. 'e => (e % 11) == 0'");
                if (vector.Find(e => (e % 11) == 0) == 0) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("There is no such number. The right number is 0 as zero is the 'default(T)' value for type 'int'");

                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 4
            try
            {
                Console.WriteLine("\nTest D: Find the minimum of the sequence");
                int min = vector.Min();
                if (min != 1) throw new Exception(min + " is an invalid minimum number of the sequence");
                Console.WriteLine(" :: SUCCESS");
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 5
            try
            {
                Console.WriteLine("\nTest E: Find the maximum of the sequence");
                int max = vector.Max();
                if (max != 8) throw new Exception(max + " is an invalid maximum number of the sequence");
                Console.WriteLine(" :: SUCCESS");
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 6
            try
            {
                Console.WriteLine("\nTest F: Find all numbers that are greater than 3 and less than 7, i.e. 'e => e > 3 && e < 7'");
                if (!CheckIntSequence(new int[] { 6, 5, 5, 5, 5 }, vector.FindAll(e => e > 3 && e < 7))) throw new Exception("Operation returns an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 7
            try
            {
                Console.WriteLine("\nTest G: Find all numbers that is either 10 or 8, i.e. 'e => e == 10 || e == 8'");
                if (!CheckIntSequence(new int[] { 8, 8 }, vector.FindAll(e => e == 10 || e == 8))) throw new Exception("Operation returns an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 8
            try
            {
                Console.WriteLine("\nTest H: Find all odd numbers, i.e. 'e => (e % 2) == 1'");
                if (!CheckIntSequence(new int[] { 5, 5, 1, 5, 3, 5 }, vector.FindAll(e => (e % 2) == 1))) throw new Exception("Operation returns an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "H";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 9
            try
            {
                Console.WriteLine("\nTest I: Find all odd numbers that are divided by 11 without remainder, i.e. 'e => (e % 11) == 0'");
                if (!CheckIntSequence(new int[] { }, vector.FindAll(e => (e % 11) == 0))) throw new Exception("Operation returns an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "I";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 10
            try
            {
                Console.WriteLine("\nTest J: Remove all even numbers, i.e. 'e => (e % 2) == 0'");
                int check = vector.RemoveAll(e => (e % 2) == 0);
                if (check != 4) throw new Exception(check + " is a wrong number of removed integers");
                if (!CheckIntSequence(new int[] { 5, 5, 1, 5, 3, 5 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}
