using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.gresimple.Model
{
    [Table("greusers")]
    public partial class Greusers
    {
        [Key]
        [Column("email")]
        [StringLength(40)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(45)]
        public string Password { get; set; }
    }
}
