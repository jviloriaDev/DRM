using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Registro
{
    public class RegistroPagingModel
    {
        public List<Spartane.Core.Classes.Registro.Registro> Registros { set; get; }
        public int RowCount { set; get; }
    }
}
