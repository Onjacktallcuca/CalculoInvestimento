using CalculoInvestimento.Controllers;
using CalculoInvestimento.Domain;
using CalculoInvestimento.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CalculoInvestimento.Tests
{
    public class ControllerTest
    {
        [Fact]
        public void VerificaCalculo()
        {
            var entrada = new DadosEntrada(100, 2);
            var lucroliquido = new Domain.CalculoInvestimento(1000, 950);
            
            //Mokc para gerar o comparável
            var mock = new Mock<ICalculoInvestimentoService>();
            mock
                .Setup(svc => svc.Get(entrada))
                .Returns(lucroliquido);
            var controller = new CalculoInvestimentoController(mock.Object);

            var result = controller.Calculate(entrada);

            Assert.IsType<ActionResult<Domain.CalculoInvestimento>>(result);
        }

        [Fact]
        public void VerificaCalculoIvalido()
        {
            var service = new Mock<ICalculoInvestimentoService>();
            var controller = new CalculoInvestimentoController(service.Object);

            Assert.Throws<Exception>(() => controller.Calculate(new DadosEntrada(0, 2)));
        }
    }
}
