using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICargoRepository Cargos {get;}
        IClienteRepository Clientes {get;}
        IProveedorRepository Proveedores {get;}
        IColorRepository Colores {get;}
        IUsuarioRepository Usuarios    {get;}
        IRolRepository Roles {get;}
        IDepartamentoRepository Departamentos {get;}
        IDetalleOrdenRepositoty DetalleOrdenes {get;}
        IDetalleVentaRepository DetalleVentas {get;}
        IEmpleadoRepository Empleados {get;}
        IEmpresaRepository Empresas {get;}
        IEstadoRepository Estados {get;}
        IFormaPagoRepository FormaPagos {get;}
        IGeneroRepository Generos {get;}
        IInsumoPrendaRepository InsumoPrendas {get;}
        IInsumoRepository Insumos {get;}
        IInventarioRepository Inventarios {get;}
        IMunicipioRepository Municipios {get;}
        IOrdenRepository Ordenes {get;}
        IPaisRepository Paises {get;}
        IPrendaRepository Prendas {get;}
        ITallaRepository Tallas {get;}
        ITipoEstadoRepository TipoEstados {get;}
        ITipoPersona TipoPersonas {get;}
        IVentaRepository Ventas {get;}
        Task<int> SaveAsync();
    }
}