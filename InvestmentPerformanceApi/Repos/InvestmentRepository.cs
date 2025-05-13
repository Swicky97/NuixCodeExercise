using InvestmentPerformanceApi.Models;

namespace InvestmentPerformanceApi.Repos;

public static class InvestmentRepository
{
    private static readonly List<Investment> _investments = new()
    {
        new Investment { Id = 1, Name = "Apple", UserId = 1, Shares = 10, CostBasisPerShare = 150, CurrentPrice = 170, PurchaseDate = DateTime.UtcNow.AddMonths(-14) },
        new Investment { Id = 2, Name = "Google", UserId = 1, Shares = 5, CostBasisPerShare = 1200, CurrentPrice = 1400, PurchaseDate = DateTime.UtcNow.AddMonths(-10) },
        new Investment { Id = 3, Name = "Microsoft", UserId = 1, Shares = 2, CostBasisPerShare = 450, CurrentPrice = 435, PurchaseDate = DateTime.UtcNow.AddMonths(-2) },
        new Investment { Id = 4, Name = "Amazon", UserId = 1, Shares = 8, CostBasisPerShare = 2010, CurrentPrice = 1950, PurchaseDate = DateTime.UtcNow.AddMonths(-16) },
        new Investment { Id = 5, Name = "Oracle", UserId = 1, Shares = 15, CostBasisPerShare = 150, CurrentPrice = 162, PurchaseDate = DateTime.UtcNow.AddMonths(-1) },
        new Investment { Id = 6, Name = "Dell", UserId = 1, Shares = 5, CostBasisPerShare = 100, CurrentPrice = 107, PurchaseDate = DateTime.UtcNow.AddMonths(-5) },
        new Investment { Id = 7, Name = "Google", UserId = 2, Shares = 100, CostBasisPerShare = 1200, CurrentPrice = 1400, PurchaseDate = DateTime.UtcNow.AddMonths(-6) },
        new Investment { Id = 8, Name = "Nvidia", UserId = 2, Shares = 150, CostBasisPerShare = 1300, CurrentPrice = 1330, PurchaseDate = DateTime.UtcNow.AddMonths(-6) },
        new Investment { Id = 9, Name = "Netflix", UserId = 1, Shares = 12, CostBasisPerShare = 1050, CurrentPrice = 1130, PurchaseDate = DateTime.UtcNow.AddMonths(-3) },
        new Investment { Id = 10, Name = "Google", UserId = 3, Shares = 10000, CostBasisPerShare = 1200, CurrentPrice = 1400, PurchaseDate = DateTime.UtcNow.AddYears(-3) },
    };

    public static IEnumerable<Investment> GetByUserId(int userId) => _investments.Where(i => i.UserId == userId);
    public static Investment? GetById(int userId, int investmentId) => _investments.FirstOrDefault(i => i.UserId == userId && i.Id == investmentId);
}
