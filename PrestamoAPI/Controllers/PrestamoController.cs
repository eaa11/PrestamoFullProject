using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrestamoData.Interfaces;
using PrestamoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoRepository _prestamoRepository;

        public PrestamoController(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPrestamos()
        {
            try
            {
                return Ok(await _prestamoRepository.GetPrestamos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(int id)
        {
            try
            {
                var prestamo = await _prestamoRepository.GetPrestamo(id);

                if (prestamo == null)
                {
                    return NotFound();
                }
                return prestamo;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Prestamo>> PostPrestamo(Prestamo prestamo)
        {
            try
            {
                if (prestamo == null)
                {
                    return BadRequest();
                }
                var newPrestamo = await _prestamoRepository.Create(prestamo);
                return CreatedAtAction(nameof(GetPrestamo), new { id = newPrestamo.Id }, newPrestamo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Prestamo>> PutPrestamo(int id, Prestamo prestamo)
        {
            if (id != prestamo.Id)
            {
                return BadRequest();
            }
            await _prestamoRepository.Update(prestamo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Prestamo>> DeletePrestamo(int id)
        {
            var prestamoToDelete = await _prestamoRepository.GetPrestamo(id);
            if (prestamoToDelete == null)
            {
                return NotFound();
            }
            await _prestamoRepository.Delete(id);
            return NoContent();
        }
    }
}
