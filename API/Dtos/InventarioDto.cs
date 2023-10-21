using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InventarioDto
    {
        public int Id { get; set; }
        public PrendaxInventarioDto Prenda { get; set; }
        public List<InventarioTallaDto> InventarioTallas { get; set; }
    }
}