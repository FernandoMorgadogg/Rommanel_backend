using MediatR;
using Rommanel.API.Models.DTO;

namespace Rommanel.API.Models.Messages
{
    public class GetClientRequest: IRequest<List<ClientDto>>
    {
    }

    
}
