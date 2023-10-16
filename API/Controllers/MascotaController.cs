using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize]

public class MascotaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public MascotaController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
    {
        var entidad = await unitofwork.Mascotas.GetAllAsync();
        return mapper.Map<List<MascotaDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MascotaDto>> Get(int id)
    {
        var entidad = await unitofwork.Mascotas.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<MascotaDto>(entidad);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MascotaDto>>> GetPagination([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Mascotas.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<MascotaDto>>(entidad.registros);
        return new Pager<MascotaDto>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    [HttpGet("consulta3A")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> Consulta3A()
    {
        var entidad = await unitofwork.Mascotas.Consulta3A();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("consulta6A")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> Consulta6A()
    {
        var entidad = await unitofwork.Mascotas.Consulta6A();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("consulta1B")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> Consulta1B()
    {
        var entidad = await unitofwork.Mascotas.Consulta1B();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("consulta3B")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> Consulta3B()
    {
        var entidad = await unitofwork.Mascotas.Consulta3B();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("consulta6B")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> Consulta6B()
    {
        var entidad = await unitofwork.Mascotas.Consulta6B();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Mascota>> Post(MascotaDto entidadDto)
    {
        var entidad = this.mapper.Map<Mascota>(entidadDto);
        this.unitofwork.Mascotas.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody]MascotaDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Mascota>(entidadDto);
        unitofwork.Mascotas.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.Mascotas.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.Mascotas.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
