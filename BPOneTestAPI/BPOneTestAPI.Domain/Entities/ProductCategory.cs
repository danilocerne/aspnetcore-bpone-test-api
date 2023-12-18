using BPOneTestAPI.Domain.Validation;

namespace BPOneTestAPI.Domain.Entities
{
    public sealed class ProductCategory : Entity
	{
		public string Name { get; private set; }
		public ICollection<Product> Products { get; set; }
		public int Active { get; private set; }

		public ProductCategory(string name, int active)
		{
			ValidateDomain(name);
			Name = name;
			Active = active;
		}

        public ProductCategory(int id, string name, int active)
        {
			DomainExceptionValidation.When(id < 0, "Invalid Id value");
			Id = id;
            ValidateDomain(name);
            Name = name;
            Active = active;
        }

		private void ValidateDomain(string name)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(name),
				"Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characteres");
        }

		public void UpdateName(string name, int active)
        {
			ValidateDomain(name);
			Name = name;
            Active = active;
        }
    }
}

