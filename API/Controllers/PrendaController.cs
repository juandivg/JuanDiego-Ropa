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
        public class PrendaController:BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PrendaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }
      [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<PrendaDto>>>Get1()
    {
        var especies=await _unitOfWork.Prendas.GetAllAsync();
        return _mapper.Map<List<PrendaDto>>(especies);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PrendaDto>>> Getpag([FromQuery] Params PrendaParams)
    {
        var Prenda = await _unitOfWork.Prendas.GetAllAsync(PrendaParams.PageIndex,PrendaParams.PageSize,PrendaParams.Search);
        var lstPrendasDto = _mapper.Map<List<PrendaDto>>(Prenda.registros);
        return new Pager<PrendaDto>(lstPrendasDto,Prenda.totalRegistros,PrendaParams.PageIndex,PrendaParams.PageSize,PrendaParams.Search);
    }
    [HttpGet("GetInsumosxPrendas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<InsumosxPrendaDto>>>Get2(string codigo)
    {
        var prendas=await _unitOfWork.Prendas.GetInsumosxPrendas(codigo);
        return _mapper.Map<List<InsumosxPrendaDto>>(prendas);

    }
    }
