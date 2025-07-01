using Microsoft.AspNetCore.Mvc;
using EstacionamentoAPI.Data;
using EstacionamentoAPI.DTOs;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/veiculos")]
    public class VeiculosController : ControllerBase
    {
        private readonly EstacionamentoContext _context;
        private readonly VeiculoService _service;

        public VeiculosController(EstacionamentoContext context)
        {
            _context = context;
            _service = new VeiculoService(context);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVeiculo([FromBody] VeiculoDTO dto)
        {
            if (!_service.PlacaValida(dto.Placa))
                return BadRequest("Placa Invalida.");
            if (await _service.PlacaDuplicadaAsync(dto.Placa))
                return Conflict("Veículo já cadastrado");
            if (await _service.VagasDisponiveisAsync() <= 0)
                return BadRequest("Estacionamento lotado.");

            var veiculo = new VeiculoEstacionado
            {
                Placa = dto.Placa.ToUpper(),
                DataHoraEntrada = DateTime.Now
            };

            _context.VeiculosEstacionados.Add(veiculo);
            await _context.SaveChangesAsync();

            return Ok(veiculo);
        }

        [HttpDelete("{placa}")]
        public async Task<IActionResult> RemoverVeiculo(string placa)
        {
            var veiculo = await _context.VeiculosEstacionados.FirstOrDefaultAsync(v => v.Placa == placa.ToUpper());
            if (veiculo == null)
                return NotFound("Veículo não encontrado.");

            var saida = DateTime.Now;
            var valor = _service.CalcularValor(veiculo.DataHoraEntrada, saida);

            var historico = new HistoricoVeiculo
            {
                Placa = veiculo.Placa,
                DataHoraEntrada = veiculo.DataHoraEntrada,
                DataHoraSaida = saida,
                ValorPago = valor
            };

            _context.VeiculosEstacionados.Remove(veiculo);
            _context.HistoricoVeiculos.Add(historico);
            await _context.SaveChangesAsync();

            return Ok(new { historico.Placa, historico.ValorPago, historico.DataHoraEntrada, historico.DataHoraSaida });
        }
        [HttpGet]
        public async Task<IActionResult> ListarEstacionados()
        {
            var lista = await _context.VeiculosEstacionados
                .Select(v => new { v.Placa, v.DataHoraEntrada })
                .ToListAsync();
            return Ok(lista);
        }
    }
}