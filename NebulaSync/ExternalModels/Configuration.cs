using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace NebulaSync.ExternalModels
{
    [Table("Configuration")]
    public partial class Configuration
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Key { get; set; }

        [StringLength(50)]
        public string Value { get; set; }

        public int? UserID { get; set; }
    }
}
