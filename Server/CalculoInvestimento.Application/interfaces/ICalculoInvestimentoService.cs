using CalculoInvestimento.Domain;

namespace CalculoInvestimento.Service
{
    public interface ICalculoInvestimentoService
    {
        Domain.CalculoInvestimento Get(DadosEntrada data);
    }
}
