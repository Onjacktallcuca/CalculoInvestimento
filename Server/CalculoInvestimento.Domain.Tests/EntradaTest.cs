using Xunit;

namespace CalculoInvestimento.Domain.Tests
{
    /// <summary>
    /// Classe para teste de validade dos dados de entrada da consulta
    /// Verifica se os dados que foram passados pela requisição, serão os mesmos que serão retornados
    /// </summary>
    public class EntradaTest
    {

        [Fact]
        public void VarificaValoresNegativos()
        {
            Assert.Throws<Exception>(() => new DadosEntrada(valor: -1, meses: Taxas.MESES));

        }

        [Fact]
        public void VarificaMes()
        {
            Assert.Throws<Exception>(() => new DadosEntrada(valor: Taxas.VALOR, meses: 0));

        }
        [Fact]
        public void VerificaValoresEntrada()
        {
            var data = new DadosEntrada(meses: Taxas.MESES, valor: Taxas.VALOR);

            Assert.Equal(data.Valor, Taxas.VALOR);
            Assert.Equal(data.Meses, Taxas.MESES);
        }

        [Fact]
        public void VerificaDefinicaoValoresEntrada()
        {
            var data = new DadosEntrada
            {
                Meses = Taxas.MESES,
                Valor = Taxas.VALOR
            };

            Assert.Equal(data.Meses, Taxas.VALOR);
            Assert.Equal(data.Valor, Taxas.MESES);
        }

    }
}
