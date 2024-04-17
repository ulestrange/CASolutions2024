/*
 * Name : Samuel Kocych
 * Date : 12/02/2024
 * Descriptiopn
 * 
 * CA1
 */using System.Net;

namespace Part_3
{
    /*
     * Ryan Barry
     * S00250496
     * Program is not fully functioning yet due to lack of time
     */


    internal class Program
    {
        static string[] rating = { "Excellent", "Very Good", "Good", "Fair", "Poor" };
        static int[] ratingFrequency = new int[rating.Length];

        static void Main(string[] args)
        {
            string[] bookID = new string[5];
            double[] scores = new double[5];

            GetValidBookID(bookID, scores);

        }
        static void GetValidBookID(string[] bookID, double[] score)
        {

            for (int i = 0; i < bookID.Length; i++)
            {
                try
                {
                    Console.Write("Please enter a Book ID (or -999 to finish) > ");
                    bookID[i] = Console.ReadLine();
                    if (bookID[i] == "-999")
                    {
                        BookReport(bookID, score);
                        RatingReport(bookID, score);
                        break;
                    }

                    //if (bookID[i][0] != 'b' || bookID[i][0] != 'B') throw new IndexOutOfRangeException();
                    //if (bookID[i][6] != ' ') throw new IndexOutOfRangeException();

                    Console.Write("Please enter a score > ");
                    string scoreText = Console.ReadLine();
                    score[i] = double.Parse(scoreText);

                    Console.WriteLine($"This Book is Rated as {GiveRatingMesssage(score[i])}");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }

            }


        }
        static string GiveRatingMesssage(double score)
        {
            try
            {
                if (score < 0 || score > 5) throw new IndexOutOfRangeException();

                if (score > 0 && score <= 1)
                {
                    ratingFrequency[4]++;
                    return rating[4];
                }
                else if (score > 1 && score <= 2)
                {
                    ratingFrequency[3]++;
                    return rating[3];
                }
                else if (score > 2 && score <= 3)
                {
                    ratingFrequency[2]++;
                    return rating[2];
                }
                else if (score > 3 && score <= 4)
                {
                    ratingFrequency[1]++;
                    return rating[1];
                }
                else
                {
                    ratingFrequency[0]++;
                    return rating[0];
                }

            }
            catch (IndexOutOfRangeException e)
            {
                return e.Message;
            }

        }
        static void BookReport(string[] bookID, double[] score)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Book Report");
            Console.WriteLine("Book ID   Score");
            for (int i = 0; i < bookID.Length; i++)
            {
                if (bookID[i] == "-999")
                {
                    break;
                }
                Console.WriteLine(bookID[i] + "     " + score[i]);
            }
        }
        static void RatingReport(string[] bookID, double[] score)
        {
            double total = 0;
            string currentHighest = "b987654";
            Console.WriteLine("------------------------------");
            Console.WriteLine("Rating Report");
            Console.WriteLine("Rating    Number of Books    Average Score");
            for (int i = rating.Length; i > 0; i--)
            {
                Console.WriteLine(rating[i] + " " + ratingFrequency[i]);
            }
            Console.WriteLine($"Total Reviews : {score.Length}");
            for (int i = 0; i < score.Length; i++)
            {
                total += score[i];
            }
            Console.WriteLine($"Overall Average {total / score.Length}");
            for (int i = 0; i < score.Length; i++)
            {
                if (score[i] > score[i + 1])
                {
                    currentHighest = bookID[i];
                }
            }
            Console.WriteLine($"Book with Highest Score: {currentHighest}");

        }


    }
}


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