using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NebulaSync.ExternalModels
{
 

    [Table("EGAISOperationsEx")]
    public partial class EGAISOperationsEx
    {
        public int ID { get; set; }

        public int OperationID { get; set; }

        [Required]
        [StringLength(50)]
        public string FORMA { get; set; }

        [Required]
        [StringLength(50)]
        public string FORMB { get; set; }

        public double TransferQuantity { get; set; }

        public double ReturnQuantity { get; set; }
    }
}
