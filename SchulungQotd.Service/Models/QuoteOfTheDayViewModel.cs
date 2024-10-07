namespace SchulungQotd.Service.Models
{
    public class QuoteOfTheDayViewModel
    {
        public string QuoteText { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorDescription { get; set; } = string.Empty;
        public DateOnly? AuthorBirthdate { get; set; }
        public byte[]? AuthorImage { get; set; }
        public string? AuthorImageMimeType { get; set; }
    }
}
