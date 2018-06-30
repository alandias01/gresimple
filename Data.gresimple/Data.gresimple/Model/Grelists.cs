using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.gresimple.Model
{
    [Table("grelists")]
    public partial class Grelists
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("email")]
        [StringLength(40)]
        public string Email { get; set; }
        [Required]
        [Column("listName")]
        [StringLength(45)]
        public string ListName { get; set; }
        [Required]
        [Column("word")]
        [StringLength(20)]
        public string Word { get; set; }
    }
}
