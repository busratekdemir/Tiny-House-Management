
namespace TinyHouse.UI
{
    internal class ReviewService
    {
        internal void AddReview(ReviewModel review)
        {
            throw new NotImplementedException();
        }

        internal List<ReviewModel> GetByHouseId(int houseId)
        {
            // Burada gerçek veri kaynağınızdan çekmelisiniz.
            // Şimdilik örnek bir listeyle dönelim:
            return new List<ReviewModel>
            {
                new ReviewModel { Id = 1, HouseId = houseId, UserId = 2, Rating = 5, Text = "Harika bir ev!", CreatedAt = DateTime.Now }
            };
        }
    }
}