using InvestmentPerformanceApi.Models;

namespace InvestmentPerformanceApi.Repos;

public interface IInvestmentRepository
{
    IEnumerable<Investment> GetByUserId(int userId);

    Investment? GetById(int userId, int investmentId);
}
