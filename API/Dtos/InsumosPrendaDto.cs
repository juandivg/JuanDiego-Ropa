using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InsumosPrendaDto
    {
       public int IdInsumofk { get; set; } 
       public InsumoDto Insumo { get; set; }
    }
}