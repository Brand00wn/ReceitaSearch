using Microsoft.EntityFrameworkCore;
using RS.Domain.Entities;
using System;
using System.Linq;

namespace DDDWebAPI.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Atividade> Atividade { get; set; }

        public DbSet<Entidade> Entidade { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<QSA> QSA { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntidadeAtividadePrincipal>().HasKey(eap => new { eap.AtividadeId, eap.EntidadeId });
            modelBuilder.Entity<EntidadeAtividadeSecundaria>().HasKey(eas => new { eas.AtividadeId, eas.EntidadeId });
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }


            }

            return base.SaveChanges();
        }
    }
}