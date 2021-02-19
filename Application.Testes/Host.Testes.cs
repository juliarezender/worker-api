using Application.Service;
using Domain.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using WorkerApi.Controllers;

namespace Application.Testes
{
    [TestFixture]
    public class Tests
    {
        private readonly ILogger<ColaboradorController> _logger;
        private Mock<IAzureQueue> _azureQueue;
        private ColaboradorController _colaboradorController;

        [SetUp]
        public void Setup()
        {
            _azureQueue = new Mock<IAzureQueue>();
            _colaboradorController = new ColaboradorController(_logger, _azureQueue.Object);
        }

        [Test]
        public void TesteOkResultQuandoPassarUmColaboradorCorretamente()
        {
            var colaborador = new Colaborador
            {
                Id = 1,
                Nome = "Teste",
                Telefone = "99999999",
                Email = "teste@email.com"
            };

            var response = _colaboradorController.DadosColaboradorAsync(colaborador);

            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void TesteBadRequestQuandoPassarUmColaboradorIncorretamente()
        {
            var colaborador = new Colaborador()
            {
                Id = 1,
                Nome = "Teste",
                Telefone = "99999999"
            };

            _colaboradorController.ModelState.AddModelError("Email", "Required");

            var response = _colaboradorController.DadosColaboradorAsync(colaborador);

            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }
    }
}