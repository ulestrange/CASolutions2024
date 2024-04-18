using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BookReviewFileManagement
{
    internal class BookReview
    {
        public double Review
        {
            get
            {
                return Review;
            }

             set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException("review score must be between 0 and 5");
                        }
                Review = value;
            }
        }

        public string BookID { get; set; }

        public BookReview()
        {
        }


        /// <summary>
        /// The review score must be between 1 and 5 or an exception will be thrown
        /// </summary>
        /// <param name="id"></param>
        /// <param name="review"></param>
        public BookReview(string id, double review)
        {
            BookID = id;


            if (review < 0 || review > 5)
            {
                throw new ArgumentException("review score must be between 0 and 5");
            }

            Review = review;
        }

        public string GetCategoryDescription()
        {
            string ratingCategory;
            switch (Review)
            {
                case >= 0 and < 1:
                    ratingCategory = "Poor";
                    break;
                case > 1 and <= 2:
                    ratingCategory = "Fair";
                    break;
                case > 2 and <= 3:
                    ratingCategory = "Good";
                    break;
                case > 3 and <= 4:
                    ratingCategory = "Very Good";
                    break;
                case > 4 and <= 5:
                    ratingCategory = "Excellant";
                    break;
                default:
                    throw (new ArgumentOutOfRangeException($"Got {Review} expecting an input between 1 and 5"));

            }
            return ratingCategory;
        }

        /// <summary>
        /// this takes a string and returns true if it is a Valid BookID
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>

        public static bool IsValidBookID(string bookID)
        {
            if (bookID.Length != 7 || !bookID.StartsWith('B'))
                return false;

            else
            {
                for (int i = 1; i < 7; i++)
                {
                    if (bookID[i] > '9' || bookID[i] < '0')
                        return false;
                }

                return true;
            }
        }

    }
}

