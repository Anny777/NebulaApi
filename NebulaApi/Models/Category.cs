﻿using System.ComponentModel.DataAnnotations;

namespace NebulaApi.Models
{
    public class Category
    {
        public virtual int Id { get; set; }
        [Display (Name = "Категория")]
        public virtual string Name { get; set; }
        public virtual string UrlImage { get; set; }
    }
}