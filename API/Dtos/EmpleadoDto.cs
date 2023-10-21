using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Idemp { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdMunicipiofk { get; set; }
    }
}