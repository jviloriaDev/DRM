using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Alert_Complete : BaseEntity
    {
        public int User__Alert_Id { get; set; }
        public int? User_Id { get; set; }
        public string User_Id_Name { get; set; }
        public short? Alert_Type { get; set; }
        public string Alert_Type_Description { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }

    }
}
