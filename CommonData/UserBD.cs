using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    /// <summary>
    /// Пользователь программы
    /// </summary>
    [Serializable]
    [Table("UsersBD")]
    public class UserBD
    {
        [Key]
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DisplayName("Физ. лицо")]
        [ReadOnly(true)]
        public virtual Person Person { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Активность")]
        public bool Enabled { get; set; }
    }
}