using System.ComponentModel.DataAnnotations;

namespace CollabIndexUI.Models
{
    public class ListedProject
    {
        public int Id { get; set; }
        public int ListingId { get; set; }

        public string ContractAddress { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public string TwitterLink { get; set; }
        public string DexScreenerLink { get; set; }
        public string TelegramLink { get; set; }

        public string CreatorsWalletAddress { get; set; }
        public string CreatorsTwitterLink { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int Votes { get; init; }
    }
}
