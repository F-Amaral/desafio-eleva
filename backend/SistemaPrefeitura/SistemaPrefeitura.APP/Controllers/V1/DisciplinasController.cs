using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.DisciplinaMappers;
using SistemaPrefeitura.Application.Interfaces;

namespace SistemaPrefeitura.APP.Controllers.V1
{
    [Route("api/v1/escolas/{escolaId}/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {
        #region Properties
        private readonly IDisciplinaService _disciplinaService;
        private readonly DisciplinaToDisciplinaDTOMapper _disciplinaToDisciplinaDTOMapper;
        private readonly DisciplinaDTOToDisciplinaMapper _disciplinaDTOToDisciplinaMapper;
        #endregion

        #region Constructor
        public DisciplinasController(IDisciplinaService disciplinaService,
                                DisciplinaToDisciplinaDTOMapper disciplinaToDisciplinaDTOMapper,
                                DisciplinaDTOToDisciplinaMapper disciplinaDTOToDisciplinaMapper)
        {
            _disciplinaService = disciplinaService;
            _disciplinaToDisciplinaDTOMapper = disciplinaToDisciplinaDTOMapper;
            _disciplinaDTOToDisciplinaMapper = disciplinaDTOToDisciplinaMapper;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDisciplinas(Guid escolaId)
        {
            return Ok(_disciplinaToDisciplinaDTOMapper.Map(await _disciplinaService.GetAllAsync(escolaId)));
        }

        [HttpGet("{disciplinaId}")]
        public async Task<IActionResult> GetDisciplina(Guid disciplinaId)
        {
            return Ok(_disciplinaToDisciplinaDTOMapper.Map(await _disciplinaService.GetByIdAsync(disciplinaId)));
        }

        [HttpPost]
        public async Task<IActionResult> PostDisciplina([FromRoute] Guid escolaId, [FromBody] DisciplinaDTO disciplina)
        {
            return Created("api/v1/escolas/{escolaId}/disciplinas", await _disciplinaService.AddAsync(_disciplinaDTOToDisciplinaMapper.Map(disciplina), escolaId));
        }

        [HttpPut]
        public async Task<IActionResult> PutDisciplina([FromBody] DisciplinaDTO disciplina)
        {
            return Created("api/v1/escolas/{escolaId}/disciplinas", await _disciplinaService.UpdateAsync(_disciplinaDTOToDisciplinaMapper.Map(disciplina)));
        }

        [HttpDelete("{disciplinaId}")]
        public async Task<IActionResult> DeleteDisciplina([FromRoute] Guid disciplinaId)
        {
            await _disciplinaService.DeleteByIdAsync(disciplinaId);
            return NoContent();
        }



    }
}
