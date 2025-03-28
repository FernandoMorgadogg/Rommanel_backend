using MediatR;
using Rommanel.API.Models.Messages;
using Rommanel.API.Repositorys;

namespace Rommanel.API.Services
{
    public class UpdateClientService : IRequestHandler<UpdateClientRequest, bool>
    {
        private readonly IClientRepository _repository;
        public UpdateClientService(IClientRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateClient(new Models.DTO.ClientDto()
            {
                id = request.id,
                bairro = request.bairro,
                CEP = request.CEP,
                cidade = request.cidade,
                dataNascimento = request.dataNascimento,
                endereco = request.endereco,
                estado = request.estado,
                inscricaoEstadual = request.inscricaoEstadual,
                isento = request.isento,
                numero = request.numero,
                razaoSocial = request.razaoSocial,
                telfone = request.telfone
            });
        }

    }
}
