using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Enfermedades
{
    public class EnfermedadesPagingModel
    {
        public List<Spartane.Core.Classes.Enfermedades.Enfermedades> Enfermedadess { set; get; }
        public int RowCount { set; get; }
    }
}
