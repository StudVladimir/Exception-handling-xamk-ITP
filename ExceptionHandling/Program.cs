using System;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicExceptionHandling();
            MultipleExceptionTypes();
            FinalyBlockUsage();
            CustomExceptionClass();
            ExceptionPropagation();
            UsingThrowAndCatch();
            Console.ReadLine();
        }

        static void BasicExceptionHandling()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Convert the input to an integer using int.Parse().
            // Use a try-catch block to handle FormatException if the user enters a non-numeric value.
            // Display an error message in case of an exception.
            // Output the input if correct
            int num=0;
            bool exceptionOccurred=false;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                exceptionOccurred = true;
            }
            if (exceptionOccurred == false)
                Console.WriteLine(num);
        }

        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Include a catch block for OverflowException to handle cases where the number is too large or small for an int.
            // Display appropriate error messages for different exceptions.
            int num = 0;
            bool exceptionOccurred = false;
            string str = Console.ReadLine();
            try
            {
                num = int.Parse(str);
            }
            catch (OverflowException e)
            {
                if (str[0] == '-')
                    Console.WriteLine("The number is too small");
                else
                    Console.WriteLine("The number is too large");
                exceptionOccurred = true;
            }
            if (exceptionOccurred == false)
                Console.WriteLine(num);
        }

        static void FinalyBlockUsage()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Add a finally block to the program.
            // Use the finally block to display a message whether an exception was caught or not.
            bool exceptionOccurred = false;
            try
            {
                int num = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                exceptionOccurred = true;
            }
            finally
            {
                if (exceptionOccurred == true) Console.WriteLine("Exception was caught");
                else Console.WriteLine("Exception was not caught");
            }
        }

        // Class for custom exception type
        class NegativeNumberException : ApplicationException
        {
            public NegativeNumberException(string message) : base(message)
            {

            }
        }

        static void CustomExceptionClass()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Modify your number input program to throw NegativeNumberException if the user enters a negative number.
            // Handle this exception in a separate catch block and display an appropriate message.
            int num = 0;
            bool exceptionOccurred = false;
            try
            {
                num = int.Parse(Console.ReadLine());
                if (num < 0)
                {
                    throw new NegativeNumberException("Negative number is not valid!");
                }
            }
            catch (NegativeNumberException e)
            {
                Console.WriteLine(e.Message);
                exceptionOccurred = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                exceptionOccurred = true;
            }
            if (exceptionOccurred == false)
                Console.WriteLine(num);
        }

        static void ExceptionPropagation()
        {    
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumber that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // In this function, call CheckNumber inside a try block and handle the exception.
            
            int num=0;
            bool exceptionOccurred = false;
            try
            {
                num = int.Parse(Console.ReadLine());
                CheckNumber(num);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                exceptionOccurred = true;
            }
            if (exceptionOccurred == false)
                Console.WriteLine(num);
        }

        // NOTE: You can implement the CheckNumber here
        static void CheckNumber(int num)
        {
            if (num > 100)
            {
                throw new ArgumentOutOfRangeException("The number must not be greater than 100!");
            }
        }

        static void UsingThrowAndCatch()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumberWithLogging that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // Modify the CheckNumberWithLogging function to log the exception message before throwing it.
            // In this function, catch the exception in the main program and display the logged message.
            int num = 0;
            bool exceptionOccurred = false;
            try
            {
                num = int.Parse(Console.ReadLine());
                CheckNumberWithLogging(num);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                exceptionOccurred = true;
            }
            if (exceptionOccurred == false)
                Console.WriteLine(num);
        }

        // NOTE: You can implement the CheckNumberWithLogging here
        static void CheckNumberWithLogging(int num)
        {
            if (num > 100)
            {
                Console.WriteLine("LOGGED MESSAGE: The number must not be greater than 100!");
                throw new ArgumentOutOfRangeException("The number must not be greater than 100!");
            }
        }
    }
}