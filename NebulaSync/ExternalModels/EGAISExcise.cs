using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace NebulaSync.ExternalModels
{

    [Table("EGAISExcise")]
    public partial class EGAISExcise
    {
        public int ID { get; set; }

        public int GoodID { get; set; }

        public int ObjectID { get; set; }

        [StringLength(50)]
        public string FORMB { get; set; }

        [StringLength(50)]
        public string FORMA { get; set; }

        public int Status { get; set; }

        [Required]
        [StringLength(150)]
        public string Excise { get; set; }
    }
}
