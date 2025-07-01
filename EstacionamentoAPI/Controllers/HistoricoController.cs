using Microsoft.AspNetCore.Mvc;
using EstacionamentoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/historico")]
    public class HistoricoController : ControllerBase
    {
        private readonly EstacionamentoContext _context;

        public HistoricoController(EstacionamentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarHistorico()
        {
            var lista = await _context.HistoricoVeiculos
                .OrderByDescending(h => h.DataHoraSaida)
                .Select(h => new
                {
                    h.Placa,
                    h.DataHoraEntrada,
                    h.DataHoraSaida,
                    h.ValorPago
                })
                .ToListAsync();
            return Ok(lista);
        }
    }
}
