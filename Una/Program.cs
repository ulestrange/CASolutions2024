/*

 */
using System.Net.Sockets;

namespace CA1
{
    internal class Program
    {
        static int seats = 10;




       

        // Note: The three variables below are used to keep count
        // of the seats, tickets and money
        // by making them static they can be used and changed in any
        // of the methods.


        static int seatsOccupied;
        static decimal totalMoneyTaken;
        static int ticketsSold;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            #region tests
            //Q1 A
            //Console.WriteLine("Q1 A Test Results");
            //Console.WriteLine(CalculateTicketPrice(10, "Single") == 10); ;
            //Console.WriteLine(CalculateTicketPrice(11, "Return") == 16.5m); ;
            //Console.WriteLine(CalculateTicketPrice(-9, "Single") == -1); ;
            //Console.WriteLine(CalculateTicketPrice(10, "") == 10); ;
            //Console.WriteLine(CalculateTicketPrice(12, "return") == 18); ;

            ////Q1 B
            //Console.WriteLine("\nQ1 B Test Results");
            //Console.WriteLine(ApplyDiscount(10, "Adult") == 10); ;
            //Console.WriteLine(ApplyDiscount(11, "Child") == 5.5m); ;
            //Console.WriteLine(ApplyDiscount(12, "Student") == 8.4m); ;
            //Console.WriteLine(ApplyDiscount(10, "OAP") == 0); ;
            //Console.WriteLine(ApplyDiscount(10, "oap") == 0); ;
            //Console.WriteLine(ApplyDiscount(10, "travelcard") == 10); ;
            //Console.WriteLine(ApplyDiscount(-11, "OAP") == -1); ;
            //Console.WriteLine(ApplyDiscount(10, "") == 10); ;




            GetCustomerTypeFromUser();
            #endregion

            //Q2 Ballin Bus
            //Menu

            Console.WriteLine("\nQ2 Ballin Bus\n");
            int menuSelection = GetMenuChoice();


 
            while (menuSelection != 4 )
            {
                
                switch (menuSelection)                          //Switch statement for menu
                {
                    case 1:
                        if (seatsOccupied >= seats)             //Check if its full before going into buying ticket
                        {
                            Console.WriteLine("Bus Full");
                        }
                        else
                            BuyTicket();
                        break;
                    case 2:
                        checkInReturnTicket();
                        break;
                    case 3:
                        PrintJourneyReportToConsole();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("\nQ2 Ballin Bus\n");
                menuSelection = GetMenuChoice();
            }
        }

        /// <summary>
        /// If the basePrice is negative this method returns -1.
        /// If the ticket type is return this method returns the price of a return
        /// ticket. Otherwise is returns the price of a single ticket.
        /// </summary>
        /// <param name="basePrice"></param>
        /// <param name="ticketType"></param>
        /// <returns>Price of a ticket or -1</returns>
        static decimal CalculateTicketPrice(decimal basePrice, string ticketType)
        {
            decimal ticketCost = 0;
            ticketType = ticketType.ToLower();
            if (ticketCost < 0)
            {
                return -1;
            }

            switch (ticketType)
            {
                case "single":
                    ticketCost = basePrice;
                    break;
                case "return":
                    ticketCost = basePrice * 1.5m; // m for decimal (short for money)
                    break;
                default:
                    ticketCost = basePrice;
                    break;
            }
                return ticketCost;
        }

        /// <summary>
        /// The method returns the price of a ticket after discount
        /// based on the type of customer is applied.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="customerType"></param>
        /// <returns>Dicount price </returns>
        static decimal ApplyDiscount(decimal price, string customerType)
        {
            decimal discountedPrice = 0;
            customerType = customerType.ToLower();

            if (price < 0)
            {
                return -1;
            }

            switch (customerType)
            {
                case "child":
                    discountedPrice = price * 0.5m;
                    break;
                case "student":
                    discountedPrice = price * 0.7m;
                    break;
                case "oap":
                    discountedPrice = 0;
                    break;
                default:
                    discountedPrice = price;
                    break;
            }

            return discountedPrice;

        }

        /// <summary>
        /// This method prints out a menu and takes the user input
        /// </summary>
        /// <returns>The user input as an integer</returns>
        static int GetMenuChoice()
        {
            int menuSelection;
            Console.WriteLine("Ballin Buses Main Menu");
            Console.WriteLine("\n1. Buy ticket");
            Console.WriteLine("2. Check in return ticket");
            Console.WriteLine("3. Journey Report");
            Console.WriteLine("4. Exit.");
            menuSelection = int.Parse(Console.ReadLine());
            return menuSelection;
        }

        /// <summary>
        /// This gets user input, it calcuates and outputs the price of a bus 
        /// it also updates the static counter variables.
        /// </summary>
        static void BuyTicket()
        {
            Console.WriteLine("\n-=Buy Ticket=-");

            decimal basePrice = 10;
            string ticketType, customerType;
            decimal ticketPrice;
            //Input
        
            ticketType = GetTicketTypeFromUser();

          
            customerType = GetCustomerTypeFromUser();

            // calculations

            ticketPrice = CalculateTicketPrice(basePrice, ticketType);
            ticketPrice = ApplyDiscount(ticketPrice, customerType);

            // store the data

            seatsOccupied++;
            totalMoneyTaken += ticketPrice;
            ticketsSold++;
            

            //Display ticket
            Console.WriteLine($"Ballin-Sligo: {customerType} {ticketType} : {ticketPrice:c}");
        }


        static string GetCustomerTypeFromUser ()
        {
            Console.Write("Select type of customer (adult/child/student/oap): ");
            string customerType = Console.ReadLine().ToLower();

            string[] validTypes = { "adult", "child", "student", "oap" };

            while (! validTypes.Contains(customerType))
            {
                Console.WriteLine("Incorrect Type, please choose again > ");
                Console.Write("Select a ticket type (single, return): ");
               customerType = Console.ReadLine().ToLower();
            }

            return customerType;
            
        }


        static string GetTicketTypeFromUser()
        {
            Console.Write("Select a ticket type (single, return): ");
            string ticketType = Console.ReadLine().ToLower();

            while (ticketType != "single" && ticketType != "return")
            {
                Console.WriteLine("Incorrect Type, please choose again > ");
                Console.Write("Select a ticket type (single, return): ");
                ticketType = Console.ReadLine().ToLower();
            }

            return ticketType;
        }


        /// <summary>
        /// 
        /// </summary>
        static void checkInReturnTicket()
        {
            Console.WriteLine("\n-=Check In Return Ticket=-");
            //Check if there is any seats remaining
            if (seatsOccupied >= seats)
            {
                Console.WriteLine("Bus Full");
            }
            else
            {
                seatsOccupied = seatsOccupied + 1;
                Console.WriteLine($"Number of seats remaining = {seats - seatsOccupied}");
            }
        }

        static void PrintJourneyReportToConsole()
        {
            Console.WriteLine("\n-=Journey Report=-");
            Console.WriteLine($"Number of Tickets Sold = {ticketsSold}");
            Console.WriteLine($"Amount of Money Taken = {totalMoneyTaken:c}");
            Console.WriteLine($"Total Seats Occupied = {seatsOccupied}");
        }

    }
}