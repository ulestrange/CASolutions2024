using System.Net;

namespace Sem_2_Ca2
{/*Michael Gallagher
  * Date 07/03/24
  * Description:ca2
  */
    internal class Program
    {
        static void Main(string[] args)
        {

            string bookId = "", redoInput = "P", spacingBetweenLines = "-------------------";


            // you would be better to use two separate arrays to store the bookID
            // and the score as the score should be stored as a double. 

            string[] ratingSystem = { "Poor", "Fair", "Good", "Very Good", "Excellent" };
            string[,] bookStoreId = { { "b12345", "2" }, { "b23567", "3" }, { "153326", "5" }, { "124141", "1" }, { "141421", "5" } };//arrays for book scores and ratings
                                                                                                                                      //This was hardcoded for testing but they do change

            Part1Input(bookStoreId);//part1logging scores

            //This is the rating system
            Console.WriteLine(spacingBetweenLines);
            Console.WriteLine("Book Report\nBookId\tScore");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{bookStoreId[i, 0]}  {bookStoreId[i, 1]}");
            }


            //Rating report syste,
            Console.WriteLine(spacingBetweenLines);
            Console.WriteLine("Rating report\nRating\tNumber of Books\t Average Score");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{ratingSystem[1]} /* other methods to be placed in here ran out of time*/ ");
            }


        }
        static void Part1Input(string[,] bookStoreId)
        {
            int leavingValue = 0;// the -999 score value to exit the method
            bool exitValue = true;
            int i = 0;//counters for the 2d array
            string bookId = "", redoInput = "P";//These are the strings for the sentences and book ratings

            do
            {
                Console.Write($"{redoInput}lease enter a Book ID(or -999 to finish) >");
                bookId = Console.ReadLine();

                if (int.TryParse(bookId, out leavingValue) == true && leavingValue == -999)
                {
                  //  exitValue = false;
                    break;
                }
                else if (bookId[0] == 'b' && bookId.Length == 6)//to credentials
                {
                    bookId = bookStoreId[i, 0];

                    bookStoreId[i, 1] = Part2Score();

                    exitValue = true;

                }
                else if (bookId[0] != 'b' || bookId.Length != 6)//if not to credentials 
                {
                    exitValue = true;
                    redoInput = redoInput = "Invlaid bookID - p";
                }
                i++;

            } while (exitValue = true && i < bookStoreId.Length);

        }
        static string Part2Score()
        {
            string bookScore = "", redoInput = "P";
            double score = 0;
            bool exitValue = true;
            do
            {
                Console.Write($"{redoInput}lease enter a score>");//entering the book score
                bookScore = Console.ReadLine();

                if (double.TryParse(bookScore, out score) == true && score >= 0 && score <= 5)// if score is correct
                {
                    if (score <= 1 && score > 0)// book rating output inside of the testing due to time effiecncy. This will output to the use the books value
                    {
                        Console.WriteLine("Book is rated Poor");
                    }
                    else if (score <= 2 && score > 1)
                    {
                        Console.WriteLine("Book is rated Fair");

                    }
                    else if (score <= 3 && score > 2)
                    {
                        Console.WriteLine("Book is rated Good ");

                    }
                    else if (score <= 4 && score > 3)
                    {
                        Console.WriteLine("Book is rated Very Good");

                    }
                    else if (score <= 5 && score > 4)
                    {
                        Console.WriteLine("Book is rated Excellent");
                    }
                    return bookScore;
                    exitValue = false;
                }
                else if (score > 5 || score == null)// this is for invalid scores
                {
                    redoInput = "Invalid score - p";
                }

                return bookScore;// have to return a score to the other method

            } while (exitValue == true);// while loop to show how this works 

        }

    }
}
