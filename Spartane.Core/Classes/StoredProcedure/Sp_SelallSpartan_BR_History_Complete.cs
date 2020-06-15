using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_History_Complete : BaseEntity
    {
        public int Key_History { get; set; }
        public int? User_logged { get; set; }
        public string User_logged_Name { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }
        public DateTime? Change_Date { get; set; }
        public string Hour_Date { get; set; }
        public int? Time_elapsed { get; set; }
        public int? Change_Type { get; set; }
        public string Change_Type_Description { get; set; }
        public string Conditions { get; set; }
        public string Actions_True { get; set; }
        public string Actions_False { get; set; }
        public int BusinessRule { get; set; }

    }
}
