using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Tipos_de_Empresa
{
    public class Tipos_de_EmpresaPagingModel
    {
        public List<Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa> Tipos_de_Empresas { set; get; }
        public int RowCount { set; get; }
    }
}
