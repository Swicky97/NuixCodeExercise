namespace InvestmentPerformanceApi.Models;

public class Investment
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int UserId { get; set; }

    public int Shares { get; set; }

    public decimal CostBasisPerShare { get; set; }

    public decimal CurrentPrice { get; set; }

    public DateTime PurchaseDate { get; set; }

    public decimal CurrentValue => Shares * CurrentPrice;

    public string Term => (DateTime.UtcNow - PurchaseDate).TotalDays > 365 ? "Long Term" : "Short Term";

    public decimal TotalGainOrLoss => CurrentValue - (Shares * CostBasisPerShare);
}
