using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_WorkFlow_Information_by_State_Complete : BaseEntity
    {
        public int Spartan_WorkFlow { get; set; }
        public int Information_by_StateId { get; set; }
        public int? Phase { get; set; }
        public string Phase_Name { get; set; }
        public int? State { get; set; }
        public string State_Name { get; set; }
        public int? Folder { get; set; }
        public string Folder_Group_Name { get; set; }
        public bool? Visible { get; set; }
        public bool? Read_Only { get; set; }
        public bool? Required { get; set; }
        public string Label { get; set; }

    }
}
