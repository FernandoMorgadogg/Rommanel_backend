using MediatR;

namespace Rommanel.API.Models.Messages
{
    public class UpdateClientRequest: IRequest<bool>
    {
        public int id { get; set; }
        public string razaoSocial { get; set; }
        public string cpfCnpj { get; set; }
        public string inscricaoEstadual { get; set; }
        public bool isento { get; set; }
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
}
