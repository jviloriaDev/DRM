using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_WorkFlow_Complete : BaseEntity
    {
        public int WorkFlowId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }
        public int? Object { get; set; }
        public string Object_Name { get; set; }

    }
}
