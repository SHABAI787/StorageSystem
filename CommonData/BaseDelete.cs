using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    public abstract class BaseDelete
    {
        [NotMapped]
        [NonSerialized]
        protected static string exceptionDel = string.Empty;
        public abstract void Delete<T>(List<T> dataBoundItems, EventHandler eventHandler);
        
        public string GetDelException()
        {
            return exceptionDel;
        }
    }
}
