using BPOneTestAPI.Domain.Entities;
using FluentAssertions;

namespace BPOneTestAPI.Domain.Tests;

public class ProductCategoryUnitTest
{
    [Fact(DisplayName = "Create Product Category with valid state")]
    public void CreateProductCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new ProductCategory(1, "Product Category Name", 1);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product Category with negative id value")]
    public void CreateProductCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new ProductCategory(-1, "Product Category Name", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Product Category with null name")]
    public void CreateProductCategory_NullNameValue_DomainExceptionInvalidNullName()
    {
        Action action = () => new ProductCategory(1, null, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Product Category with empty name")]
    public void CreateProductCategory_EmptyNameValue_DomainExceptionInvalidEmptyName()
    {
        Action action = () => new ProductCategory(1, "", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Product Category with short name")]
    public void CreateProductCategory_ShortNameValue_DomainExceptionInvalidShortName()
    {
        Action action = () => new ProductCategory(1, "Pr", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characteres");
    }

    [Fact(DisplayName = "Update Product Category with valid state")]
    public void UpdateProductCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new ProductCategory("Product Category updated", 1);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Update Product Category with null name")]
    public void UpdateProductCategory_NullNameValue_DomainExceptionInvalidNullName()
    {
        Action action = () => new ProductCategory(null, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Update Product Category with empty name")]
    public void UpdateProductCategory_EmptyNameValue_DomainExceptionInvalidEmptyName()
    {
        Action action = () => new ProductCategory("", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
}
