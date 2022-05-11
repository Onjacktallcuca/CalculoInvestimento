using Xunit;

namespace CalculoInvestimento.Domain.Tests
{
    public class InvestimentoTest
    {
        [Fact]
        public void VerificaValoresContrutor()
        {
            const double valorBruto = 1000.98;
            const double valorLiquido = 950.15;

            var value = new CalculoInvestimento(ValorBruto: valorBruto, ValorLiquido: valorLiquido);
            
            Assert.Equal(value.ValorBruto, valorBruto);
            Assert.Equal(value.ValorLiquido, valorLiquido);
        }
    }
}
