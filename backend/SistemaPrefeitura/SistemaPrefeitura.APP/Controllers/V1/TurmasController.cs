using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.ProfessorMappers;
using SistemaPrefeitura.APP.Mappers.TurmaMappers;
using SistemaPrefeitura.Application.Interfaces;

namespace SistemaPrefeitura.APP.Controllers.V1
{
    [Route("api/v1/escolas/{escolaId}/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        #region Properties
        private readonly ITurmaService _turmaService;
        private readonly TurmaToTurmaDTOMapper _turmaToTurmaDTOMapper;
        private readonly TurmaDTOToTurmaMapper _turmaDTOToTurmaMapper;
        #endregion

        #region Constructor
        public TurmasController(ITurmaService turmaService,
                                TurmaToTurmaDTOMapper turmaToTurmaDTOMapper,
                                TurmaDTOToTurmaMapper turmaDTOToTurmaMapper)
        {
            _turmaService = turmaService;
            _turmaToTurmaDTOMapper = turmaToTurmaDTOMapper;
            _turmaDTOToTurmaMapper = turmaDTOToTurmaMapper;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetTurmas(Guid escolaId)
        {
            return Ok(_turmaToTurmaDTOMapper.Map(await _turmaService.GetAllAsync(escolaId)));
        }

        [HttpGet("{turmaId}")]
        public async Task<IActionResult> GetTurma(Guid turmaId)
        {
            return Ok(_turmaToTurmaDTOMapper.Map(await _turmaService.GetByIdAsync(turmaId)));
        }

        [HttpPost]
        public async Task<IActionResult> PostTurma([FromRoute] Guid escolaId, [FromBody] TurmaDTO turma)
        {
            return Created("api/v1/escolas/{escolaId}/turmas", await _turmaService.AddAsync(_turmaDTOToTurmaMapper.Map(turma), escolaId));
        }

        [HttpPut]
        public async Task<IActionResult> PutTurma([FromBody] TurmaDTO turma)
        {
            return Created("api/v1/escolas/{escolaId}/turmas", await _turmaService.UpdateAsync(_turmaDTOToTurmaMapper.Map(turma)));
        }

        [HttpDelete("{turmaId}")]
        public async Task<IActionResult> DeleteTurma([FromRoute] Guid turmaId)
        {
            await _turmaService.DeleteByIdAsync(turmaId);
            return NoContent();
        }

    }
}
