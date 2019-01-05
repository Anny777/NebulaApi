using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NebulaSync.ExternalModels
{


    [Table("EGAISObjectRegistration")]
    public partial class EGAISObjectRegistration
    {
        public int ID { get; set; }

        public int ObjectID { get; set; }

        public int RegistrationID { get; set; }
    }
}
