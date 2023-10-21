using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class Insumo:BaseEntity
    {
        public string Nombre { get; set; }
        public decimal ValorUnit { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
         public ICollection<InsumoProveedor> InsumoProveedores { get; set; }
        public ICollection<Proveedor> Proveedores = new HashSet<Proveedor>();
        public ICollection<InsumoPrenda> InsumoPrendas { get; set; }
    }
