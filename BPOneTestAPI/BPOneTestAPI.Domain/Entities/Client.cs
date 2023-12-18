using BPOneTestAPI.Domain.Interfaces;
using BPOneTestAPI.Domain.Validation;

namespace BPOneTestAPI.Domain.Entities
{
    public sealed class Client : Entity, ICpfCnpj
	{
		public string Name { get; private set; }
		public string CpfCnpj { get; private set; }
		public string Address { get; private set; }
		public string Number { get; private set; }
		public string Phone { get; private set; }
        public ICollection<Order> Orders { get; set; }
        public int Active { get; private set; }

        public bool EmptyCpfCnpj { get; set; }

        private readonly int[] CpfMultiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private readonly int[] CpfMultiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        private static readonly int[] CnpjMultiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static readonly int[] CnpjMultiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public Client(string name, string cpfCnpj, string address, string number,
			string phone, int active)
		{
            ValidateDomain(name);
            Name = name;
            CpfCnpjValidation(cpfCnpj);
            CpfCnpj = cpfCnpj;
            Address = address;
            Number = number;
            Phone = phone;
            Active = active;
        }

        public Client(int id, string name, string cpfCnpj, string address,
            string number, string phone, int active)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
            Name = name;
            CpfCnpjValidation(cpfCnpj);
            CpfCnpj = cpfCnpj;
            Address = address;
            Number = number;
            Phone = phone;
            Active = active;
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characteres");
        }

        public string RemoveCpfCnpjFormatting(string cpfCnpj)
        {
            return new string(cpfCnpj.Where(char.IsDigit).ToArray());
        }

        public bool IsCpfOrCnpjIsValid(string cpfCnpj)
        {
            if (cpfCnpj.Length <= 11)
                return CpfValidationIsValid(cpfCnpj);
            return CnpjValidationIsValid(cpfCnpj);
        }

        public bool CpfValidationIsValid(string value)
        {
            var cpf = RemoveCpfCnpjFormatting(value);

            if (cpf.Length != 11)
                return false;

            var tempCpf = cpf.Substring(0, 9);
            var sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf.AsSpan(i, 1)) * CpfMultiplier1[i];
            }

            var rest = sum % 11;
            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            var digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf.AsSpan(i, 1)) * CpfMultiplier2[i];
            }

            rest = sum % 11;
            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit += rest.ToString();
            return cpf.EndsWith(digit);
        }

        public bool CnpjValidationIsValid(string value)
        {
            var cnpj = RemoveCpfCnpjFormatting(value);

            if (cnpj.Length != 14)
                return false;

            var tempCnpj = cnpj.Substring(0, 12);
            var sum = 0;

            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(tempCnpj.AsSpan(i, 1)) * CnpjMultiplier1[i];
            }

            var rest = sum % 11;
            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            var digit = rest.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;

            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(tempCnpj.AsSpan(i, 1)) * CnpjMultiplier2[i];
            }

            rest = (sum % 11);
            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit = digit + rest.ToString();
            return cnpj.EndsWith(digit);
        }

        public string FormatCpf(string cpf)
        {
            return cpf?.Length == 11 ? Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00") : cpf;
        }

        public string FormatCnpj(string cnpj)
        {
            return cnpj?.Length == 14 ? Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00") : cnpj;
        }

        public void CpfCnpjValidation(string cpfCnpj)
        {
            EmptyCpfCnpj = string.IsNullOrWhiteSpace(cpfCnpj);
            if (EmptyCpfCnpj)
                DomainExceptionValidation.When(true, "Value cannot be emtpy");
            else
            {
                var cpfCnpjValidationResult = IsCpfOrCnpjIsValid(cpfCnpj);
                if (!cpfCnpjValidationResult)
                    DomainExceptionValidation.When(true, "Invalid value");
            }

        }

        public void Update(string name, string cpfCnpj, string address, string number,
            string phone, int active)
        {
            ValidateDomain(name);
            Name = name;
            CpfCnpjValidation(cpfCnpj);
            CpfCnpj = cpfCnpj;
            Address = address;
            Number = number;
            Phone = phone;
            Active = active;
        }
    }
}

