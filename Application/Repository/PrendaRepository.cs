using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
        public class PrendaRepository:GenericRepository<Prenda>, IPrendaRepository
    {
    private readonly RopaContext _context;
    public PrendaRepository(RopaContext context) : base(context)
    {
        _context=context;
    }

    public async Task<IEnumerable<Prenda>> GetInsumosxPrendas(string codigo)
    {
        return await _context.Prendas.Include(p=>p.InsumoPrendas).ThenInclude(p=>p.Insumo).Where(p=>p.IdPrenda==codigo).ToListAsync();
    }
}
