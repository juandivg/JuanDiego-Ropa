using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
        public class VentaRepository:GenericRepository<Venta>, IVentaRepository
    {
    private readonly RopaContext _context;
    public VentaRepository(RopaContext context) : base(context)
    {
        _context=context;
    }
    }
}