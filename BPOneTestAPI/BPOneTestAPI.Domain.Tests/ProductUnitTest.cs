using BPOneTestAPI.Domain.Entities;
using FluentAssertions;

namespace BPOneTestAPI.Domain.Tests;

public class ProductUnitTest
{
    [Fact(DisplayName = "Create Product with valid state")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product("Product name", "Description", 100.00m, 1, 1, 1);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product with negative id value")]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product name", "Description", 100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Product with null name")]
    public void CreateProduct_NullNameValue_DomainExceptionInvalidNullName()
    {
        Action action = () => new Product(1, null, "Description", 100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Product with empty name")]
    public void CreateProduct_EmptyNameValue_DomainExceptionInvalidEmptyName()
    {
        Action action = () => new Product(1, "", "Description", 100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Product with null description")]
    public void CreateProduct_NullDescriptionValue_DomainExceptionInvalidNullDescription()
    {
        Action action = () => new Product(1, "Product name", null, 100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required");
    }

    [Fact(DisplayName = "Create Product with empty description")]
    public void CreateProduct_EmptyDescriptionValue_DomainExceptionInvalidEmptyDescription()
    {
        Action action = () => new Product(1, "Product name", "", 100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required");
    }

    [Fact(DisplayName = "Create Product with short name")]
    public void CreateProduct_ShortNameValue_DomainExceptionInvalidShortName()
    {
        Action action = () => new Product(1, "Pr", "Description", 100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characteres");
    }

    [Fact(DisplayName = "Create Product with short description")]
    public void CreateProduct_ShortDescriptionValue_DomainExceptionInvalidShortDescription()
    {
        Action action = () => new Product(1, "Product name", "Descrip", 100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, too short, minimum 10 characteres");
    }

    [Fact(DisplayName = "Create product with negative price")]
    public void CreateProduct_NegativePriceValue_DomainExceptionInvalidNegativePrice()
    {
        Action action = () => new Product(1, "Product name", "Description", -100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }

    [Fact(DisplayName = "Create product with negative stock")]
    public void CreateProduct_NegativeStockValue_DomainExceptionInvalidNegativeStock()
    {
        Action action = () => new Product(1, "Product name", "Description", 100.00m, -1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }

    [Fact(DisplayName = "Update Product with valid state")]
    public void UpdateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product("Product updated", "Description updated",
            300.00m, 10, 1, 1).Update("Product updated", "Description updated",
            300.00m, 10, 1, 1);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Update Product with null name")]
    public void UpdateProduct_NullNameValue_DomainExceptionInvalidNullName()
    {
        Action action = () => new Product(null, "Example description",
            100.00m, 1, 1, 1).Update(null, "Example description",
            100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Update Product with empty name")]
    public void UpdateProduct_EmptyNameValue_DomainExceptionInvalidEmptyName()
    {
        Action action = () => new Product("", "Example description",
            100.00m, 1, 1, 1).Update("", "Example description",
            100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Update Product with null description")]
    public void UpdateProduct_NullDescriptionValue_DomainExceptionInvalidNullDescription()
    {
        Action action = () => new Product("Product name updated", null,
            100.00m, 1, 1, 1).Update("Product name updated", null,
            100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required");
    }

    [Fact(DisplayName = "Update Product with empty description")]
    public void UpdateProduct_EmptyDescriptionValue_DomainExceptionInvalidEmptyDescription()
    {
        Action action = () => new Product("Product name updated", "",
            100.00m, 1, 1, 1).Update("Product name updated", "",
            100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required");
    }

    [Fact(DisplayName = "Update product with negative price")]
    public void UpdateProduct_NegativePriceValue_DomainExceptionInvalidNegativePrice()
    {
        Action action = () => new Product(1, "Product name", "Description",
            -100.00m, 1, 1, 1).Update("Product name", "Description",
            -100.00m, 1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }

    [Fact(DisplayName = "Update product with negative stock")]
    public void UpdateProduct_NegativeStockValue_DomainExceptionInvalidNegativeStock()
    {
        Action action = () => new Product(1, "Product name", "Description",
            100.00m, -1, 1, 1).Update("Product name", "Description",
            100.00m, -1, 1, 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
}
