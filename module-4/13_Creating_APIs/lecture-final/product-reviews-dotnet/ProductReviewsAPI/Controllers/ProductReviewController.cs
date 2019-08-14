using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReviewsAPI.Models;
using ProductReviewsAPI.Services;

namespace ProductReviewsAPI.Controllers
{
    /// <summary>
    /// This is a review api
    /// </summary>
    [Route("api/reviews")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        private DataAccessLayer dal;

        public ProductReviewController(DataAccessLayer dal)
        {
            this.dal = dal;
        }


        [HttpGet]
        public ActionResult<List<ProductReview>> GetAllReviews()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// Gets a product review given an id
        /// </summary>
        /// <param name="id">The id of the review desired</param>
        /// <returns>A Product Review, or 404 if not found</returns>
        //[Route("{id}")]
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReview> GetReviewById(int id)
        {
            ProductReview review = dal.Get(id);

            if(review == null)
            {
                return NotFound();      // Send a 404 http response
            }

            return review;
        }

        [HttpPost]
        public ActionResult Create(ProductReview review)
        {
            dal.Add(review);
            return CreatedAtRoute("GetProductById", new { id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ProductReview updatedReview)
        {
            ProductReview existingReview = dal.Get(id);
            if (existingReview == null)
            {
                return NotFound();      // Send a 404 http response
            }

            // Copy values from updated to existing
            existingReview.Name = updatedReview.Name;
            existingReview.Title = updatedReview.Title;
            existingReview.Review = updatedReview.Review;

            dal.Update(existingReview);

            return NoContent();         // return http 204
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ProductReview review = dal.Get(id);
            if (review == null)
            {
                return NotFound();
            }

            dal.Delete(id);

            return NoContent();

        }

    }
}