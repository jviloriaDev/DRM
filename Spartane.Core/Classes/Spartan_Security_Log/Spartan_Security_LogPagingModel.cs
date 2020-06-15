using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Spartan_Security_Log
{
    public class Spartan_Security_LogPagingModel
    {
        public List<Spartane.Core.Classes.Spartan_Security_Log.Spartan_Security_Log> Spartan_Security_Logs { set; get; }
        public int RowCount { set; get; }
    }
}
