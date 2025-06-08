using System.Collections.Generic;
using TinyHouse.Data.Models;
using TinyHouse.Data.Repositories;
using TinyHouse.Data.Utilities;

namespace TinyHouse.Business.Services
{
    public class ReviewService
    {
        private readonly ReviewRepository _repo;

        public ReviewService()
        {
            _repo = new ReviewRepository(DbHelper.GetConnectionString());
        }

        public int AddReview(ReviewModel review)
        {
            return _repo.Add(review);
        }

        public List<ReviewModel> GetByHouseId(int houseId)
        {
            return _repo.GetByHouseId(houseId);
        }
    }
}
