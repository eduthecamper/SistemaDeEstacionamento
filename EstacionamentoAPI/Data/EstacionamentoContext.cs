using Microsoft.EntityFrameworkCore;
using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Data
{
    public class EstacionamentoContext : DbContext
    {
        public EstacionamentoContext(DbContextOptions<EstacionamentoContext> options)
        : base(options) { }

        public DbSet<VeiculoEstacionado> VeiculosEstacionados { get; set; }
        public DbSet<HistoricoVeiculo> HistoricoVeiculos { get; set; }
        public DbSet<Configuracao> Configuracao { get; set; }
    }
}