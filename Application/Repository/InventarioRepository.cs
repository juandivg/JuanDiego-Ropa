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
    public class InventarioRepository:GenericRepository<Inventario>, IInventarioRepository
    {
    private readonly RopaContext _context;
    public InventarioRepository(RopaContext context) : base(context)
    {
        _context=context;
    }

        public async Task<IEnumerable<Inventario>> GetInventariosxTallas()
        {
            return await _context.Inventarios.Include(p=>p.InventarioTallas).ThenInclude(p=>p.Talla).ToArrayAsync();
        }
    }
}