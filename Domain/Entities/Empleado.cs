using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class Empleado:BaseEntity
    {
        public string Idemp { get; set; }
        public string Nombre { get; set; }
        public int IdCargofk { get; set; }
        public Cargo Cargo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdMunicipiofk { get; set; }
        public Municipio Municipio { get; set; }
        public ICollection<Venta> Ventas { get; set; }
        public ICollection<Orden> Ordenes { get; set; }

    }
