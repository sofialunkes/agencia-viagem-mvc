using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencia_viagem_mvc.Models {
    public class Viagem {
        public long Id { get; set; }
        public string Nome { get; set;}

        public int QuantidadeDias { get; set; }

        public long? HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}