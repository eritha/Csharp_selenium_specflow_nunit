using System;
using System.Linq;
using System.Text;

namespace Csharp_selenium_specflow_nunit.Utility
{
    public static class Generator
    {
        public static string GenerateEmail()
        {
            return RandomString(10) + "random@yopmail.com";
        }

        // Generate a random string builder with a given size    
        public static string RandomString(int size, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Generate a random string "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890" with a given length    
        public static string RandomString(int length)
        {
            string result = "";
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            try
            {
                result = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class Generator | Method RandomNumberWithRange | Exception desc : " + ex.Message);
            }
            return result;
        }

        // Generate a random password    
        public static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumberWithRange(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        //  Return a random number in a range <min, max>
        public static int RandomNumberWithRange(int Min, int Max)
        {
            int random = 0;
            Random r = new Random();
            try
            {
                random = r.Next(Min, Max);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class Generator | Method RandomNumberWithRange | Exception desc : " + ex.Message);
            }

            return random;
        }

        //  Return a random number less than <size>
        public static int RandomNumberLessThan(int size)
        {
            int random = 0;
            Random r = new Random();
            try
            {
                random = r.Next(size);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class Generator | Method RandomNumberLessThan | Exception desc : " + ex.Message);
            }

            return random;
        }

        public static int RandomNumber(int length)
        {
            int resultInt = 0;
            Random random = new Random();
            const string chars = "1234567890";
            try
            {
                resultInt = Int32.Parse(new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class Generator | Method RandomNumber | Exception desc : " + ex.Message);
            }

            return resultInt;
        }

        static void Main(string[] args)
        {
            // Create a StringBuilder that expects to hold 50 characters.
            // Initialize the StringBuilder with "ABC".
            StringBuilder sb = new StringBuilder("ABC", 50);

            // Append three characters (D, E, and F) to the end of the StringBuilder.
            sb.Append(new char[] { 'D', 'E', 'F' });

            // Append a format string to the end of the StringBuilder.
            sb.AppendFormat("GHI{0}{1}", 'J', 'k');

            // Display the number of characters in the StringBuilder and its string.
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

            // Insert a string at the beginning of the StringBuilder.
            sb.Insert(0, "Alphabet: ");

            // Replace all lowercase k's with uppercase K's.
            sb.Replace('k', 'K');

            // Display the number of characters in the StringBuilder and its string.
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
        }
    }
}