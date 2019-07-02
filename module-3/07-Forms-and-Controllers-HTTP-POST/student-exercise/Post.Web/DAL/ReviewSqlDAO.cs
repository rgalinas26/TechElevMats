using Post.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.DAL
{
    public class ReviewSqlDAO : IReviewDAO
    {
        private readonly string connectionString;

        public ReviewSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all reviews
        /// </summary>
        /// <returns></returns>
        public IList<Review> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves a new review to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>
        public int SaveReview(Review newReview)
        {
            throw new NotImplementedException();
        }
    }
}
