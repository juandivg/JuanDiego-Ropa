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
     public class EmpleadoRepository:GenericRepository<Empleado>, IEmpleadoRepository
    {
    private readonly RopaContext _context;
    public EmpleadoRepository(RopaContext context) : base(context)
    {
        _context=context;
    }
    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados.ToListAsync();
    }

        public async Task<IEnumerable<Empleado>> GetempleadosxCargo(string cargo)
        {
            return await _context.Empleados.Where(p=>p.Cargo.Nombre==cargo).ToListAsync();
        }
        public override async Task<(int totalRegistros, IEnumerable<Empleado> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Empleados as IQueryable<Empleado>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }
        
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
    }
}