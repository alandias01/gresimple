using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.gresimple.Model
{
    [Table("grewords")]
    public partial class Grewords
    {
        [Column("id")]
        public int Id { get; set; }
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
