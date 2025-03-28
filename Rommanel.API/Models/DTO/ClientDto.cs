using FluentValidation;

namespace Rommanel.API.Models.DTO
{
    public class ClientDto
    {
        public int id { get; set; }
        public string razaoSocial{ get; set; }
        public string cpfCnpj { get; set; }
        public string inscricaoEstadual { get; set; }
        public bool isento{ get; set; }
        public DateTime dataNascimento { get; set; }
        public string telfone { get; set; }
        public string email { get; set; }
        public string CEP { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }


    }

    public class ClientValidator : AbstractValidator<ClientDto>
    {
        public ClientValidator()
        {
            RuleFor(f => f.razaoSocial).NotEmpty().WithMessage("Razão Social é obrigatória");
            RuleFor(f => f.cpfCnpj)
                .NotEmpty()
                .WithMessage("Número do documento é obrigatório");

            RuleFor(f => f.email)
                .NotEmpty()
                .WithMessage("Email é obrigatório")
                .EmailAddress()
                .WithMessage("Email inválido");
        }
    }


}
