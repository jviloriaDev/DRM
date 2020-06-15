using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Spartan_Transaction_Log
{
    public class Spartan_Transaction_LogPagingModel
    {
        public List<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log> Spartan_Transaction_Logs { set; get; }
        public int RowCount { set; get; }
    }
}
