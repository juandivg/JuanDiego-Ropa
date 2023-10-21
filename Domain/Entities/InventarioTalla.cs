using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class InventarioTalla:BaseEntity
    {
        public int IdInventariofk { get; set; }
        public Inventario Inventario { get; set; }
        public int IdTallafk { get; set; }
        public Talla Talla { get; set; }
    }
