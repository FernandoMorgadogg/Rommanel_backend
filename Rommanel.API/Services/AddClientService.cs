using MediatR;
using Rommanel.API.Models.Messages;
using Rommanel.API.Repositorys;

namespace Rommanel.API.Services
{
    public class AddClientService: IRequestHandler<AddClientRequest, bool>
    {
        private readonly ICpfCnpjService _cpfCnpjService;
        private readonly IClientRepository _repository;
        public AddClientService(IClientRepository repository, ICpfCnpjService cpfCnpjService)
        {
            _repository = repository;
            _cpfCnpjService = cpfCnpjService;
        }

        public async Task<bool> Handle(AddClientRequest request, CancellationToken cancellationToken)
        {
            switch (await this.TypePerson(request))
            {
                case "PF":
                    if (!_cpfCnpjService.IsCPFValido(request.cpfCnpj))
                        throw new ApplicationException("CPF inválido.");

                    if (await CalcularIdade(request.dataNascimento) < 18)
                        throw new ApplicationException("Menor de idade.");
                    break;
                case "PJ":
                    if (!_cpfCnpjService.IsCNPJValido(request.cpfCnpj))
                        throw new ApplicationException("CNPJ invalido.");

                    request.isento = true;
                    break;
                default:
                    throw new ApplicationException("Numero de documento invalido");
                    break;
            }
            
            var result = await _repository.AddClient(new Models.DTO.ClientDto()
            {
                bairro = request.bairro,
                CEP = request.CEP,
                cidade = request.cidade,
                cpfCnpj = request.cpfCnpj,
                dataNascimento = request.dataNascimento,
                email = request.email,
                endereco = request.endereco,
                estado = request.estado,
                inscricaoEstadual = request.inscricaoEstadual,
                isento = request.isento,
                numero = request.numero,
                razaoSocial = request.razaoSocial,
                telfone = request.telfone
            });

            return result;
        }

        private async Task<string> TypePerson(AddClientRequest request)
        {
            if (request.cpfCnpj.Length == 11)
            {
                return "PF";
            }
            else
            {
                return "PJ";
            }
        }

        private async Task<int> CalcularIdade(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataNascimento.Date > dataAtual.AddYears(-idade))
                idade--;
            
            return idade;
        }
    }
}
