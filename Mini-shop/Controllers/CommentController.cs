using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_shop.DataAccessLayer;
using Mini_shop.Models;

namespace Mini_shop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CommentController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Comment> comments = await _db.Comment.ToListAsync();
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Comment comment)
        {
            await _db.Comment.AddAsync(comment);
            await _db.SaveChangesAsync();

            return Ok(comment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _db.Comment.FindAsync(id);

            if (comment == null)
                return NotFound();

            _db.Comment.Remove(comment);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Comment silindi" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Comment updateComment)
        {
            var comment = await _db.Comment.FindAsync(id);

            if (comment == null)
                return NotFound();

            updateComment.Id = id;

            _db.Entry(comment).CurrentValues.SetValues(updateComment);

            await _db.SaveChangesAsync();

            return Ok(updateComment);
        }
    }
}