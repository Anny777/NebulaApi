
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NebulaSync.ExternalModels
{

    [Table("System")]
    public partial class System
    {
        [Key]
        [StringLength(20)]
        public string Version { get; set; }

        public short? ProductID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastBackup { get; set; }
    }
}
