using System;

namespace ProductReviewsAPI.Models {

    /// <summary>
    /// This class represents a review of one of our products
    /// </summary>
    public class ProductReview {

        public int Id {get;set;}

        /// <summary>
        /// The name of the reviewer
        /// </summary>
        public string Name {get;set;}
        public string Title {get;set;}
        public string Avatar {get;set;}
        public string Review {get;set;}
        public DateTime CreatedAt {get;set;}

    }

}