using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Actions_False_Detail_Complete : BaseEntity
    {
        public int ActionsFalseDetailId { get; set; }
        public int Business_Rule { get; set; }
        public short? Action_Classification { get; set; }
        public string Action_Classification_Description { get; set; }
        public int? Action { get; set; }
        public string Action_Description { get; set; }
        public short? Action_Result { get; set; }
        public string Action_Result_Description { get; set; }
        public string Parameter_1 { get; set; }
        public string Parameter_2 { get; set; }
        public string Parameter_3 { get; set; }
        public string Parameter_4 { get; set; }
        public string Parameter_5 { get; set; }

    }
}
