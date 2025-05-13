using Microsoft.AspNetCore.Mvc;
using InvestmentPerformanceApi.Repos;

[ApiController]
[Route("api/users/{userId}/investments")]
public class InvestmentsController : ControllerBase
{
    private readonly InvestmentRepository _repository;

    public InvestmentsController(InvestmentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetInvestments(int userId)
    {
        var investments = _repository.GetByUserId(userId)
            .Select(i => new { i.Id, i.Name });
        return Ok(investments);
    }

    [HttpGet("{investmentId}")]
    public IActionResult GetInvestmentDetails(int userId, int investmentId)
    {
        var investment = _repository.GetById(userId, investmentId);
        if (investment == null)
            return NotFound();

        return Ok(new
        {
            investment.Shares,
            investment.CostBasisPerShare,
            investment.CurrentPrice,
            investment.CurrentValue,
            investment.Term,
            TotalGainOrLoss = investment.TotalGainOrLoss
        });
    }
}
