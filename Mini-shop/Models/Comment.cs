namespace Mini_shop.Models
{
    public class Comment
    {
        public int Id { get; set; }

        // 1. Rəyin hansı məhsula yazıldığını bilmək üçün (Xarici açar - Foreign Key məntiqi)
        public int ProductId { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

        // 2. Adminin rəyi təsdiqləməsi üçün status (Default olaraq false veririk ki, dərhal görünməsin)
        public bool IsApproved { get; set; } = false;

        // 3. Adminin rəyə yazacağı cavab (Nullable edirik ki, başlanğıcda boş ola bilsin)
        public string? AdminReply { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}