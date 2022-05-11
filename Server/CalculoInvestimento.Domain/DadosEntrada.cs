using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CalculoInvestimento.Domain
{
    /// <summary>
    /// Classe com os parâmetros recebidos via POST do client (Angular)
    /// Esses dados são capturados através do JsonPropertyName, que vem no body da requisição.
    /// Quando lançado o DomainException, o Error de retorno conterá o parâmetro ErrorMessage com a mensagem de erro.
    /// </summary>
    public class DadosEntrada
    {
        private int _prazo;
        private double _valor;

        public DadosEntrada() { }
        public DadosEntrada(double valor, int meses)
        {
            this.Valor = valor;
            this.Meses = meses;
        }

        internal const string validaMesMessage = "O prazo do investimento deverá ser maior que a 1 mês";
        internal const string validaValorMessage = "O valor investido deve ser maior do que zero";

        [JsonPropertyName("meses")]
        [Range(minimum: 2, maximum: int.MaxValue, ErrorMessage = validaMesMessage)]
        public int Meses 
        {
            get => _prazo; 
            set{ 
                if (value < 2)
                    throw new Exception(validaMesMessage);
                _prazo = value;
            } 
        }

        [JsonPropertyName("valor")]
        [Range(minimum: 0.01, maximum: double.MaxValue, ErrorMessage = validaValorMessage)]
        public double Valor 
        {
            get => _valor;
            set
            {
                if (value <= 0)
                    throw new Exception(validaValorMessage);
                _valor = value;
            }
        }
    }
}
