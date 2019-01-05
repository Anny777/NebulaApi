
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace NebulaSync.ExternalModels
{
    [Table("NextAcct")]
    public partial class NextAcct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column("NextAcct")]
        [StringLength(50)]
        public string NextAcct1 { get; set; }
    }
}
