using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_shop.Models
{
    public class Card
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public double Rating { get; set; }
        public string? Category { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> ?Color { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
    
}
}
