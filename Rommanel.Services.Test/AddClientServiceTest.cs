using Moq;
using MediatR;
using Rommanel.API.Services;
using Rommanel.API.Repositorys;
using Rommanel.API.Models.Messages;
using Rommanel.API.Models.DTO;

namespace Rommanel.Services.Test
{
    public class AddClientServiceTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ICpfCnpjService> _cpfCnpjService;
        private readonly Mock<IClientRepository> _repository;
        private readonly AddClientService _service;

        public AddClientServiceTest()
        {
            _mediator = new Mock<IMediator>();
            _repository = new Mock<IClientRepository>();
            _cpfCnpjService = new Mock<ICpfCnpjService>();
            _service = new AddClientService(_repository.Object, _cpfCnpjService.Object);
        }

        [Fact(DisplayName = "Cadastra um novo cliente do tipo PF")]
        public async Task AddClientService_Handle_ShouldReturnTrue()
        {
            // Arrange
            var request = new AddClientRequest
            {
                bairro = "bairro",
                CEP = "cep",
                cidade = "cidade",
                cpfCnpj = "36378219826",
                dataNascimento = new DateTime(1986,12,29),
                email = "fernando@gmail.com",
                endereco = "endereco",
                estado = "estado",
                inscricaoEstadual = "inscricaoEstadual",
                isento = false,
                numero = 1,
                razaoSocial = "razaoSocial",
                telfone = "telfone"
            };

            _cpfCnpjService.Setup(x => x.IsCPFValido(It.IsAny<string>())).Returns(true);
            _repository.Setup(x => x.AddClient(It.IsAny<ClientDto>())).ReturnsAsync(true);

            // Act
            var result = await _service.Handle(request, new CancellationToken());

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "PF menor de idade")]
        public async Task AddClientService_Handle_ShouldReturnFalse_UsuarioMenorDeIdade()
        {
            // Arrange
            var request = new AddClientRequest
            {
                bairro = "bairro",
                CEP = "cep",
                cidade = "cidade",
                cpfCnpj = "36378219826",
                dataNascimento = DateTime.Now,
                email = "fernando@gmail.com",
                endereco = "endereco",
                estado = "estado",
                inscricaoEstadual = "inscricaoEstadual",
                isento = false,
                numero = 1,
                razaoSocial = "razaoSocial",
                telfone = "telfone"
            };

            _cpfCnpjService.Setup(x => x.IsCPFValido(It.IsAny<string>())).Returns(true);
            _repository.Setup(x => x.AddClient(It.IsAny<ClientDto>())).ReturnsAsync(true);

            // Act
            var result = await _service.Handle(request, new CancellationToken());

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "PF com numero de documento errado")]
        public async Task AddClientService_Handle_ShouldReturnFalse_UsuarioDocumentoInvalido()
        {
            // Arrange
            var request = new AddClientRequest
            {
                bairro = "bairro",
                CEP = "cep",
                cidade = "cidade",
                cpfCnpj = "36378219828",
                dataNascimento = DateTime.Now,
                email = "fernando@gmail.com",
                endereco = "endereco",
                estado = "estado",
                inscricaoEstadual = "inscricaoEstadual",
                isento = false,
                numero = 1,
                razaoSocial = "razaoSocial",
                telfone = "telfone"
            };

            _cpfCnpjService.Setup(x => x.IsCPFValido(It.IsAny<string>())).Returns(false);
            _repository.Setup(x => x.AddClient(It.IsAny<ClientDto>())).ReturnsAsync(true);

            // Act
            var result = await _service.Handle(request, new CancellationToken());

            // Assert
            Assert.True(result);
        }

    }
}
