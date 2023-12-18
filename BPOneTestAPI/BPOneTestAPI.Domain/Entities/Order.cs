using BPOneTestAPI.Domain.Validation;

namespace BPOneTestAPI.Domain.Entities
{
    public sealed class Order : Entity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public int Active { get; private set; }

        public Order(int clientId, int active)
        {
            ValidateDomain(clientId);
            Active = active;
        }

        public Order(int id, int clientId, int active)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(clientId);
            ClientId = clientId;
            Active = active;
        }

        private void ValidateDomain(int clientId)
        {
            DomainExceptionValidation.When(clientId < 0,
                "Invalid Client Id. Client Id is required");
        }

        public void Update(int clientId)
        {
            ValidateDomain(clientId);
            ClientId = clientId;
        }

    }
}