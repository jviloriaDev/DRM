using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.SpartanObject
{
    public class SpartanObjectPagingModel
    {
        public List<Spartane.Core.Classes.SpartanObject.SpartanObject> SpartanObjects { set; get; }
        public int RowCount { set; get; }
    }
}
