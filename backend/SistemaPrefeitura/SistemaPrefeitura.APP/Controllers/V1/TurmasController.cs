using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.AlunoMappers;
using SistemaPrefeitura.APP.Mappers.DisciplinaMappers;
using SistemaPrefeitura.APP.Mappers.ProfessorMappers;
using SistemaPrefeitura.APP.Mappers.TurmaMappers;
using SistemaPrefeitura.APP.Mappers.TurmasMappers;
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
        private readonly TurmaToTurmaCompletoDTOMapper _turmaToTurmaCompletoDTOMapper;
        private readonly DisciplinaToDisciplinaDTOMapper _disciplinaToDisciplinaDTOMapper;
        private readonly AlunoToAlunoDTOMapper _alunoToAlunoDTOMapper;


        #endregion

        #region Constructor
        public TurmasController(ITurmaService turmaService, TurmaToTurmaDTOMapper turmaToTurmaDTOMapper,
            TurmaDTOToTurmaMapper turmaDTOToTurmaMapper, TurmaToTurmaCompletoDTOMapper turmaToTurmaCompletoDTOMapper,
            DisciplinaToDisciplinaDTOMapper disciplinaToDisciplinaDTOMapper, AlunoToAlunoDTOMapper alunoToAlunoDTOMapper)
        {
            _turmaService = turmaService;
            _turmaToTurmaDTOMapper = turmaToTurmaDTOMapper;
            _turmaDTOToTurmaMapper = turmaDTOToTurmaMapper;
            _turmaToTurmaCompletoDTOMapper = turmaToTurmaCompletoDTOMapper;
            _disciplinaToDisciplinaDTOMapper = disciplinaToDisciplinaDTOMapper;
            _alunoToAlunoDTOMapper = alunoToAlunoDTOMapper;
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
            return Ok(_turmaToTurmaCompletoDTOMapper.Map(await _turmaService.GetByIdAsync(turmaId)));
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

        [HttpPost("{turmaId}/disciplinas")] 
        public async Task<IActionResult> PostDisciplinas([FromRoute] Guid turmaId, [FromBody] IEnumerable<Guid> disciplinasIds )
        {
            return Ok(_turmaToTurmaCompletoDTOMapper.Map(await _turmaService.GetByIdAsync(turmaId) ,
                                                         await _turmaService.AddDisciplinasAsync(turmaId, disciplinasIds)));
        }

        [HttpGet("{turmaId}/disciplinas")]
        public async Task<IActionResult> GetDisciplinas([FromRoute] Guid turmaId)
        {
            return Ok(_disciplinaToDisciplinaDTOMapper.Map(await _turmaService.GetDisciplinas(turmaId)));
        }

        [HttpPost("{turmaId}/alunos")]
        public async Task<IActionResult> PostAlunos([FromRoute] Guid turmaId, [FromBody] IEnumerable<Guid> alunosIds)
        {
            return Ok(_turmaToTurmaCompletoDTOMapper.Map(await _turmaService.AddAlunosAsync(turmaId, alunosIds)));
        }

        [HttpGet("{turmaId}/alunos")]
        public async Task<IActionResult> GetAlunos([FromRoute] Guid turmaId)
        {
            return Ok(_alunoToAlunoDTOMapper.Map(await _turmaService.GetAlunos(turmaId)));
        }

        [HttpDelete("{turmaId}/alunos/{alunoId}")]
        public async Task<IActionResult> DeleteAlunoFromTurma([FromRoute] Guid turmaId, Guid alunoId)
        {
            await _turmaService.RemoveAluno(turmaId, alunoId);
            return NoContent();
        }

        [HttpDelete("{turmaId}/disciplinas/{disciplinaId}")]
        public async Task<IActionResult> DeleteDisciplinaFromTurma([FromRoute] Guid turmaId, Guid disciplinaId)
        {
            await _turmaService.RemoveDisciplina(turmaId, disciplinaId);
            return NoContent();
        }
    }
}
