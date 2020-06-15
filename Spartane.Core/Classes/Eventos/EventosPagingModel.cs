using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Eventos
{
    public class EventosPagingModel
    {
        public List<Spartane.Core.Classes.Eventos.Eventos> Eventoss { set; get; }
        public int RowCount { set; get; }
    }
}
