using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InventarioTallaDto
    {
        public TallaDto Talla { get; set; }
        public int Cantidad { get; set; }
    }
}