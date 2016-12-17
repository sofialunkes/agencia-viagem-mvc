namespace agencia_viagem_mvc.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<agencia_viagem_mvc.Context.EFContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(agencia_viagem_mvc.Context.EFContext context) {

        }
    }
}
