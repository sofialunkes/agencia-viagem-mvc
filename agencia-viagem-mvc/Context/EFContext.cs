using agencia_viagem_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace agencia_viagem_mvc.Context {
    public class EFContext:DbContext {
        public EFContext() : base ("AgenciaViagem") { }
        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
    }
}