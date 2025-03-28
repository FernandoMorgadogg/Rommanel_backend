using Microsoft.EntityFrameworkCore;
using Rommanel.API.Models.DTO;
using Rommanel.API.Models.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Rommanel.API.Repositorys
{
    public class ClientRepository : RommanelContext, IClientRepository
    {
        public ClientRepository(DbContextOptions<RommanelContext> options) : base(options)
        {
        }

        public async Task<bool> AddClient(ClientDto model)
        {
            this.Database.OpenConnection();

            this.Clients.Add(new ClientEntity
            {
                razaoSocial = model.razaoSocial,
                cpfCnpj = model.cpfCnpj,
                inscricaoEstadual = model.inscricaoEstadual,
                isento = model.isento,
                dataNascimento = model.dataNascimento,
                telfone = model.telfone,
                email = model.email,
                CEP = model.CEP,
                endereco = model.endereco,
                numero = model.numero,
                bairro = model.bairro,
                cidade = model.cidade,
                estado = model.estado,
                dataInclusao = DateTime.Now
            });
            this.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteClient(int clientId)
        {
            this.Clients.Remove(this.Clients.Find(clientId));
            return true;
        }

        public async Task<List<ClientDto>> GetClient()
        {
            var result = this.Clients.ToList();

            List<ClientDto> list = new List<ClientDto>();
            foreach (var item in result)
            {
                list.Add(new ClientDto()
                {
                    id = item.id,
                    razaoSocial = item.razaoSocial,
                    cpfCnpj = item.cpfCnpj,
                    inscricaoEstadual = item.inscricaoEstadual,
                    isento = item.isento,
                    dataNascimento = item.dataNascimento,
                    telfone = item.telfone,
                    email = item.email,
                    CEP = item.CEP,
                    endereco = item.endereco,
                    numero = item.numero,
                    bairro = item.bairro,
                    cidade = item.cidade,
                    estado = item.estado,
                });
            }

            return list;
        }

        public async Task<bool> UpdateClient(ClientDto model)
        {
            this.Clients.Update(new ClientEntity
            {
                id = model.id,
                razaoSocial = model.razaoSocial,
                //cpfCnpj = model.cpfCnpj,
                inscricaoEstadual = model.inscricaoEstadual,
                isento = model.isento,
                dataNascimento = model.dataNascimento,
                telfone = model.telfone,
                //email = model.email,
                CEP = model.CEP,
                endereco = model.endereco,
                numero = model.numero,
                bairro = model.bairro,
                cidade = model.cidade,
                estado = model.estado,
            });
            this.SaveChanges();
            return true;
        }
    }

    public interface IClientRepository
    {
        Task<bool> AddClient(ClientDto model);
        Task<bool> UpdateClient(ClientDto model);
        Task<bool> DeleteClient(int clientId );
        Task<List<ClientDto>> GetClient();
    }
}
