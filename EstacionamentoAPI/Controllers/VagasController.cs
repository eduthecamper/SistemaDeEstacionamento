using Microsoft.AspNetCore.Mvc;
using EstacionamentoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/vagas")]
    public class VagasController : ControllerBase
    {
        private readonly EstacionamentoContext _context;

        public VagasController(EstacionamentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> StatusVagas()
        {
            var config = await _context.Configuracao.FirstOrDefaultAsync();
            var ocupadas = await _context.VeiculosEstacionados.CountAsync();

            return Ok(new
            {
                Maximo = config?.QuantidadeMaximaVagas ?? 0,
                Ocupadas = ocupadas,
                Disponiveis = (config?.QuantidadeMaximaVagas ?? 0) - ocupadas
            });
        }
    }
}
