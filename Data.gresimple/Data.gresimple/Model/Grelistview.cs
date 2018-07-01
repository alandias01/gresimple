using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.gresimple.Model
{    
    public class Grelistview
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("email")]
        [StringLength(40)]
        public string Email { get; set; }
        [Required]
        [Column("listName")]
        [StringLength(45)]
        public string ListName { get; set; }
        [Column("word")]
        [StringLength(100)]
        public string Word { get; set; }
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
        [Column("definition")]
        [StringLength(500)]
        public string Definition { get; set; }
    }
}
