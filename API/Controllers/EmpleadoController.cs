using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
    public class EmpleadoController:BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>>Get1()
    {
        var especies=await _unitOfWork.Empleados.GetAllAsync();
        return _mapper.Map<List<EmpleadoDto>>(especies);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EmpleadoDto>>> Getpag([FromQuery] Params EmpleadoParams)
    {
        var Empleado = await _unitOfWork.Empleados.GetAllAsync(EmpleadoParams.PageIndex,EmpleadoParams.PageSize,EmpleadoParams.Search);
        var lstEmpleadosDto = _mapper.Map<List<EmpleadoDto>>(Empleado.registros);
        return new Pager<EmpleadoDto>(lstEmpleadosDto,Empleado.totalRegistros,EmpleadoParams.PageIndex,EmpleadoParams.PageSize,EmpleadoParams.Search);
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
