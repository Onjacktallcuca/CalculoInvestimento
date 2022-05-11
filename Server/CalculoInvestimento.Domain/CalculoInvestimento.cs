using System.Text.Json.Serialization;

namespace CalculoInvestimento.Domain
{
    /// <summary>
    /// Classe principal de acesso aos valores do investimento
    /// </summary>
    public class CalculoInvestimento
    {
        public CalculoInvestimento(double ValorBruto, double ValorLiquido)
        {
            this.ValorBruto = ValorBruto;
            this.ValorLiquido = ValorLiquido;
        }

        [JsonPropertyName("valor_bruto")]
        public double ValorBruto { get; private set; }
        [JsonPropertyName("valor_liquido")]
        public double ValorLiquido { get; private set; }

        
    }
}
