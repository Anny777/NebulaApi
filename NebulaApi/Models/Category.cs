using System.ComponentModel.DataAnnotations;

namespace NebulaApi.Models
{
    public class Category : ModelBase
    {
        public string Name { get; set; }
        public string UrlImage { get; set; }
    }
}