using System;

namespace Lab5_Part2
{
    // Custom exception class for password complexity
    public class PasswordComplexityException : Exception
    {
        public PasswordComplexityException() : base() { }
        public PasswordComplexityException(string message) : base(message) { }
        public PasswordComplexityException(string message, Exception inner) : base(message, inner) { }
    }

    class Program
    {
        static void ValidatePassword(string? password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new PasswordComplexityException("Password cannot be null or empty.");
            }

            if (password.Length < 8)
            {
                throw new PasswordComplexityException("Password must be at least 8 characters long.");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter a password: ");
                    string? password = Console.ReadLine();

                    ValidatePassword(password);
                    Console.WriteLine("Password is valid!");
                    break; // Exit loop if password is valid
                }
                catch (PasswordComplexityException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
        }
    }
}