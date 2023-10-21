using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InsumosxPrendaDto
    {
        public string IdPrenda { get; set; }
        public List<InsumosPrendaDto> InsumoPrendas { get; set; }
    }
}