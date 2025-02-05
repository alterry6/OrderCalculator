using System;

namespace SweatshirtOrdering
{
    // The Program calculates the total cost of a sweatshirt order, including personalization and shipping.
    class OrderCalculator
    {
        // Prices and fees
        private const double SweatshirtPrice = 25.99;    // Price of one sweatshirt
        private const double PersonalizationCost = 4.00; // Price for each added personalization
        private const double ShippingCost = 6.20;        // Shipping fee
        private const double TransactionFee = 0.30;      // Fee per sweatshirt

        private int _sweatshirts;      // Number of sweatshirts ordered
        private int _personalizations; // Number of personalizations added

        // Get the number of sweatshirts and personalizations from the user
        public void CollectOrderDetails()
        {
            _sweatshirts = PromptForInput("How many sweatshirts would you like to order?", 1);
            _personalizations = PromptForInput("How many personalizations would you like to add?", 0);
        }

        // Calculate the total cost of the order
        public double CalculateTotalCost()
        {
            double sweatshirtCost = _sweatshirts * SweatshirtPrice;
            double personalizationCost = _personalizations * PersonalizationCost;
            double transactionFees = _sweatshirts * TransactionFee;

            return sweatshirtCost + personalizationCost + transactionFees + ShippingCost;
        }

        // Display the total cost of the order to the user
        public void DisplayTotalCost()
        {
            double total = CalculateTotalCost();
            Console.WriteLine($"\nYour total order cost is: ${total:F2}");
        }

        // Get and validate numeric input from the user
        private int PromptForInput(string message, int minimumValue)
        {
            int value;
            Console.Write($"{message} ");
            while (!int.TryParse(Console.ReadLine(), out value) || value < minimumValue)
            {
                Console.Write($"Please enter a valid number (minimum {minimumValue}): ");
            }
            return value;
        }
    }

    class Program
    {
        // Start the program
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Sweatshirt Ordering System!");

            var calculator = new OrderCalculator();
            calculator.CollectOrderDetails();
            calculator.DisplayTotalCost();

            Console.WriteLine("\nThank you for your order! Press any key to exit...");
            Console.ReadKey();
        }
    }
} 