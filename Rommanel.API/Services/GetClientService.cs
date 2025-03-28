using MediatR;
using Rommanel.API.Models.DTO;
using Rommanel.API.Models.Messages;
using Rommanel.API.Repositorys;

namespace Rommanel.API.Services
{
    public class GetClientService : IRequestHandler<GetClientRequest, List<ClientDto>>
    {
        private readonly IClientRepository _repository;
        public GetClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClientDto>> Handle(GetClientRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetClient();
        }
    }
}
