using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmpleadoController:BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }
    [HttpGet("GetempleadosxCargo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>>Get2(string cargo)
    {
        var empleados=await _unitOfWork.Empleados.GetempleadosxCargo(cargo);
        return _mapper.Map<List<EmpleadoDto>>(empleados);

    }
    }
}