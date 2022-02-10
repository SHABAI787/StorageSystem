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
    /// Поставщик
    /// </summary>
    [Serializable]
    [Table("Providers")]
    public class Provider
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Ответственный")]
        public virtual Person Responsible { get; set; }
    }
}
