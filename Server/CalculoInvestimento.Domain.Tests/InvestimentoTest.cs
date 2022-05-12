using Xunit;

namespace CalculoInvestimento.Domain.Tests
{
    public class InvestimentoTest
    {
        [Fact]
        public void VerificaValoresContrutor()
        {
            const double valorBruto = 160156.80;
            const double valorLiquido = 152024.00;

            var value = new CalculoInvestimento(ValorBruto: valorBruto, ValorLiquido: valorLiquido);
            
            Assert.Equal(value.ValorBruto, valorBruto);
            Assert.Equal(value.ValorLiquido, valorLiquido);
        }
    }
}
