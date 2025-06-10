// TinyHouse.Business/Services/ReviewService.cs
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
            : this(new ReviewRepository(DbHelper.GetConnectionString()))
        { }

        // test veya mock için de ctor ekledik
        public ReviewService(ReviewRepository repo)
        {
            _repo = repo;
        }

        // Kullanıcının eklediği yorumu sakla (varsayılan Pending)
        public int AddReview(ReviewModel review)
            => _repo.Add(review);

        // İlan detay sayfası için onaylanmış yorumları getir
        public List<ReviewModel> GetByHouseId(int houseId)
            => _repo.GetByHouseId(houseId);

        // AdminForm’daki tüm yorumları listelemek için
        public List<ReviewModel> GetAllReviews()
            => _repo.GetAllReviews();

        public List<ReviewModel> GetVallReviews(int houseId)
            => _repo.GetVallReviews(houseId);

        // AdminForm’daki “Onayla” butonuna basınca
        public bool UpdateReviewStatus(int reviewId, CommentStatus newStatus)
            => _repo.UpdateReviewStatus(reviewId, newStatus);

        // AdminForm’daki “Sil” butonuna basınca
        public bool DeleteReview(int reviewId)
        {
            return _repo.Delete(reviewId);
        }
    }
}
