using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Tipo_Ejercicio
{
    public class Tipo_EjercicioPagingModel
    {
        public List<Spartane.Core.Classes.Tipo_Ejercicio.Tipo_Ejercicio> Tipo_Ejercicios { set; get; }
        public int RowCount { set; get; }
    }
}
