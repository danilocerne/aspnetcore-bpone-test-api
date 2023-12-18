using BPOneTestAPI.Domain.Entities;
using FluentAssertions;

namespace BPOneTestAPI.Domain.Tests;

public class OrderItemUnitTest
{
    [Fact(DisplayName = "Create Order Item valid state")]
    public void CreateOrderItem_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new OrderItem(1, 1, 10, 100.00m, 1000.00m);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Order Item negative Order Id value")]
    public void CreateOrderItem_NegativeOrderIdValue_DomainExceptionInvalidOrderId()
    {
        Action action = () => new OrderItem(-1, 1, 10, 100.00m, 1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Order Id. Order Id is required");
    }

    [Fact(DisplayName = "Create Order Item negative Product Id value")]
    public void CreateOrderItem_NegativeProductIdValue_DomainExceptionInvalidProductId()
    {
        Action action = () => new OrderItem(1, -1, 10, 100.00m, 1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Product Id. Product Id is required");
    }

    [Fact(DisplayName = "Create Order Item negative Amount value")]
    public void CreateOrderItem_NegativeAmountValue_DomainExceptionInvalidAmount()
    {
        Action action = () => new OrderItem(1, 1, -10, 100.00m, 1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Amount value");
    }

    [Fact(DisplayName = "Create Order Item negative Unit Price value")]
    public void CreateOrderItem_NegativeUnitPriceValue_DomainExceptionInvalidUnitPrice()
    {
        Action action = () => new OrderItem(1, 1, 10, -100.00m, 1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Unit Price value");
    }

    [Fact(DisplayName = "Create Order Item negative Total Price value")]
    public void CreateOrderItem_NegativeTotalPriceValue_DomainExceptionInvalidTotalPrice()
    {
        Action action = () => new OrderItem(1, 1, 10, 100.00m, -1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Total Price value");
    }

    [Fact(DisplayName = "Update Order Item with valid state")]
    public void UpdateOrderItem_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new OrderItem(1, 1, 10, 100.00m, 1000.00m)
            .Update(1, 1, 10, 100.00m, 1000.00m);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Update Order Item with negative Order Id value")]
    public void UpdateOrder_NegativeClientIdValue_DomainExceptionInvalidClientId()
    {
        Action action = () => new OrderItem(-1, 1, 10, 100.00m, 1000.00m)
            .Update(1, 1, 10, 100.00m, 1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Order Id. Order Id is required");
    }

    [Fact(DisplayName = "Update Order Item with negative Product Id value")]
    public void UpdateOrder_NegativeProductIdValue_DomainExceptionInvalidProductId()
    {
        Action action = () => new OrderItem(1, -1, 10, 100.00m, 1000.00m)
            .Update(1, -1, 10, 100.00m, 1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Product Id. Product Id is required");
    }

    [Fact(DisplayName = "Update Order Item negative Amount value")]
    public void UpdateOrderItem_NegativeAmountValue_DomainExceptionInvalidAmount()
    {
        Action action = () => new OrderItem(1, 1, -10, 100.00m, 1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Amount value");
    }

    [Fact(DisplayName = "Update Order Item negative Unit Price value")]
    public void UpdateOrderItem_NegativeUnitPriceValue_DomainExceptionInvalidUnitPrice()
    {
        Action action = () => new OrderItem(1, 1, 10, -100.00m, 1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Unit Price value");
    }

    [Fact(DisplayName = "Update Order Item negative Total Price value")]
    public void UpdateOrderItem_NegativeTotalPriceValue_DomainExceptionInvalidTotalPrice()
    {
        Action action = () => new OrderItem(1, 1, 10, 100.00m, -1000.00m);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Total Price value");
    }


}
