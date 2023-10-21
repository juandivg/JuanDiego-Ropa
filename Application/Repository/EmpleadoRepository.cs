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

        public async Task<IEnumerable<Empleado>> GetempleadosxCargo(string cargo)
        {
            return await _context.Empleados.Where(p=>p.Cargo.Nombre==cargo).ToListAsync();
        }
    }
}