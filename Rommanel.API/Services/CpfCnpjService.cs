namespace Rommanel.API.Services
{
    public class CpfCnpjService: ICpfCnpjService
    {
        public bool IsCPFValido(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = new System.Text.RegularExpressions.Regex(@"[^\d]").Replace(cpf, "");

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais
            bool todosDigitosIguais = true;
            for (int i = 1; i < 11; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    todosDigitosIguais = false;
                    break;
                }
            }
            if (todosDigitosIguais)
                return false;

            // Calcula os dígitos verificadores
            string tempCpf = cpf.Substring(0, 9);
            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos calculados são iguais aos dígitos do CPF
            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }

        public bool IsCNPJValido(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = new System.Text.RegularExpressions.Regex(@"[^\d]").Replace(cnpj, "");

            // Verifica se o CNPJ tem 14 dígitos
            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais
            bool todosDigitosIguais = true;
            for (int i = 1; i < 14; i++)
            {
                if (cnpj[i] != cnpj[0])
                {
                    todosDigitosIguais = false;
                    break;
                }
            }
            if (todosDigitosIguais)
                return false;

            // Calcula os dígitos verificadores
            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCnpj += digito1;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos calculados são iguais aos dígitos do CNPJ
            return cnpj.EndsWith(digito1.ToString() + digito2.ToString());
        }
    }

    public interface ICpfCnpjService
    {
        bool IsCPFValido(string cpf);
        bool IsCNPJValido(string cnpj);
    }   
}
