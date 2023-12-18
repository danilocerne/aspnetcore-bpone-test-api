using BPOneTestAPI.Domain.Validation;

namespace BPOneTestAPI.Domain.Entities
{
	public sealed class Product : Entity
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public decimal Price { get; private set; }
		public int Stock { get; private set; }
		public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int Active { get; private set; }

		public Product(string name, string description, decimal price, int stock,
			int productCategoryId, int active)
		{
            ValidateDomain(name, description, price, stock);
            Name = name;
			Description = description;
			Price = price;
			Stock = stock;
			ProductCategoryId = productCategoryId;
			Active = active;

		}

        public Product(int id, string name, string description, decimal price, int stock,
            int productCategoryId, int active)
        {
			Id = id;
            ValidateDomain(name, description, price, stock);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            ProductCategoryId = productCategoryId;
            Active = active;
        }

		private void ValidateDomain(string name, string description, decimal price, int stock)
		{
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            DomainExceptionValidation.When(price < 0,
                "Invalid price value");

            DomainExceptionValidation.When(stock < 0,
                "Invalid stock value");
        }

        public void Update(string name, string description, decimal price, int stock,
            int productCategoryId, int active)
        {
            ValidateDomain(name, description, price, stock);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            ProductCategoryId = productCategoryId;
            Active = active;
        }
    }
}

