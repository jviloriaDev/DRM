using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Marca
{
    public class MarcaPagingModel
    {
        public List<Spartane.Core.Classes.Marca.Marca> Marcas { set; get; }
        public int RowCount { set; get; }
    }
}
