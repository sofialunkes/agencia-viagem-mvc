namespace agencia_viagem_mvc.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<agencia_viagem_mvc.Context.EFContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(agencia_viagem_mvc.Context.EFContext context) {

        }
    }
}
