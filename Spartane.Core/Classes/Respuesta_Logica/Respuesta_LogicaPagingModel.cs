using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Respuesta_Logica
{
    public class Respuesta_LogicaPagingModel
    {
        public List<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica> Respuesta_Logicas { set; get; }
        public int RowCount { set; get; }
    }
}
