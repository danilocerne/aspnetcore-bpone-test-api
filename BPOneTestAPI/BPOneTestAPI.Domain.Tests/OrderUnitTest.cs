using BPOneTestAPI.Domain.Entities;
using FluentAssertions;

namespace BPOneTestAPI.Domain.Tests;

public class OrderUnitTest
{
    [Fact(DisplayName = "Create Order with valid state")]
    public void CreateOrder_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Order(1, 1);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Order with negative id value")]
    public void CreateOrder_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Order(-1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Order with negative Client Id value")]
    public void CreateOrder_NegativeClientIdValue_DomainExceptionInvalidClientId()
    {
        Action action = () => new Order(-1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Client Id. Client Id is required");
    }

    [Fact(DisplayName = "Update Order with valid state")]
    public void UpdateOrder_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Order(1, 1).Update(1);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Update Order with negative Client Id value")]
    public void UpdateOrder_NegativeClientIdValue_DomainExceptionInvalidClientId()
    {
        Action action = () => new Order(1, 1).Update(-1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Client Id. Client Id is required");
    }
}
