using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessageBoardContext _db;

        public MessagesController(MessageBoardContext db)
        {
            _db = db;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages(string startDateString, string endDateString)
        {

          var query = _db.Messages.AsQueryable();

          if (startDateString != null && endDateString != null)
          {
            DateTime startDate = DateTime.Parse(startDateString);
            DateTime endDate = DateTime.Parse(endDateString);
            query = query.Where(entry => entry.Date >= startDate && entry.Date <= endDate);
          }

          return await _db.Messages.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            var message = await _db.Messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.MessageId)
            {
                return BadRequest();
            }

            _db.Entry(message).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message, string name)
        {
          var thisGroup = _db.Groups.Include(entry => entry.Messages).FirstOrDefault(entry => entry.Name == name);

          if (thisGroup != null)
          {
            message.Date = DateTime.Now;
            message.GroupId = thisGroup.GroupId;
            thisGroup.Messages.Add(message);
            _db.Groups.Update(thisGroup);    
            await _db.SaveChangesAsync();
          }
          else
          {
            return BadRequest();
          }
          return CreatedAtAction("Post", new { id = message.GroupId}, thisGroup);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _db.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _db.Messages.Remove(message);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(int id)
        {
            return _db.Messages.Any(e => e.MessageId == id);
        }
    }
}