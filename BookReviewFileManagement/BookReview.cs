using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewFileManagement
{
    internal class BookReview
    {
        public double Review { get; set; }

        public string BookID { get; set; }


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
    }
}

