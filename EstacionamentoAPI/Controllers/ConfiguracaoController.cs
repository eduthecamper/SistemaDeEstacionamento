using Microsoft.AspNetCore.Mvc;
using EstacionamentoAPI.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/configuracao")]
    public class ConfiguracaoController : ControllerBase
    {
        private readonly EstacionamentoContext _context;

        public ConfiguracaoController(EstacionamentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var config = await _context.Configuracao.FirstOrDefaultAsync();
            if (config == null) return NotFound();
            return Ok(config);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] int quantidadeMaximaVagas)
        {
            var config = await _context.Configuracao.FirstOrDefaultAsync();
            if (config == null) return NotFound();
            config.QuantidadeMaximaVagas = quantidadeMaximaVagas;
            await _context.SaveChangesAsync();
            return Ok(config);
        }
    }
}
