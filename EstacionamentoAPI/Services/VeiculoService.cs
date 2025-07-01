using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace EstacionamentoAPI.Services
{
    public class VeiculoService
    {
        private readonly EstacionamentoContext _context;
        public VeiculoService(EstacionamentoContext context)
        {
            _context = context;
        }
        public bool PlacaValida(string placa)
        {
            //formato abc-1234 ou abc1d23
            return Regex.IsMatch(placa, @"^[A-Z]{3}-\d{4}$|^[A-Z]{3}\d[A-Z]\d{2}$", RegexOptions.IgnoreCase);
        }

        public async Task<bool> PlacaDuplicadaAsync(string placa)
        {
            return await _context.VeiculosEstacionados.AnyAsync(v => v.Placa == placa);
        }
        public async Task<int> VagasDisponiveisAsync()
        {
            var config = await _context.Configuracao.FirstOrDefaultAsync();
            var ocupadas = await _context.VeiculosEstacionados.CountAsync();
            return config.QuantidadeMaximaVagas - ocupadas;
        }
        public decimal CalcularValor(DateTime entrada, DateTime saida)
        {
            var horas = (decimal)(saida - entrada).TotalHours;
            if (horas < 1) horas = 1;
            return horas * 5; //R$5 por hora
        }
    }
}