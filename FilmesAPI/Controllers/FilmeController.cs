using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;
using FilmesAPI.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private DataContext _context;
    private IMapper _mapper;

    public FilmeController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="novoFilme">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    public async Task<IActionResult> AdicionarFilme([FromBody] CreateFilmeDto novoFilme)
    {
        Filme filme = _mapper.Map<Filme>(novoFilme);
        try
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(BuscarFilmePorId), new { id = filme.Id }, filme);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Não foi possível criar o filme - {ex.Message}");
        }
    }

    /// <summary>
    /// Lista todos os filmes do banco de dados sem paginação
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso listagem seja retornada com sucesso</response>
    [HttpGet]
    public async Task<IActionResult> ListarFilmes()
    {
        try
        {
            return Ok(await _context.Filmes.ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Não foi possível listar os filmes - {ex.Message}");
        }
    }

    /// <summary>
    /// Lista filmes com paginação
    /// </summary>
    /// <param name="page">Página atual</param>
    /// <param name="take">Quantidade de items retornada por página</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso listagem seja retornada com sucesso</response>
    [HttpGet("{take}/{page}")]
    public async Task<IActionResult> ListarFilmes([FromRoute] int take, [FromRoute] int page)
    {
        try
        {
            return Ok(await _context.Filmes.Skip((page - 1) * take).Take(take).ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Não foi possível listar os filmes - {ex.Message}");
        }
    }


    /// <summary>
    /// Lista um filme pelo seu id
    /// </summary>
    /// <param name="id">Id do filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso retornado com sucesso</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarFilmePorId([FromRoute] int id)
    {
        try
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);
            if (filme == null)
                return NotFound();

            return Ok(filme);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Não foi possível encontrar o filme - {ex.Message}");
        }
    }


    /// <summary>
    /// Deleta um filme pelo seu id
    /// </summary>
    /// <param name="id">Id do filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso deletado com sucesso</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarFilme([FromRoute] int id)
    {
        var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);
        if (filme == null)
            return NotFound();

        try
        {
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Não foi possível deletar o filme - {ex.Message}");
        }
    }

    /// <summary>
    /// Atualiza todos os dados de um filme buscado pelo seu id
    /// </summary>
    /// <param name="filmeEditado">Filme editado</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso editado com sucesso</response>
    [HttpPut]
    public async Task<IActionResult> EditarFilme([FromBody] Filme filmeEditado)
    {
        if (filmeEditado == null || filmeEditado.Id <= 0)
        {
            return BadRequest("Dados inválidos.");
        }

        try
        {
            _context.Filmes.Update(filmeEditado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Não foi possível atualizar o filme - {ex.Message}");
        }
    }

    /// <summary>
    /// Atualiza parte dos dados de um filme buscado pelo seu id
    /// </summary>
    /// <param name="id">Id do filme a ser editado</param>
    /// <param name="patchFilme">Campos a serem editados</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso editado com sucesso</response>
    [HttpPatch("{id}")]
    public async Task<IActionResult> EditarFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patchFilme)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme == null) return NotFound();

        try
        {
            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme); /*converting filme to an UpdateFilmeDto to validate according UpdateFilmeDto rules*/
            patchFilme.ApplyTo(filmeParaAtualizar, ModelState);
            if (!TryValidateModel(filmeParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(filmeParaAtualizar, filme); /*mapping changes from filmeParaAtualizar to Filme to save changes in the database*/
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Não foi possível atualizar o filme - {ex.Message}");
        }
    }
    /*
     Request format form patch to partially update this entity's data: JSON

        [
            {
                "op":"replace",
                "path":"/titulo",
                "value":"O Homem de Aço 2"
            }
        ]
     */
}
