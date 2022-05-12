using CalculoInvestimento.Domain;
using CalculoInvestimento.Service;
using System;
using Xunit;

namespace CalculoInvestimento.Tests
{
    public class ServiceTest
    {
        private Domain.CalculoInvestimento ValorEsperadoPorFaixa(DadosEntrada calculo, double taxa)
        {
            double valorLiquido = calculo.Valor * Math.Pow(1 + Taxas.RATE, calculo.Meses);
            var taxas = (valorLiquido - calculo.Valor) * taxa;
            return new Domain.CalculoInvestimento(ValorBruto: valorLiquido, ValorLiquido: valorLiquido - taxas);
        }

        [Fact]
        public void SemestralTest()
        {
            var simul = new DadosEntrada(valor: 100, meses: 6);
            var result = new CalculoInvestimentoService().Get(simul);
            var expect = ValorEsperadoPorFaixa(simul, Taxas.SEMESTRAL);

            Assert.Equal(result.ValorBruto, expect.ValorBruto, 2);
            Assert.Equal(result.ValorLiquido, expect.ValorLiquido, 2);
        }

        [Fact]
        public void AnualTest()
        {
            var data = new DadosEntrada(valor: 100, meses: 11);
            var res = new CalculoInvestimentoService().Get(data);
            var expect = ValorEsperadoPorFaixa(data, Taxas.ANUAL);

            Assert.Equal(res.ValorBruto, expect.ValorBruto, 2);
            Assert.Equal(res.ValorLiquido, expect.ValorLiquido, 2);
        }

        [Fact]
        public void BienalTest()
        {
            var data = new DadosEntrada(valor: 100, meses: 21);

            var result = new CalculoInvestimentoService().Get(data);
            var expect = ValorEsperadoPorFaixa(data, Taxas.BIENAL);

            Assert.Equal(result.ValorBruto, expect.ValorBruto, 2);
            Assert.Equal(result.ValorLiquido, expect.ValorLiquido, 2);
        }

        /// <summary>
        /// Certifica se o cálculo será feito com a taxa de mais de dois anos (ACIMABIENAL = 0.15)
        /// </summary>
        [Fact]
        public void AcimaBienalTest()
        {
            var data = new DadosEntrada(valor: 100, meses: 27);

            var result = new CalculoInvestimentoService().Get(data);
            var expect = ValorEsperadoPorFaixa(data, Taxas.ACIMABIENAL);

            Assert.Equal(result.ValorBruto, expect.ValorBruto, 2);
            Assert.Equal(result.ValorLiquido, expect.ValorLiquido, 2);
        }
    }
}
