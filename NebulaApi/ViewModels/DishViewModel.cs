using NebulaApi.Models;
using ProjectOrderFood.Enums;
using ProjectOrderFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NebulaApi.ViewModels
{
    public class DishViewModel : ModelBase
    {
        /// <summary>
        /// Идентификатор заказанного блюда
        /// </summary>
        public int CookingDishId;
        /// <summary>
        /// Название блюда
        /// </summary>
        public string Name;
        /// <summary>
        /// Состав блюда
        /// </summary>
        public string Consist;
        /// <summary>
        /// Единица измерения
        /// </summary>
        public string Unit;
        /// <summary>
        /// Состояние блюда
        /// </summary>
        public DishState State;
        /// <summary>
        /// Комментарий к блюду
        /// </summary>
        public string Comment;
        /// <summary>
        /// Цех
        /// </summary>
        public WorkshopType WorkshopType;
        /// <summary>
        /// Цена блюда
        /// </summary>
        public decimal? Price;
    }
}