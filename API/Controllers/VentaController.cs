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
    public class VentaController:BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public VentaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VentaDto>>>Get1()
    {
        var especies=await _unitOfWork.Ventas.GetAllAsync();
        return _mapper.Map<List<VentaDto>>(especies);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<VentaDto>>> Getpag([FromQuery] Params VentaParams)
    {
        var Venta = await _unitOfWork.Ventas.GetAllAsync(VentaParams.PageIndex,VentaParams.PageSize,VentaParams.Search);
        var lstVentasDto = _mapper.Map<List<VentaDto>>(Venta.registros);
        return new Pager<VentaDto>(lstVentasDto,Venta.totalRegistros,VentaParams.PageIndex,VentaParams.PageSize,VentaParams.Search);
    }

    }
