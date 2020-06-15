using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Module_Config_Complete : BaseEntity
    {
        public short Module_Config_Id { get; set; }
        public short? Order_Type { get; set; }
        public string Order_Type_Description { get; set; }

    }
}
