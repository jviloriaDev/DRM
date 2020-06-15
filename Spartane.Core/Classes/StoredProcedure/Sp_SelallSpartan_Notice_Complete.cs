using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Notice_Complete : BaseEntity
    {
        public int Notice_Id { get; set; }
        public string Description { get; set; }
        public int? Notice_Type { get; set; }
        public string Notice_Type_Description { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }

    }
}
