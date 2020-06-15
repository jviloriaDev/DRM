using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Tipos_de_Contrato
{
    public class Tipos_de_ContratoPagingModel
    {
        public List<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> Tipos_de_Contratos { set; get; }
        public int RowCount { set; get; }
    }
}
