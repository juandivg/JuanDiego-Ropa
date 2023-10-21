using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PrendaDto
    {
        public int Id { get; set; }
        public string IdPrenda { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnitCop { get; set; }
        public decimal ValorUnitUsd { get; set; }
        public int IdEstadofk { get; set; }
        public int IdTipoProteccionfk { get; set; }
        public int IdGenerofk { get; set; }
    }
}