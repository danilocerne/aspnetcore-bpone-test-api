namespace BPOneTestAPI.Domain.Interfaces
{
    public interface ICpfCnpj
	{
        public string FormatCpf(string cpf);
		public string FormatCnpj(string cnpj);
        public string RemoveCpfCnpjFormatting(string cpfCnpj);
        public bool IsCpfOrCnpjIsValid(string cpfCnpj);
        public void CpfCnpjValidation(string cpfCnpj);
        public bool CpfValidationIsValid(string value);
        public bool CnpjValidationIsValid(string value);
    }
}

