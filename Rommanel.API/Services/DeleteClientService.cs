using MediatR;
using Rommanel.API.Models.Messages;
using Rommanel.API.Repositorys;

namespace Rommanel.API.Services
{
    public class DeleteClientService : IRequestHandler<DeleteClientRequest, bool>
    {
        private readonly IClientRepository _repository;
        public DeleteClientService(IClientRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteClient(request.id);
        }
    }
}
