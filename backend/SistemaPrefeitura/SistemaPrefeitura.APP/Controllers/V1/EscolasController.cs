using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.EscolaMappers;
using SistemaPrefeitura.Application.Interfaces;

namespace SistemaPrefeitura.APP.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EscolasController : ControllerBase
    {
        #region Properties
        private readonly IEscolaService _escolaService;
        private readonly EscolaToEscolaDTOMapper _escolaToEscolaDTOMapper;
        private readonly EscolaDTOToEscolaMapper _escolaDTOToEscolaMapper;
        #endregion

        #region Constructor
        public EscolasController(IEscolaService escolaService,
                                 EscolaToEscolaDTOMapper escolaToEscolaDTOMapper,
                                 EscolaDTOToEscolaMapper escolaDTOToEscolaMapper)
        {
            _escolaService = escolaService;
            _escolaToEscolaDTOMapper = escolaToEscolaDTOMapper;
            _escolaDTOToEscolaMapper = escolaDTOToEscolaMapper;
        }

        #endregion

        // GET: api/Escolas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_escolaToEscolaDTOMapper.Map(await _escolaService.GetAllAsync()));
        }

        // GET: api/Escolas/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_escolaToEscolaDTOMapper.Map(await _escolaService.GetByIdAsync(id)));
        }

        // POST: api/Escolas
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EscolaDTO escola)
        {
            return Created("api/v1/escolas", _escolaToEscolaDTOMapper.Map(await _escolaService.AddAsync(_escolaDTOToEscolaMapper.Map(escola))));
        }

        // PUT: api/Escolas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EscolaDTO escola)
        {
            return Ok(_escolaToEscolaDTOMapper.Map(await _escolaService.UpdateAsync(_escolaDTOToEscolaMapper.Map(escola, id))));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _escolaService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
