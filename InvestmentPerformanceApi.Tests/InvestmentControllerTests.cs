using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

using InvestmentPerformanceApi.Controllers;
using InvestmentPerformanceApi.Models;
using InvestmentPerformanceApi.Repos;

public class InvestmentControllerTests
{
    private readonly Mock<IInvestmentRepository> _mockRepo;
    private readonly Mock<ILogger<InvestmentController>> _mockLogger;
    private readonly InvestmentController _controller;

    public InvestmentControllerTests()
    {
        _mockRepo = new Mock<IInvestmentRepository>();
        _mockLogger = new Mock<ILogger<InvestmentController>>();
        _controller = new InvestmentController(_mockRepo.Object, _mockLogger.Object);
    }

    [Fact]
    public void GetInvestments_ReturnsOk_WhenDataExists()
    {
        // Arrange
        int userId = 1;
        _mockRepo.Setup(r => r.GetByUserId(userId)).Returns(new List<Investment>
        {
            new Investment { Id = 1, Name = "Apple", UserId = userId },
            new Investment { Id = 2, Name = "Google", UserId = userId }
        });

        // Act
        var result = _controller.GetInvestments(userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var investments = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);
        Assert.Equal(2, investments.Count());
    }

    [Fact]
    public void GetInvestments_Returns500_OnException()
    {
        // Arrange
        int userId = 1;
        _mockRepo.Setup(r => r.GetByUserId(userId)).Throws(new Exception("DB failure"));

        // Act
        var result = _controller.GetInvestments(userId);

        // Assert
        var errorResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, errorResult.StatusCode);
    }

    [Fact]
    public void GetInvestmentDetails_ReturnsOk_WhenFound()
    {
        // Arrange
        int userId = 1, investmentId = 1;
        _mockRepo.Setup(r => r.GetById(userId, investmentId)).Returns(new Investment
        {
            Id = investmentId,
            UserId = userId,
            Shares = 10,
            CostBasisPerShare = 100,
            CurrentPrice = 150,
            PurchaseDate = DateTime.UtcNow.AddMonths(-6)
        });

        // Act
        var result = _controller.GetInvestmentDetails(userId, investmentId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public void GetInvestmentDetails_ReturnsNotFound_WhenNull()
    {
        // Arrange
        int userId = 1, investmentId = 99;
        _mockRepo.Setup(r => r.GetById(userId, investmentId)).Returns((Investment)null);

        // Act
        var result = _controller.GetInvestmentDetails(userId, investmentId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetInvestmentDetails_Returns500_OnException()
    {
        // Arrange
        int userId = 1, investmentId = 1;
        _mockRepo.Setup(r => r.GetById(userId, investmentId)).Throws(new Exception("Unexpected failure"));

        // Act
        var result = _controller.GetInvestmentDetails(userId, investmentId);

        // Assert
        var errorResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, errorResult.StatusCode);
    }
}
