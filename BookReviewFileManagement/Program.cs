namespace BookReviewFileManagement
{
    internal class Program
    {




        static BookReview[] bookReviews = new BookReview[50];

        static string[] categoryDescriptions = { "Poor", "Fair", "Good", "Very Good", "Excellant" };
        static int[] categoryCounts = new int[5];
        static double[] categorySums = new double[5];
        static int countReviews; // valid reviews
        static int countLines; // lines read so far
        static void Main(string[] args)
        {

      

            BookReview bookRev = new BookReview("b123", 45);

            double review = bookRev.Review;


            string path = "../../../bookReviews3.txt";
            ReadReviewsFromFile(path);

           // GenerateCategoryData();


        }


        static void ReadReviewsFromFile(string path)
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string? s = sr.ReadLine();
                    while (s != null)
                    {
                        string[] fields = s.Split(',');

                        if (fields.Length == 2 && BookReview.IsValidBookID(fields[0])
                            && IsValidReviewScore(fields[1]))
                        {
                            BookReview bookReview = new BookReview(fields[0],
                                Double.Parse(fields[1]));
   
                            bookReviews[countReviews] = bookReview;
                            countReviews++;

                            if (countReviews == 50)
                            {
                                Console.WriteLine("More than 50 reviews");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error on line {countLines+1}");
                        }

                        countLines++;
                        s = sr.ReadLine();
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error with reading from File " + ex.Message);
            }
        }



        static bool IsValidReviewScore(string input)
        {
            double score;

            return (Double.TryParse(input, out score) &&
                score >= 0 && score <= 5);

        }

        static void GenerateCategoryData(BookReview bookReview)
        {
            string categoryDescription = bookReview.GetCategoryDescription();


            int categoryIndex = Array.IndexOf(categoryDescriptions, categoryDescription);

            categoryCounts[categoryIndex]++;
            categorySums[categoryIndex] += bookReview.Review;
        }

        /// <summary>
        /// Takes a double which is score between 1 and 5 (inclusive) and
        /// returns a string with the category of that score.
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>

    }
}