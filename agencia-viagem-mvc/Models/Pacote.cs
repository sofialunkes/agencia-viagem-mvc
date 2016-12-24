﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencia_viagem_mvc.Models {
    public class Pacote {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeDias { get; set; }

        public List<long?> ClientesId { get; set; }
        public long? HotelId { get; set; }

        public List<Cliente> Clientes { get; set; }
        public Hotel Hotel { get; set; }
    }
}