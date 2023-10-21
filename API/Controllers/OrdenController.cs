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
    public class OrdenController:BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public OrdenController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }
      [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<OrdenDto>>>Get1()
    {
        var especies=await _unitOfWork.Ordenes.GetAllAsync();
        return _mapper.Map<List<OrdenDto>>(especies);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<OrdenDto>>> Getpag([FromQuery] Params OrdenParams)
    {
        var Orden = await _unitOfWork.Ordenes.GetAllAsync(OrdenParams.PageIndex,OrdenParams.PageSize,OrdenParams.Search);
        var lstOrdensDto = _mapper.Map<List<OrdenDto>>(Orden.registros);
        return new Pager<OrdenDto>(lstOrdensDto,Orden.totalRegistros,OrdenParams.PageIndex,OrdenParams.PageSize,OrdenParams.Search);
    }
    [HttpGet("GetOrdenesxEstado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<OrdenDto>>>Get2(string estado)
    {
        var ordenes=await _unitOfWork.Ordenes.GetOrdenesxEstado(estado);
        return _mapper.Map<List<OrdenDto>>(ordenes);

    }

    }
    
