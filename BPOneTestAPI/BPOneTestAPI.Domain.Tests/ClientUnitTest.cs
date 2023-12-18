using BPOneTestAPI.Domain.Entities;
using FluentAssertions;

namespace BPOneTestAPI.Domain.Tests;

public class ClientUnitTest
{
    [Fact(DisplayName = "Create a client informing valid Cpf and valid states")]
    public void CreateClient_WithValidCpfAndWithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Client("John Doe", "24215307767", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create a client informing valid Cnpj and valid states")]
    public void CreateClient_WithValidCnpjAndWithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Client("John Doe", "87031297000130", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .NotThrow<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create a client informing invalid Cpf and valid states")]
    public void CreateClient_WithInvalidCpfAndWithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Client("John Doe", "12345678912", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid value");
    }

    [Fact(DisplayName = "Create a client informing invalid Cnpj and valid states")]
    public void CreateClient_WithInvalidCnpjAndWithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Client("John Doe", "12345678912345", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid value");
    }

    [Fact(DisplayName = "Create client with negative id value")]
    public void CreateClient_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Client(-1, "John Doe", "12345678912345", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Client with null name for Cpf valid")]
    public void CreateClient_NullNameValueForCpfValid_DomainExceptionInvalidNullName()
    {
        Action action = () => new Client(1, null, "24215307767", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Client with empty name for Cpf valid")]
    public void CreateClient_EmptyNameValueForCpfValid_DomainExceptionInvalidEmptyName()
    {
        Action action = () => new Client(1, "", "24215307767", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Client with null name for Cnpj valid")]
    public void CreateClient_NullNameValueForCnpjValid_DomainExceptionInvalidNullName()
    {
        Action action = () => new Client(1, null, "87031297000130", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Client with empty name for Cnpj valid")]
    public void CreateClient_EmptyNameValueForCnpjValid_DomainExceptionInvalidEmptyName()
    {
        Action action = () => new Client(1, "", "87031297000130", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Client with short name for Cpf valid")]
    public void CreateClient_ShortNameValueForCpfValid_DomainExceptionInvalidShortName()
    {
        Action action = () => new Client(1, "Jo", "24215307767", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characteres");
    }

    [Fact(DisplayName = "Create Client with short name for Cnpj valid")]
    public void CreateClient_ShortNameValueForCnpjValid_DomainExceptionInvalidShortName()
    {
        Action action = () => new Client(1, "Jo", "87031297000130", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characteres");
    }

    [Fact(DisplayName = "Create client with null Cpf")]
    public void CreateClient_NullCpfValue_DomainExceptionInvalidCpf()
    {
        Action action = () => new Client(1, "John Doe", null, "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Value cannot be emtpy");
    }

    [Fact(DisplayName = "Create client with empty Cpf")]
    public void CreateClient_EmptyCpfValue_DomainExceptionInvalidCpf()
    {
        Action action = () => new Client(1, "John Doe", "", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Value cannot be emtpy");
    }

    [Fact(DisplayName = "Create client with null Cnpj")]
    public void CreateClient_NullCnpjValue_DomainExceptionInvalidCnpj()
    {
        Action action = () => new Client(1, "John Doe", null, "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Value cannot be emtpy");
    }

    [Fact(DisplayName = "Create client with empty Cnpj")]
    public void CreateClient_EmptyCnpjValue_DomainExceptionInvalidCnpj()
    {
        Action action = () => new Client(1, "John Doe", "", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Value cannot be emtpy");
    }

    [Fact(DisplayName = "Update Client with null name for Cpf valid")]
    public void UpdateClient_NullNameValueForCpfValid_DomainExceptionInvalidNullName()
    {
        Action action = () => new Client(1, "John Doe", "24215307767", "Address",
            "1000", "11945543563", 1).Update(null, "24215307767", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Update Client with empty name for Cpf valid")]
    public void UpdateClient_EmptyNameValueForCpfValid_DomainExceptionInvalidEmptyName()
    {
        Action action = () => new Client(1, "John Doe", "24215307767", "Address",
            "1000", "11945543563", 1).Update("", "24215307767", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Update Client with null name for Cnpj valid")]
    public void UpdateClient_NullNameValueForCnpjValid_DomainExceptionInvalidNullName()
    {
        Action action = () => new Client(1, "John Doe", "24215307767", "Address",
            "1000", "11945543563", 1).Update(null, "87031297000130", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Update Client with empty name for Cnpj valid")]
    public void UpdateClient_EmptyNameValueForCnpjValid_DomainExceptionInvalidEmptyName()
    {
        Action action = () => new Client(1, "John Doe", "87031297000130", "Address",
            "1000", "11945543563", 1).Update("", "87031297000130", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Update Client with short name for Cpf valid")]
    public void UpdateClient_ShortNameValueForCpfValid_DomainExceptionInvalidShortName()
    {
        Action action = () => new Client(1, "Jo", "24215307767", "Address",
            "1000", "11945543563", 1).Update(null, "24215307767", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characteres");
    }

    [Fact(DisplayName = "Update Client with short name for Cnpj valid")]
    public void UpdateClient_ShortNameValueForCnpjValid_DomainExceptionInvalidShortName()
    {
        Action action = () => new Client(1, "Jo", "87031297000130", "Address",
            "1000", "11945543563", 1).Update("", "87031297000130", "Address",
            "1000", "11945543563", 1);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characteres");
    }

    [Fact(DisplayName = "Update client with null Cpf")]
    public void UpdateClient_NullCpfValue_DomainExceptionInvalidCpf()
    {
        Action action = () => new Client(1, "John Doe", "24215307767", "Address",
            "1000", "11945543563", 1).CpfCnpjValidation(null);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Value cannot be emtpy");
    }

    [Fact(DisplayName = "Update client with empty Cpf")]
    public void UpdateClient_EmptyCpfValue_DomainExceptionInvalidCpf()
    {
        Action action = () => new Client(1, "John Doe", "24215307767", "Address",
            "1000", "11945543563", 1).CpfCnpjValidation("");
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Value cannot be emtpy");
    }

    [Fact(DisplayName = "Update client with null Cnpj")]
    public void UpdateClient_NullCnpjValue_DomainExceptionInvalidCnpj()
    {
        Action action = () => new Client(1, "John Doe", "87031297000130", "Address",
            "1000", "11945543563", 1).CpfCnpjValidation(null);
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Value cannot be emtpy");
    }

    [Fact(DisplayName = "Update client with empty Cnpj")]
    public void UpdateClient_EmptyCnpjValue_DomainExceptionInvalidCnpj()
    {
        Action action = () => new Client(1, "John Doe", "87031297000130", "Address",
            "1000", "11945543563", 1).CpfCnpjValidation("");
        action.Should()
            .Throw<BPOneTestAPI.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Value cannot be emtpy");
    }


}
