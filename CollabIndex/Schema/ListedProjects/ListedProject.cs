namespace CollabIndex.Schema.ListedProjects;

public class ListedProject
{
    public int Id { get; init; }
    public int ListingId { get; init; }

    public string ContractAddress { get; init; }

    public string ProjectName { get; init; }

    public string Description { get; init; }

    public string TwitterLink { get; init; }
    public string DexScreenerLink { get; init; }
    public string TelegramLink { get; init; }

    public string CreatorsWalletAddress { get; init; }
    public string CreatorsTwitterLink { get; init; }

    public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
    public int Votes { get; init; }
}
