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

        // 1. BÜTÜN RƏYLƏRİ GƏTİR (Təsdiqlənmişləri filtrləmək üçün əlavə olundu)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allComments = await _db.Comment.ToListAsync();
            return Ok(allComments);
        }

        // 2. MÜŞTƏRİ ÜÇÜN: Yalnız təsdiqlənmiş rəyləri gətir
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetApprovedComments(int productId)
        {
            var comments = await _db.Comment
                .Where(c => c.ProductId == productId && c.IsApproved == true)
                .ToListAsync();

            return Ok(comments);
        }

        // 3. ADMİN ÜÇÜN: Təsdiq gözləyən rəyləri gətir
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingComments()
        {
            var comments = await _db.Comment
                .Where(c => c.IsApproved == false)
                .ToListAsync();

            return Ok(comments);
        }

        // 4. MÜŞTƏRİ ÜÇÜN: Yeni rəy yazmaq
        [HttpPost]
        public async Task<IActionResult> Post(Comment comment)
        {
            comment.IsApproved = false;
            await _db.Comment.AddAsync(comment);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Rəy uğurla göndərildi.", data = comment });
        }

        // 5. ADMİN ÜÇÜN: Rəyi silmək
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _db.Comment.FindAsync(id);
            if (comment == null) return NotFound();

            _db.Comment.Remove(comment);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Comment silindi" });
        }

        // 6. ADMİN ÜÇÜN: Rəyi təsdiqləmək
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var comment = await _db.Comment.FindAsync(id);
            if (comment == null) return NotFound();

            comment.IsApproved = true;
            await _db.SaveChangesAsync();

            return Ok(new { message = "Rəy təsdiqləndi" });
        }

        // 7. ADMİN ÜÇÜN: Rəyə cavab yazmaq
        [HttpPut("reply/{id}")]
        public async Task<IActionResult> Reply(int id, [FromBody] string adminReplyText)
        {
            var comment = await _db.Comment.FindAsync(id);
            if (comment == null) return NotFound();

            comment.AdminReply = adminReplyText;
            comment.IsApproved = true;

            await _db.SaveChangesAsync();

            return Ok(new { message = "Cavab göndərildi və rəy təsdiqləndi" });
        }
    }
}