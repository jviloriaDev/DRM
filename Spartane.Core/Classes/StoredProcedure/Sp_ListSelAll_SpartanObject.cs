using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartanObject : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int SpartanObject_Object_Id { get; set; }
        public string SpartanObject_Name { get; set; }

    }
}
