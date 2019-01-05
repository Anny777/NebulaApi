using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace NebulaSync.ExternalModels
{

    [Table("EGAISystem")]
    public partial class EGAISystem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Version { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime LastUpdate { get; set; }
    }
}
