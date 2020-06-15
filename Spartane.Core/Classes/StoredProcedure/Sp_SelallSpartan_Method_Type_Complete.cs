using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Method_Type_Complete : BaseEntity
    {
        public short Method_Type_Id { get; set; }
        public string Description { get; set; }
        public short? Clasification { get; set; }
        public string Clasification_Description { get; set; }
        public int? Image { get; set; }
        public string Image_Description { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }

    }
}
