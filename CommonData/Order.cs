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
    /// Заказы на товар
    /// </summary>
    [Serializable]
    [Table("Orders")]
    public class Order
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Заказчик")]
        public virtual Person Person { get; set; }

        [DisplayName("Товар")]
        public virtual Product Product { get; set; }

        [DisplayName("Количество")]
        public int Quantity { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
    }
}
