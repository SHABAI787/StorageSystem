using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    /// <summary>
    /// Товар
    /// </summary>
    [Serializable]
    [Table("Products")]
    public class Product
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Состояние")]
        [ReadOnly(true)]
        public virtual ProductState State { get; set; }

        [DisplayName("Склад")]
        [ReadOnly(true)]
        public virtual Store Store { get; set; }

        [DisplayName("Поставщик")]
        [ReadOnly(true)]
        public virtual Provider Provider { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
    }
}
