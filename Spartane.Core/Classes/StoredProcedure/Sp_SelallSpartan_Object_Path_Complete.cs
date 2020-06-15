using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Object_Path_Complete : BaseEntity
    {
        public int Object_Path_Id { get; set; }
        public int? Object_Id { get; set; }
        public string Object_Id_Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public short? Token_Type { get; set; }
        public string Token_Type_Description { get; set; }
        public short? Order { get; set; }

    }
}
