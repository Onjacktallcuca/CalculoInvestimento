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
        public void ShoudReturnCorrectCalculation()
        {
            var entrada = new DadosEntrada(100, 2);
            var profitability = new Domain.CalculoInvestimento(1000, 950);
            
            var mockService = new Mock<ICalculoInvestimentoService>();
            mockService
                .Setup(svc => svc.Get(entrada))
                .Returns(profitability);
            var controller = new CalculoInvestimentoController(mockService.Object);

            var result = controller.Calculate(entrada);

            Assert.IsType<ActionResult<Domain.CalculoInvestimento>>(result);
        }

        [Fact]
        public void ShouldReturnBadRequestWhenValueIsInvalid()
        {
            var mockService = new Mock<ICalculoInvestimentoService>();
            var controller = new CalculoInvestimentoController(mockService.Object);

            Assert.Throws<Exception>(() => controller.Calculate(new DadosEntrada(0, 2)));
        }
    }
}
