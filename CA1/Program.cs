
namespace CA1_Semester2
{/*     Name: Ryan Crumley
  *     Date: 12/02/2024
  */
    internal class Program
    {
        static decimal costOfTicket = 0;

        
        static void Main(string[] args)
        {
            char c = 'A';
            char b = (char)(c + 10);
            Console.WriteLine(b);
        }
        static private void Question1()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string choice = "", customerType;
            decimal basePrice = 0, finalCost = 0;

            choice = choice.ToUpper();
            choice = choice.ToLower();

            customerType = choice.ToUpper();
            customerType = choice.ToLower();

            Console.Write($"Please enter your ticket type(Return or Single): ");
            choice = Console.ReadLine();

            Console.Write("Please enter the base price of the ticket: ");
            basePrice = int.Parse(Console.ReadLine());


            Console.Write("Please enter what kind of person you are (Child, Student, OAP): ");
            customerType = Console.ReadLine();
            CalculateTicketPrice(basePrice, choice);
            /*
            Console.WriteLine(CalculateTicketPrice(10, "Single") == 10);
            Console.WriteLine(CalculateTicketPrice(11, "Return") == 16.5m);
            Console.WriteLine(CalculateTicketPrice(-9, "Single") == -1);
            Console.WriteLine(CalculateTicketPrice(10,"")==10);
            Console.WriteLine(CalculateTicketPrice(12,"return")== 18);*/

            Console.Write($"This is the cost of the ticket before any discounts: ");

            ApplyDiscount(costOfTicket, customerType);
            Console.WriteLine(ApplyDiscount(10, "Adult") == 10);
            Console.WriteLine(ApplyDiscount(11, "Child") == 5.5m);
            Console.WriteLine(ApplyDiscount(12, "Student") == 8.4m);
            Console.WriteLine(ApplyDiscount(10, "OAP") == 0);
            Console.WriteLine(ApplyDiscount(10, "oap") == 0);
            Console.WriteLine(ApplyDiscount(10, "travelcard") == 10);
            Console.WriteLine(ApplyDiscount(10, "OAP") == -1);
            Console.WriteLine(ApplyDiscount(10, "") == 10);


            Console.WriteLine($"This is the final cost of the ticket: {costOfTicket:c}");


        }
        static decimal CalculateTicketPrice(decimal basePrice, string ticketType)
        {  // VARS

            ticketType = "";
            ticketType = ticketType.ToUpper();
            ticketType = ticketType.ToLower();

            Console.OutputEncoding = System.Text.Encoding.UTF8; // ENCODING FOR EURO

            // CHECKS

            if (basePrice > 0)
            {
                if (ticketType == "Single")
                {
                    costOfTicket = basePrice;
                }
                else if (ticketType == "Return")
                {
                    costOfTicket = (basePrice * 1) + (basePrice / 2);
                }
                else if (ticketType == "")
                {
                    costOfTicket = basePrice;
                }

            }
            else Console.WriteLine("-1");

            return (costOfTicket);
        }
        static decimal ApplyDiscount(decimal price, string customerType)
        {
            if (price >= 0)
            {
                if (customerType == "Child")
                {
                    costOfTicket = price / 2;
                    Console.WriteLine($"Your ticket costs {price:C}");
                }
                else if (customerType == "Student")
                {
                    costOfTicket = (price / 100 * 70);
                    Console.WriteLine($"Your ticket costs {price:c}");
                }
                else if (customerType == "OAP")
                {
                    costOfTicket = 0;
                    Console.WriteLine($"Your ticket costs {price:c}");
                }
            }
            else if (price < 0)
            {
                Console.WriteLine("-1");
            }
            return (costOfTicket);
        }
        static void Question2()
        {
            const int numberOfSeats = 10;
            if (numberOfSeats > 0)
            {

            }
        }

    }
}