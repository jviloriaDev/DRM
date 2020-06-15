using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Role_Complete : BaseEntity
    {
        public int User_Role_Id { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public string Status_Description { get; set; }

    }
}
