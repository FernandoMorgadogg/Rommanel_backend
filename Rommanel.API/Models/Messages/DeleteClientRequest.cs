using MediatR;

namespace Rommanel.API.Models.Messages
{
    public class DeleteClientRequest: IRequest<bool>
    {
        public int id { get; set; }
    }
}
