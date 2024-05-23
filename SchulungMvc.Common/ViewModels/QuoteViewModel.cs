namespace SchulungMvc.Common.ViewModels
{
    public class QuoteViewModel
    {
        public Guid Id { get; set; }
        public string QuoteText { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public string? AuthorName { get; set; }
    }
}