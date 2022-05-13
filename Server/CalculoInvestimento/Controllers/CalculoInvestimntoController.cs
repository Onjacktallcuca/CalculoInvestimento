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
        
        public CalculoInvestimentoController(ICalculoInvestimentoService service)
        {
            this.service = service;
        }

        
        [HttpPost]
        public ActionResult<Domain.CalculoInvestimento> Calculate(DadosEntrada data)
        {
            return Ok(service.Get(data));
        }
    }
}
