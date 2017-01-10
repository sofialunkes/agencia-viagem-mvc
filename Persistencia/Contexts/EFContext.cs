using Modelo.Tabelas;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using Persistencia.Migrations;

namespace Persistencia.Contexts {
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class EFContext : DbContext {
        public EFContext() : base("AgenciaViagem") {
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());

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