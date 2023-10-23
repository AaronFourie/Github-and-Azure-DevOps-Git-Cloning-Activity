using System.ComponentModel.DataAnnotations;

namespace ICE_TASK_3.Model
{
    public class Investor
    {
        [Key] // Primary Key
        public int InvestorID { get; set; }
        public string InvestorName { get; set; }
        public string I_Address { get; set; }
        public int ContactNumber { get; set; }
        public int TaxNumber { get; set; }

        // Navigation property for the 1-to-many relationship with InvestmentPortfolio
        public List<InvestmentPortfolio> InvestmentPortfolios { get; set; }
    }
}