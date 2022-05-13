using CalculoInvestimento.Domain;

namespace CalculoInvestimento.Service
{
    /// <summary>
    /// Classe principal de acesso aos serviços de cálculo
    /// </summary>
    public class CalculoInvestimentoService : ICalculoInvestimentoService
    {
        /// <summary>
        /// 
        /// Para o cálculo do CDB, deve-se utilizar a fórmula VF = VI x [1 + (CDI x TB)] onde:
        ///  i.VF é o valor final;
        ///  ii.VI é o valor inicial;
        ///  iii.CDI é o valor dessa taxa no último mês;
        ///  iv.TB é quanto o banco paga sobre o CDI;
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Domain.CalculoInvestimento Get(DadosEntrada data)
        {
            var lucroBruto = CalcularLucroBruto(data);
            var desconto = CalcularDesconto(data.Meses);
            var lucroLiquido = LucroLiquido(lucroBruto, data.Valor, desconto);
            
            return new Domain.CalculoInvestimento(lucroBruto, lucroLiquido);
        }

        /// <summary>
        /// Nota: A fórmula calcula somente o valor de um mês. Ou seja, os rendimentos de cada mês devem ser 
        /// utilizados para calcular o mês seguinte
        /// VF = VI x [1 + (CDI x TB)]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double CalcularLucroBruto(DadosEntrada data)
        {
            double valorInicial = 0;
            double valor = data.Valor;
            for (int months = 0; months < data.Meses; months++)
            {
                valorInicial = valor * Taxas.RATE;
                valor = valorInicial;
            }

            return valorInicial;
        }

        /// <summary>
        /// Método utilizado para calcular o desconto com base na seguinte regra:
        /// Para cálculo do imposto utilizar a seguinte tabela:
        ///         i.Até 06 meses: 22,5%
        ///         ii.Até 12 meses: 20%
        ///         iii.Até 24 meses 17,5%
        ///         iv.Acima de 24 meses 15%
        /// </summary>
        /// <param name="meses"></param>
        /// <returns></returns>
        private double CalcularDesconto (int meses)
        {
            
            switch (meses)
            {
                case int n when (n <= 6):
                    return Taxas.SEMESTRAL;

                case int n when (n > 6 && n <= 12):
                    return Taxas.ANUAL;

                case int n when (n > 12 && n <= 24):
                    return Taxas.BIENAL;

                default:
                    return Taxas.ACIMABIENAL;
            }
        }

        /// <summary>
        /// Método para calcular o lucro liquido
        /// </summary>
        /// <param name="lucroBruto"></param>
        /// <param name="valor"></param>
        /// <param name="desconto"></param>
        /// <returns></returns>
        private double LucroLiquido(double lucroBruto, double valor, double desconto)
        {
            var lucro = lucroBruto - valor;
            var taxa = lucro * desconto;
            return lucroBruto - taxa;
        }
    }
}
