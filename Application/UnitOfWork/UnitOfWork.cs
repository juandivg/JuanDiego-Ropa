using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RopaContext _context;
        private ICargoRepository _cargos;
        private IClienteRepository _clientes;
        private IColorRepository _colores;
        private IDepartamentoRepository _departamentos;
        private IDetalleOrdenRepositoty _detalleordenes;
        private IDetalleVentaRepository _detalleventas;

        private IEmpleadoRepository _empleados;
        private IEmpresaRepository _empresas;
        private IEstadoRepository _estados;
        private IFormaPagoRepository _formapagos;
        private IGeneroRepository _generos;
        private IInsumoPrendaRepository _insumoprendas;
        private IInsumoRepository _insumos;
        private IInventarioRepository _inventarios;
        private IMunicipioRepository _municipios;
        private IOrdenRepository _ordenes;
        private IPaisRepository _paises;
        private IPrendaRepository _prendas;
        private IProveedorRepository _proveedores;
        private IRolRepository _roles;
        private ITallaRepository _tallas;
        private ITipoEstadoRepository _tipoestados;
        private ITipoPersona _tipopersonas;
        private IUsuarioRepository _usuarios;
        private IVentaRepository _ventas;

    
        public UnitOfWork(RopaContext context)
        {
            _context= context;
        }
        public ICargoRepository Cargos
        {
            get{
                if(_cargos==null)
                {
                    _cargos=new CargoRepository(_context);
                }
                return _cargos;
            }
        }
        public IClienteRepository Clientes
        {
            get{
                if(_clientes==null)
                {
                    _clientes=new ClienteRepository(_context);
                }
                return _clientes;
            }
        }
        public IColorRepository Colores
        {
            get{
                if(_colores==null)
                {
                    _colores=new ColorRepository(_context);
                }
                return _colores;
            }
        }
        public IDepartamentoRepository Departamentos
        {
            get{
                if(_departamentos==null)
                {
                    _departamentos=new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }
        public IDetalleOrdenRepositoty DetalleOrdenes
        {
            get{
                if(_detalleordenes==null)
                {
                    _detalleordenes=new DetalleOrdenRepository(_context);
                }
                return _detalleordenes;
            }
        }
        public IDetalleVentaRepository DetalleVentas
        {
            get{
                if(_detalleventas==null)
                {
                    _detalleventas=new DetalleVentaRepository(_context);
                }
                return _detalleventas;
            }
        }
        public IEmpleadoRepository Empleados
        {
            get{
                if(_empleados==null)
                {
                    _empleados=new EmpleadoRepository(_context);
                }
                return _empleados;
            }
        }
        public IEmpresaRepository Empresas
        {
            get{
                if(_empresas==null)
                {
                    _empresas=new EmpresaRepository(_context);
                }
                return _empresas;
            }
        }
        public IEstadoRepository Estados
        {
            get{
                if(_estados==null)
                {
                    _estados=new EstadoRepository(_context);
                }
                return _estados;
            }
        }
        public IFormaPagoRepository FormaPagos
        {
            get{
                if(_formapagos==null)
                {
                    _formapagos=new FormaPagoRepository(_context);
                }
                return _formapagos;
            }
        }
        public IGeneroRepository    Generos
        {
            get{
                if(_generos==null)
                {
                    _generos=new GeneroRepository(_context);
                }
                return _generos;
            }
        }
        public IInsumoRepository Insumos
        {
            get{
                if(_insumos==null)
                {
                    _insumos=new InsumoRepository(_context);
                }
                return _insumos;
            }
        }
        public IInsumoPrendaRepository InsumoPrendas
        {
            get{
                if(_insumoprendas==null)
                {
                    _insumoprendas=new InsumoPrendaRepository(_context);
                }
                return _insumoprendas;
            }
        }
        public IInventarioRepository Inventarios
        {
            get{
                if(_inventarios==null)
                {
                    _inventarios=new InventarioRepository(_context);
                }
                return _inventarios;
            }
        }
        public IMunicipioRepository Municipios
        {
            get{
                if(_municipios==null)
                {
                    _municipios=new MunicipioRepository(_context);
                }
                return _municipios;
            }
        }
        public IOrdenRepository Ordenes
        {
            get{
                if(_ordenes==null)
                {
                    _ordenes=new OrdenRepository(_context);
                }
                return _ordenes;
            }
        }
        public IPaisRepository Paises
        {
            get{
                if(_paises==null)
                {
                    _paises=new PaisRepository(_context);
                }
                return _paises;
            }
        }
        public IPrendaRepository Prendas
        {
            get{
                if(_prendas==null)
                {
                    _prendas=new PrendaRepository(_context);
                }
                return _prendas;
            }
        }
        public IProveedorRepository Proveedores
        {
            get{
                if(_proveedores==null)
                {
                    _proveedores=new ProveedorRepository(_context);
                }
                return _proveedores;
            }
        }
        public IRolRepository Roles
        {
            get{
                if(_roles==null)
                {
                    _roles=new RolRepository(_context);
                }
                return _roles;
            }
        }
        public ITallaRepository Tallas
        {
            get{
                if(_tallas==null)
                {
                    _tallas=new TallaRepository(_context);
                }
                return _tallas;
            }
        }
        public ITipoEstadoRepository TipoEstados
        {
            get{
                if(_tipoestados==null)
                {
                    _tipoestados=new TipoEstadoRepository(_context);
                }
                return _tipoestados;
            }
        }
        public ITipoPersona TipoPersonas
        {
            get{
                if(_tipopersonas==null)
                {
                    _tipopersonas=new TipoPersonaRepository(_context);
                }
                return _tipopersonas;
            }
        }
        public IUsuarioRepository Usuarios
        {
            get{
                if(_usuarios==null)
                {
                    _usuarios=new UsuarioRepository(_context);
                }
                return _usuarios;
            }
        }
        public IVentaRepository Ventas
        {
            get{
                if(_ventas==null)
                {
                    _ventas=new VentaRepository(_context);
                }
                return _ventas;
            }
        }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}