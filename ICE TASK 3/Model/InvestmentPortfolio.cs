using ICE_TASK_3.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICE_TASK_3.Model
{
    public class InvestmentPortfolio
    {
        [Key] // Primary Key
        public int InvestmentNum { get; set; }

        [ForeignKey("Cow")]
        public int CowTag { get; set; }
        public Cow Cow { get; set; }

        [ForeignKey("Investor")]
        public int InvestorID { get; set; }
        public Investor Investor { get; set; }

        public double InvestmentPeriod { get; set; }
        public double MaintenaceFeePerMonth { get; set; }
        public double MaintenanceSavingsRate { get; set; }
        public double RIO_Rate { get; set; }
        public double TAX_Rate { get; set; }
        public double Est_Payout { get; set; }

        // Navigation property for the 1-to-many relationship with InvestmentPortfolio
        public List<Cow> Cows { get; set; }
        // Navigation property for the 1-to-many relationship with InvestmentPortfolio
        public List<Investor> Investors { get; set; }
    }
}