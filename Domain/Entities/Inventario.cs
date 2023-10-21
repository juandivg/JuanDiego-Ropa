using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class Inventario:BaseEntity
    {
        public string Codigo { get; set; }
        public int IdPrendafk { get; set; }
        public Prenda Prenda { get; set; }
        public decimal ValorVtaCop { get; set; }
        public decimal ValorVtaUsd { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
        public ICollection<InventarioTalla> InventarioTallas { get; set; }
    }
