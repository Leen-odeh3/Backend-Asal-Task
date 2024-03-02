using CreditTransferSystem.Domain.Models;
using CreditTransferSystem.Domain.IGenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditTransferSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditTransferController : ControllerBase
    {
        private readonly IRepository<TransferredCredits> _repository;

        public CreditTransferController(IRepository<TransferredCredits> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferredCredits>>> GetAllTransferredCredits()
        {
            var transferredCredits = await _repository.GetAllAsync();
            return Ok(transferredCredits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransferredCredits>> GetTransferredCredits(int id)
        {
            var transferredCredits = await _repository.GetByIdAsync(id);
            if (transferredCredits == null)
            {
                return NotFound();
            }
            return Ok(transferredCredits);
        }

        [HttpPost]
        public async Task<ActionResult<TransferredCredits>> AddTransferredCredits(TransferredCredits transferredCredits)
        {
            var newTransferredCredits = await _repository.AddAsync(transferredCredits);
            return CreatedAtAction(nameof(GetTransferredCredits), new { id = newTransferredCredits.Id }, newTransferredCredits);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransferredCredits(int id, TransferredCredits transferredCredits)
        {
            if (id != transferredCredits.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync(transferredCredits, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TransferredCredits>> DeleteTransferredCredits(int id)
        {
            var transferredCredits = await _repository.DeleteAsync(id);
            if (transferredCredits == null)
            {
                return NotFound();
            }
            return Ok(transferredCredits);
        }
    }
}
