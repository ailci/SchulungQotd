namespace SchulungQotd.Domain
{
    public class Quote : BaseEntity
    {
        public required string QuoteText { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; } //FK  => Author + Id
    }
}