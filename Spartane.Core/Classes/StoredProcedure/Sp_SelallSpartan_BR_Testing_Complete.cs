using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Testing_Complete : BaseEntity
    {
        public int Key_Testing { get; set; }
        public int? User_that_reviewed { get; set; }
        public string User_that_reviewed_Name { get; set; }
        public string Acceptance_Critera { get; set; }
        public bool? It_worked { get; set; }
        public int? Rejection_Reason { get; set; }
        public string Rejection_Reason_Description { get; set; }
        public string Comments { get; set; }
        public int? Evidence { get; set; }
        public int Business_Rule { get; set; }

    }
}
