# InvestmentPerformanceApi

This repository contains the Investment Performance API, which provides functionality for managing and retrieving investment details for users.
Test data is available in InvestmentRepository.cs. Database creation was foregone for simplicity sake. 

## Getting Started

### Clone the repository
git clone https://github.com/Swicky97/NuixCodeExercise.git
open project in visual studio

### Restore installed dependencies
run dotnet restore

### Run the api
cd InvestmentPerformanceApi from proj base
select InvestmentPerformanceApi.csproj as startup project (if not already selected)
run dotnet run
SwaggerUI is available at the base url or endpoints can be tested manually by navigating to the controller endpoints
	-- localhost:5000/api/users/{userId}/investments
	-- localhost:5000/api/users/{userId}/investments/{investmentId}

### Run tests
cd InvestmentPerformanceApi.Tests from proj base
run dotnet test
	
