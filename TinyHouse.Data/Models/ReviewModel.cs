public class ReviewModel
{
    public int Id { get; set; }
    public int HouseId { get; set; }
    public int UserId { get; set; }
    public int Rating { get; set; }      // 1–5 arası
    public string Text { get; set; }     // Yorum metni
    public DateTime CreatedAt { get; set; }
}
