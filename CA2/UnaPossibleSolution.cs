//using System.ComponentModel;

//namespace CA2
//{
//    internal class Program
//    {

//        static string[] bookIDs = new string[5];
//        static double[] scores = new double[5];
//        static int count = 0;

//        static string bestBookID = "";
//        static double bestScore = -1;

     
//        static string[] categoryDescriptions = { "Poor", "Fair", "Good", "Very Good", "Excellant" };

//        static int[] categoryCounts = new int[5];
//        static double[] categorySums = new double[5];
//        static void Main(string[] args)
//        {


//            while (count < 5)
//            {

//                string bookID = GetBookIDFromUser();

//                if (bookID == "-999")
//                {
//                    break;
//                }
//                bookIDs[count] = bookID;

                

//                count++;

//                double score = GetScoreFromUser();

//                if (score > bestScore)
//                {
//                    bestScore = score;
//                    bestBookID = bookID;
//                }
//                scores[count] = score;

//                string categoryDescription = GetCategoryDescription(scores[count]);

//                Console.WriteLine($"Book {bookIDs[count]} is rated as {categoryDescription}");

//                int categoryIndex = Array.IndexOf(categoryDescriptions, categoryDescription);

//                categoryCounts[categoryIndex]++;
//                categorySums[categoryIndex] += scores[count];
//            }

//            // here we have finished taking input and need to
//            // print the book report and rating report

//            Console.WriteLine("-----------------------------");
//            PrintBookReport();
//            Console.WriteLine("-----------------------------");

//            PrintRatingReport();



//        }

//        static void PrintBookReport()
//        {
//            Console.WriteLine("Book Report");
//            Console.WriteLine("Book ID    Score");
//            for (int i = 0; i < count; i++)
//            {
//                Console.WriteLine($"{bookIDs[i]}    {scores[i]}");
//            }
//        }

//        static void PrintRatingReport()
//        {
//            Console.WriteLine("Rating Report");
//            Console.WriteLine("Rating    Number of Books   Average Score");
//            int countReviews = 0;
//            double sumRevies = 0;
//            for (int i = 0; i < categoryDescriptions.Length; i++)
//            {

//                countReviews += categoryCounts[i];
//                sumRevies += categorySums[i];
//                if (categoryCounts[i] == 0)
//                {
//                    Console.WriteLine($"{categoryDescriptions[i],-10}  {categoryCounts[i],-17}  ");
//                }
//                else
//                {
//                    Console.WriteLine($"{categoryDescriptions[i],-10} " +
//                        $" {categoryCounts[i],-17} {categorySums[i] / categoryCounts[i]} ");
//                }
//            }

//            Console.WriteLine($"Total Reviews : {countReviews}");

//            if (countReviews != 0)
//            {
//                Console.WriteLine($"Overall Average {sumRevies/countReviews}");
//                Console.WriteLine($"Book with Highest Score : {bestBookID}");
//            }

//        }

//        /// <summary>
//        /// gets either a valid bookID or -999 from the user
//        /// keeps prompting until the user enters a proper entry
//        /// </summary>
//        /// <returns></returns>

//        static string GetBookIDFromUser()
//        {
//            Console.Write("Please enter a Book ID (or -999 to finish) > ");
//            string bookID = Console.ReadLine().ToUpper();
//            while (!IsValidBookID(bookID) && bookID != "-999")
//            {
//                Console.WriteLine("Invalid bookID - please enter a Book ID (or -999 to finish) >");
//                bookID = Console.ReadLine().ToUpper();
//            }

//            // here either the bookID is valid or the bookID is -999
//            return bookID;
//        }

//        /// <summary>
//        ///  takes a string and returns true if it is a valid bookid
//        /// </summary>
//        /// <param name="bookID"></param>
//        /// <returns></returns>
//        static bool IsValidBookID(string bookID)
//        {
//            if (bookID.Length != 7 || !bookID.StartsWith('B'))
//                return false;

//            else
//            {
//                for (int i = 1; i < 7; i++)
//                {
//                    if (bookID[i] > '9' || bookID[i] < '0')
//                        return false;
//                }

//                return true;
//            }
//        }

//        /// <summary>
//        ///  prompts the user to enter a score and checks if it is valid.
//        ///  It keeps prompting until it gets a valid score. In which case it returns it
//        /// </summary>
//        /// <returns>score</returns>

//        static double GetScoreFromUser()
//        {
//            Console.Write("Please enter a score >");
//            string scoreEntered = Console.ReadLine();
//            double score;
//            while (!(double.TryParse(scoreEntered, out score)) ||
//                score < 0 || score > 5)
//            {
//                Console.Write("Invalid score - please enter a score >");
//                scoreEntered = Console.ReadLine();
//            }
//            return score;
//        }


//        /// <summary>
//        /// Takes a double which is score between 1 and 5 (inclusive) and
//        /// returns a string with the category of that score.
//        /// </summary>
//        /// <param name="score"></param>
//        /// <returns></returns>
//        static string GetCategoryDescription(double score)
//        {
//            string ratingCategory;
//            switch (score)
//            {
//                case >= 0 and < 1:
//                    ratingCategory = "Poor";
//                    break;
//                case > 1 and <= 2:
//                    ratingCategory = "Fair";
//                    break;
//                case > 2 and <= 3:
//                    ratingCategory = "Good";
//                    break;
//                case > 3 and <= 4:
//                    ratingCategory = "Very Good";
//                    break;
//                case > 4 and <= 5:
//                    ratingCategory = "Excellant";
//                    break;
//                default:
//                    throw (new ArgumentOutOfRangeException($"Got {score} expecting an input between 1 and 5"));

//            }

//            return ratingCategory;
//        }
//    }
//}