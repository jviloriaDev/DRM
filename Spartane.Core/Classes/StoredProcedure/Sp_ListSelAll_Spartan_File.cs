using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_File : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_File_File_Id { get; set; }
        public string Spartan_File_Description { get; set; }
        public int? Spartan_File_File1 { get; set; }
        public string Spartan_File_File1_Nombre { get; set; }
        public int? Spartan_File_File_Size { get; set; }
        public int? Spartan_File_Object { get; set; }
        public int? Spartan_File_User_Id { get; set; }
        public DateTime? Spartan_File_Date_Time { get; set; }

    }
}
