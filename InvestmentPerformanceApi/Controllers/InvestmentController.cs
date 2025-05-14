using Microsoft.AspNetCore.Mvc;
using InvestmentPerformanceApi.Repos;

namespace InvestmentPerformanceApi.Controllers;

[ApiController]
[Route("api/users/{userId}/investments")]
public class InvestmentController : ControllerBase
{
    private readonly IInvestmentRepository _repository;
    private readonly ILogger<InvestmentController> _logger;

    public InvestmentController(IInvestmentRepository repository, ILogger<InvestmentController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetInvestments(int userId)
    {
        try
        {
            _logger.LogInformation("Fetching investments for user {UserId}", userId);

            var investments = _repository.GetByUserId(userId)
                .Select(i => new { i.Id, i.Name });

            return Ok(investments);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching investments for user {UserId}", userId);
            return StatusCode(500, new { message = "Something went wrong while processing your request." });
        }
    }

    [HttpGet("{investmentId}")]
    public IActionResult GetInvestmentDetails(int userId, int investmentId)
    {
        try
        {
            _logger.LogInformation("Fetching details for investment {InvestmentId} for user {UserId}", investmentId, userId);

            var investment = _repository.GetById(userId, investmentId);

            if (investment == null)
            {
                _logger.LogWarning("Investment {InvestmentId} not found for user {UserId}", investmentId, userId);
                return NotFound();
            }

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
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching investment {InvestmentId} for user {UserId}", investmentId, userId);
            return StatusCode(500, new { message = "Something went wrong while processing your request." });
        }
    }
}
