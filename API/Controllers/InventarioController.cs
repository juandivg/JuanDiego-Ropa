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
    public class InventarioController:BaseApiController
    {
                private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }
      [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<InventarioDto>>>Get1()
    {
        var especies=await _unitOfWork.Inventarios.GetAllAsync();
        return _mapper.Map<List<InventarioDto>>(especies);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<InventarioDto>>> Getpag([FromQuery] Params InventarioParams)
    {
        var Inventario = await _unitOfWork.Inventarios.GetAllAsync(InventarioParams.PageIndex,InventarioParams.PageSize,InventarioParams.Search);
        var lstInventariosDto = _mapper.Map<List<InventarioDto>>(Inventario.registros);
        return new Pager<InventarioDto>(lstInventariosDto,Inventario.totalRegistros,InventarioParams.PageIndex,InventarioParams.PageSize,InventarioParams.Search);
    }
    [HttpGet("GetInventariosxTallas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<InventarioDto>>>Get2()
    {
        var inventarios=await _unitOfWork.Inventarios.GetInventariosxTallas();
        return _mapper.Map<List<InventarioDto>>(inventarios);

    }
    }
