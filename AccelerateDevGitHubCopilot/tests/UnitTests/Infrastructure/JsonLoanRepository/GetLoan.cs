using Library.ApplicationCore.Entities;
using Library.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace UnitTests.Infrastructure.Repositories
{
  public class GetLoanTests
  {
    private readonly Mock<JsonData> _mockJsonData;
    private readonly JsonLoanRepository _jsonLoanRepository;
    private readonly JsonLoanRepository _nonMockJsonLoanRepository;

    public GetLoanTests()
    {
      _mockJsonData = new Mock<JsonData>();
      _jsonLoanRepository = new JsonLoanRepository(_mockJsonData.Object);

      // Configuração para o repositório não simulado
      var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
      var jsonData = new JsonData(configuration);
      _nonMockJsonLoanRepository = new JsonLoanRepository(jsonData);
    }

    [Fact]
    public async Task GetLoan_ReturnsLoan_WhenIdExists()
    {
      // Arrange
      var loanId = 1;
      var loan = new Loan { Id = loanId };
      _mockJsonData.Setup(j => j.EnsureDataLoaded()).Returns(Task.CompletedTask);
      _mockJsonData.Setup(j => j.Loans).Returns(new List<Loan> { loan });

      // Act
      var result = await _jsonLoanRepository.GetLoan(loanId);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(loanId, result?.Id);
    }

    [Fact]
    public async Task GetLoan_ReturnsNull_WhenIdDoesNotExist()
    {
      // Arrange
      var loanId = 101; // ID que não existe
      _mockJsonData.Setup(j => j.EnsureDataLoaded()).Returns(Task.CompletedTask);
      _mockJsonData.Setup(j => j.Loans).Returns(new List<Loan>());

      // Act
      var result = await _jsonLoanRepository.GetLoan(loanId);

      // Assert
      Assert.Null(result);
    }
  }
}