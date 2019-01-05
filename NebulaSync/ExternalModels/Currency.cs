using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace NebulaSync.ExternalModels
{
    
    public partial class Currency
    {
        public int ID { get; set; }

        [Column("Currency")]
        [StringLength(3)]
        public string Currency1 { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public double? ExchangeRate { get; set; }

        public int? Deleted { get; set; }
    }
}
