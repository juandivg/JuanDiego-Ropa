using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository
{
        public class OrdenRepository:GenericRepository<Orden>, IOrdenRepository
    {
    private readonly RopaContext _context;
    public OrdenRepository(RopaContext context) : base(context)
    {
        _context=context;
    }

        public async Task<IEnumerable<Orden>> GetOrdenesxEstado(string estado)
        {
            return await _context.Ordenes.Where(p=>p.Estado.Descripcion==estado).ToListAsync();
        }
    }
}