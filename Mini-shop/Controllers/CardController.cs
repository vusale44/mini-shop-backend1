
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_shop.DataAccessLayer;
using Mini_shop.Models;

namespace Mini_shop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CardController (AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            List<Card> card = await _db.Card.ToListAsync();
            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Card card)
        {
            await _db.Card.AddAsync(card);
          await  _db.SaveChangesAsync();
            return Ok();
        }

    


        [HttpDelete("id")] 
        public async Task<IActionResult> Delete(int id)
        {
            Card card = await _db.Card.FindAsync(id);

            _db.Card.Remove(card);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Məhsul uğurla silindi" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(Card updateCard)
        {
           _db.Card.Update(updateCard);

            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}

