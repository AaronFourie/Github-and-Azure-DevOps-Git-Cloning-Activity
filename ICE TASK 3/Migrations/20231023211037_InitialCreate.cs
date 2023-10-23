using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICE_TASK_3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cows",
                columns: table => new
                {
                    CowTag = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmID = table.Column<int>(type: "int", nullable: false),
                    CowCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeInMonth = table.Column<double>(type: "float", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    InvestmentPortfolioInvestmentNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cows", x => x.CowTag);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    FarmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CowTag = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.FarmID);
                    table.ForeignKey(
                        name: "FK_Farms_Cows_CowTag",
                        column: x => x.CowTag,
                        principalTable: "Cows",
                        principalColumn: "CowTag");
                });

            migrationBuilder.CreateTable(
                name: "InvestmentPortfolios",
                columns: table => new
                {
                    InvestmentNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CowTag = table.Column<int>(type: "int", nullable: false),
                    InvestorID = table.Column<int>(type: "int", nullable: false),
                    InvestmentPeriod = table.Column<double>(type: "float", nullable: false),
                    MaintenaceFeePerMonth = table.Column<double>(type: "float", nullable: false),
                    MaintenanceSavingsRate = table.Column<double>(type: "float", nullable: false),
                    RIO_Rate = table.Column<double>(type: "float", nullable: false),
                    TAX_Rate = table.Column<double>(type: "float", nullable: false),
                    Est_Payout = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPortfolios", x => x.InvestmentNum);
                    table.ForeignKey(
                        name: "FK_InvestmentPortfolios_Cows_CowTag",
                        column: x => x.CowTag,
                        principalTable: "Cows",
                        principalColumn: "CowTag",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investors",
                columns: table => new
                {
                    InvestorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    I_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    TaxNumber = table.Column<int>(type: "int", nullable: false),
                    InvestmentPortfolioInvestmentNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investors", x => x.InvestorID);
                    table.ForeignKey(
                        name: "FK_Investors_InvestmentPortfolios_InvestmentPortfolioInvestmentNum",
                        column: x => x.InvestmentPortfolioInvestmentNum,
                        principalTable: "InvestmentPortfolios",
                        principalColumn: "InvestmentNum");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cows_FarmID",
                table: "Cows",
                column: "FarmID");

            migrationBuilder.CreateIndex(
                name: "IX_Cows_InvestmentPortfolioInvestmentNum",
                table: "Cows",
                column: "InvestmentPortfolioInvestmentNum");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_CowTag",
                table: "Farms",
                column: "CowTag");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPortfolios_CowTag",
                table: "InvestmentPortfolios",
                column: "CowTag");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPortfolios_InvestorID",
                table: "InvestmentPortfolios",
                column: "InvestorID");

            migrationBuilder.CreateIndex(
                name: "IX_Investors_InvestmentPortfolioInvestmentNum",
                table: "Investors",
                column: "InvestmentPortfolioInvestmentNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Cows_Farms_FarmID",
                table: "Cows",
                column: "FarmID",
                principalTable: "Farms",
                principalColumn: "FarmID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cows_InvestmentPortfolios_InvestmentPortfolioInvestmentNum",
                table: "Cows",
                column: "InvestmentPortfolioInvestmentNum",
                principalTable: "InvestmentPortfolios",
                principalColumn: "InvestmentNum");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentPortfolios_Investors_InvestorID",
                table: "InvestmentPortfolios",
                column: "InvestorID",
                principalTable: "Investors",
                principalColumn: "InvestorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cows_Farms_FarmID",
                table: "Cows");

            migrationBuilder.DropForeignKey(
                name: "FK_Cows_InvestmentPortfolios_InvestmentPortfolioInvestmentNum",
                table: "Cows");

            migrationBuilder.DropForeignKey(
                name: "FK_Investors_InvestmentPortfolios_InvestmentPortfolioInvestmentNum",
                table: "Investors");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "InvestmentPortfolios");

            migrationBuilder.DropTable(
                name: "Cows");

            migrationBuilder.DropTable(
                name: "Investors");
        }
    }
}
