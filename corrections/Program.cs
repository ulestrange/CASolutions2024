/*
 * Name : Samuel Kocych
 * Date : 12/02/2024
 * Descriptiopn
 * 
 * CA1
 */

namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declare var
            int seatsOccupied = 0;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //// Q1a
            //decimal result1 = CalculateTicketPrice(12, "return");
            //Console.WriteLine(result1);

            //// Q1b
            //decimal result2 = ApplyDiscount(11, "travelcard");
            //Console.WriteLine(result2);

            // Q2
            // declare var
            int menu = 0, ticketsSold = 0;
            decimal totalMoneyTaken = 0;

            // input
            while (menu != 4)
            {
                // input
                Console.WriteLine("Ballin Buses Main Menu\n");
                Console.WriteLine("1. Buy ticket");
                Console.WriteLine("2. Check in return ticket");
                Console.WriteLine("3. Print journey report");
                Console.WriteLine("4. Exit");
                menu = int.Parse(Console.ReadLine());

                if (menu == 1)
                {
                    BuyTicket(seatsOccupied, totalMoneyTaken, ticketsSold);
                }
                else if (menu == 2)
                {
                    CheckInExistingTicket(seatsOccupied);
                }
                else if (menu == 3)
                {
                    PrintJourneyReport(ticketsSold, totalMoneyTaken, seatsOccupied);
                }
            }
        }
        static decimal CalculateTicketPrice(decimal basePrice, string ticketType)
        {
            // declare var
            ticketType = ticketType.ToLower();

            // process
            switch (basePrice)
            {
                case < 0:
                    return -1;
            }
            switch (ticketType)
            {
                case "return":
                    return basePrice * 1.5m;
                default:
                    return basePrice;
            }
        }
        static decimal ApplyDiscount(decimal price, string customerType)
        {
            // declare var
            customerType = customerType.ToLower();

            // process
            switch (price)
            {
                case < 0:
                    return -1;
            }
            switch (customerType)
            {
                case "child":
                    return price * 0.5m;
                case "student":
                    return price * 0.7m;
                case "oap":
                    return 0;
                default:
                    return price;
            }
        }
        static private void BuyTicket(int seatsOccupied, decimal totalMoneyTaken, int ticketsSold)
        {
            // declare var
            string ticketType, customerType;
            int price = 10;

            // input
            Console.Write("Select a ticket type: ");
            ticketType = Console.ReadLine();
            Console.Write("Select the type of customer you are: ");
            customerType = Console.ReadLine();

            // process
            decimal result = CalculateTicketPrice(price, ticketType);
            decimal result2 = ApplyDiscount(result, customerType);

            // output
            Console.WriteLine($"Ballin-Sligo:{customerType} {ticketType}: {result2:c2}");

            seatsOccupied++;
            totalMoneyTaken += result2;
            ticketsSold++;
        }
        static private void CheckInExistingTicket(int seatsOccupied)
        {
            int remainingSeats = 10 - seatsOccupied;

            // process
            if (remainingSeats < 1)
            {
                Console.WriteLine("Bus Full");
            }
            else
            {
                seatsOccupied++;
                Console.WriteLine($"Remaining seats: {remainingSeats - 1}");
            }
        }
        static private void PrintJourneyReport(int ticketsSold, decimal moneyTaken, int seatsOccupied)
        {
            Console.WriteLine($"Number of tickets sold: {ticketsSold}");
            Console.WriteLine($"Money taken: {moneyTaken}");
            Console.WriteLine($"Total seats occupied: {seatsOccupied}");
        }
    }
}