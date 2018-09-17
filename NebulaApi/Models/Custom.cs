using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NebulaApi.Models
{
    public class Custom : ModelBase
    {
        public Custom()
        {
            CookingDishes = new Collection<CookingDish>();
        }

        public virtual ICollection<CookingDish> CookingDishes { get; set; }

       public  bool IsOpened { get; set; }
       public   int TableNumber { get; set; }

    }
}