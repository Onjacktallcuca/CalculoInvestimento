using CalculoInvestimento.Domain;
using CalculoInvestimento.Service;
using Microsoft.AspNetCore.Mvc;

namespace CalculoInvestimento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculoInvestimentoController : ControllerBase
    {
        private readonly ICalculoInvestimentoService service;

        public CalculoInvestimentoController(ICalculoInvestimentoService cdbService)
        {
            this.service = cdbService;
        }

        [HttpPost]
        public ActionResult<Domain.CalculoInvestimento> Calculate(DadosEntrada data)
        {
            return Ok(service.Get(data));
        }
    }
}
