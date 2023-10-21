using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
        public class TipoEstadoRepository:GenericRepository<TipoEstado>, ITipoEstadoRepository
    {
    private readonly RopaContext _context;
    public TipoEstadoRepository(RopaContext context) : base(context)
    {
        _context=context;
    }
    }
}