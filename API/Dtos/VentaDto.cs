using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class VentaDto
    {
        public int Id { get; set; }
         public DateTime Fecha { get; set; }
        public int IdEmpleadofk { get; set; }
        public int IdClientefk { get; set; }
        public int IdFormaPagofk { get; set; }
    }
}