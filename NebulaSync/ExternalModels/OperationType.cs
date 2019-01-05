
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace NebulaSync.ExternalModels
{
    [Table("OperationType")]
    public partial class OperationType
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string BG { get; set; }

        [StringLength(255)]
        public string EN { get; set; }

        [StringLength(255)]
        public string DE { get; set; }

        [StringLength(255)]
        public string RU { get; set; }

        [StringLength(255)]
        public string TR { get; set; }

        [StringLength(255)]
        public string SQ { get; set; }

        [StringLength(255)]
        public string SR { get; set; }

        [StringLength(255)]
        public string RO { get; set; }

        [StringLength(255)]
        public string GR { get; set; }

        [StringLength(255)]
        public string EL { get; set; }

        [StringLength(255)]
        public string ES { get; set; }

        [StringLength(255)]
        public string HY { get; set; }

        [StringLength(255)]
        public string KA { get; set; }

        [StringLength(255)]
        public string PL { get; set; }

        [StringLength(255)]
        public string UK { get; set; }

        [StringLength(255)]
        public string ZU { get; set; }

        [StringLength(255)]
        public string LV { get; set; }

        [StringLength(255)]
        public string FI { get; set; }

        [StringLength(255)]
        public string AR { get; set; }

        [StringLength(255)]
        public string TK { get; set; }
    }
}
