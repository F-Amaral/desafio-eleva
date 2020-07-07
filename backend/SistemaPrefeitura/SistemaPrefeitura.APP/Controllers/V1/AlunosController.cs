using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.AlunoMappers;
using SistemaPrefeitura.Application.Interfaces;

namespace SistemaPrefeitura.APP.Controllers.V1.Escolas
{
    [Route("api/v1/escolas/{escolaId}/[controller]")]
    [ApiController]
    [Authorize]
    public class AlunosController : ControllerBase
    {
        #region Properties
        private readonly IAlunoService _alunoService;
        private readonly AlunoToAlunoDTOMapper _alunoToAlunoDTOMapper;
        private readonly AlunoDTOToAlunoMapper _alunoDTOToAlunoMapper;
        #endregion

        #region Constructor
        public AlunosController(IAlunoService alunoService, 
                                AlunoToAlunoDTOMapper alunoToAlunoDTOMapper,
                                AlunoDTOToAlunoMapper alunoDTOToAlunoMapper)
        {
            _alunoService = alunoService;
            _alunoToAlunoDTOMapper = alunoToAlunoDTOMapper;
            _alunoDTOToAlunoMapper = alunoDTOToAlunoMapper;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAlunos(Guid escolaId)
        {
            return Ok(_alunoToAlunoDTOMapper.Map(await _alunoService.GetAllAsync(escolaId)));
        }

        [HttpGet("{alunoId}")]
        public async Task<IActionResult> GetAluno(Guid alunoId)
        {
            return Ok(_alunoToAlunoDTOMapper.Map(await _alunoService.GetByIdAsync(alunoId)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAluno([FromRoute] Guid escolaId, [FromBody] AlunoDTO aluno)
        {
            return Created("api/v1/escolas/{escolaId}/alunos", await _alunoService.AddAsync(_alunoDTOToAlunoMapper.Map(aluno), escolaId));
        }

        [HttpPut("{alunoId}")]
        public async Task<IActionResult> PutAluno([FromBody] AlunoDTO aluno, [FromRoute] Guid alunoId)
        {
            return Created("api/v1/escolas/{escolaId}/alunos", await _alunoService.UpdateAsync(_alunoDTOToAlunoMapper.Map(aluno, alunoId)));
        }

        [HttpDelete("{alunoId}")]
        public async Task<IActionResult> DeleteAluno([FromRoute] Guid alunoId)
        {
            await _alunoService.DeleteByIdAsync(alunoId);
            return NoContent();
        }
    }
}
