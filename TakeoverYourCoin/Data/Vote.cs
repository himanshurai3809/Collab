namespace TakeoverYourCoin
{
    public class Vote
    {
        public int Id { get; set; }
        public int ListedProjectId { get; set; }
        public ListedProject listedProject { get; set; } = null;
        public string UserIdentifier { get; set; } = null; // This could be a user ID or another identifier
        public DateTime VotedOn { get; set; } = DateTime.UtcNow;
    }
}