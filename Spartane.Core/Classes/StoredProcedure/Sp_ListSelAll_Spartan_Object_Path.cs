using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Object_Path : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Object_Path_Object_Path_Id { get; set; }
        public int? Spartan_Object_Path_Object_Id { get; set; }
        public string Spartan_Object_Path_Object_Id_Name { get; set; }
        public string Spartan_Object_Path_Description { get; set; }
        public string Spartan_Object_Path_URL { get; set; }
        public short? Spartan_Object_Path_Token_Type { get; set; }
        public string Spartan_Object_Path_Token_Type_Description { get; set; }
        public short? Spartan_Object_Path_Order { get; set; }

    }
}
