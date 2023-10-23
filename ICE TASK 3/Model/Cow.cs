using ICE_TASK_3.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICE_TASK_3.Model
{
    public class Cow
    {
        [Key] // Primary Key
        public int CowTag { get; set; }

        [ForeignKey("Farm")]
        public int FarmID { get; set; }
        public Farm Farm { get; set; }

        public string CowCategory { get; set; }
        public double AgeInMonth { get; set; }
        public double Cost { get; set; }

        // Navigation property for the 1-to-many relationship with InvestmentPortfolio
        public List<InvestmentPortfolio> InvestmentPortfolios { get; set; }
        // Navigation property for the 1-to-many relationship with InvestmentPortfolio
        public List<Farm> Farms { get; set; }
    }
}