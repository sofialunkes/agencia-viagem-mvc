using Modelo.Tabelas;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia.Contexts {
    public class EFContext : DbContext {
        public EFContext() : base("AgenciaViagem") {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}