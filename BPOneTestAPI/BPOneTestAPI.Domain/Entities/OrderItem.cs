using BPOneTestAPI.Domain.Validation;

namespace BPOneTestAPI.Domain.Entities
{
	public sealed class OrderItem : Entity
	{
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }

        public OrderItem(int orderId, int productId, int amount, decimal unitPrice,
            decimal totalPrice)
        {
            ValidateDomain(orderId, productId, amount, unitPrice, totalPrice);
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public OrderItem(int id, int orderId, int productId, int amount, decimal unitPrice,
            decimal totalPrice)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(orderId, productId, amount, unitPrice, totalPrice);
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        private void ValidateDomain(int orderId, int productId, int amount,
            decimal unitPrice, decimal totalPrice)
        {
            DomainExceptionValidation.When(orderId < 0,
                "Invalid Order Id. Order Id is required");

            DomainExceptionValidation.When(productId < 0,
                "Invalid Product Id. Product Id is required");

            DomainExceptionValidation.When(amount < 0,
                "Invalid Amount value");

            DomainExceptionValidation.When(unitPrice < 0,
                "Invalid Unit Price value");

            DomainExceptionValidation.When(totalPrice < 0,
                "Invalid Total Price value");
        }

        public void Update(int orderId, int productId, int amount,
            decimal unitPrice, decimal totalPrice)
        {
            ValidateDomain(orderId, productId, amount, unitPrice, totalPrice);
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }
    }
}

