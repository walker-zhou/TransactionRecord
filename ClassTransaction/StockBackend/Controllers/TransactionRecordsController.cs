using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockBackend;
using StockBackend.Models;

namespace StockBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionRecordsController : ControllerBase
    {
        private readonly TransactionRecordContext _context;

        public TransactionRecordsController(TransactionRecordContext context)
        {
            _context = context;
        }

        // GET: api/TransactionRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionRecord>>> GetTransactionRecords()
        {
          if (_context.TransactionRecords == null)
          {
              return NotFound();
          }
            return await _context.TransactionRecords.ToListAsync();
        }

        // GET: api/TransactionRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionRecord>> GetTransactionRecord(int id)
        {
          if (_context.TransactionRecords == null)
          {
              return NotFound();
          }
            var transactionRecord = await _context.TransactionRecords.FindAsync(id);

            if (transactionRecord == null)
            {
                return NotFound();
            }

            return transactionRecord;
        }

        // PUT: api/TransactionRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionRecord(int id, TransactionRecord transactionRecord)
        {
            if (id != transactionRecord.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transactionRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TransactionRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionRecord>> PostTransactionRecord(TransactionRecord transactionRecord)
        {
          if (_context.TransactionRecords == null)
          {
              return Problem("Entity set 'TransactionRecordContext.TransactionRecords'  is null.");
          }
            _context.TransactionRecords.Add(transactionRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionRecord", new { id = transactionRecord.TransactionId }, transactionRecord);
        }

        // DELETE: api/TransactionRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionRecord(int id)
        {
            if (_context.TransactionRecords == null)
            {
                return NotFound();
            }
            var transactionRecord = await _context.TransactionRecords.FindAsync(id);
            if (transactionRecord == null)
            {
                return NotFound();
            }

            _context.TransactionRecords.Remove(transactionRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionRecordExists(int id)
        {
            return (_context.TransactionRecords?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
