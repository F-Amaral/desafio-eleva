using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.ProfessorMappers;
using SistemaPrefeitura.Application.Interfaces;

namespace SistemaPrefeitura.APP.Controllers.V1
{
    [Route("api/v1/escolas/{escolaId}/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfessoresController : ControllerBase
    {
        #region Properties
        private readonly IProfessorService _professorService;
        private readonly ProfessorToProfessorDTOMapper _professorToProfessorDTOMapper;
        private readonly ProfessorDTOToProfessorMapper _professorDTOToProfessorMapper;
        #endregion

        #region Constructor
        public ProfessoresController(IProfessorService professorService,
                                ProfessorToProfessorDTOMapper professorToProfessorDTOMapper,
                                ProfessorDTOToProfessorMapper professorDTOToProfessorMapper)
        {
            _professorService = professorService;
            _professorToProfessorDTOMapper = professorToProfessorDTOMapper;
            _professorDTOToProfessorMapper = professorDTOToProfessorMapper;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProfessores(Guid escolaId)
        {
            return Ok(_professorToProfessorDTOMapper.Map(await  _professorService.GetAllAsync(escolaId)));
        }

        [HttpGet("{professorId}")]
        public async Task<IActionResult> GetProfessor(Guid professorId)
        {
            return Ok(_professorToProfessorDTOMapper.Map(await _professorService.GetByIdAsync(professorId)));
        }

        [HttpPost]
        public async Task<IActionResult> PostProfessor([FromRoute] Guid escolaId, [FromBody] ProfessorDTO professor)
        {
            return Created("api/v1/escolas/{escolaId}/professores", await _professorService.AddAsync(_professorDTOToProfessorMapper.Map(professor), escolaId));
        }

        [HttpPut]
        public async Task<IActionResult> PutProfessor([FromBody] ProfessorDTO professor)
        {
            return Created("api/v1/escolas/{escolaId}/professores", await _professorService.UpdateAsync(_professorDTOToProfessorMapper.Map(professor)));
        }

        [HttpDelete("{professorId}")]
        public async Task<IActionResult> DeleteProfessor([FromRoute] Guid professorId)
        {
            await _professorService.DeleteByIdAsync(professorId);
            return NoContent();
        }

    }
}
