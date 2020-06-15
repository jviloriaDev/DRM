using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Spartan_Session_Log
{
    public class Spartan_Session_LogPagingModel
    {
        public List<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log> Spartan_Session_Logs { set; get; }
        public int RowCount { set; get; }
    }
}
