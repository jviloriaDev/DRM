using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Format : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Format_FormatId { get; set; }
        public DateTime? Spartan_Format_Registration_Date { get; set; }
        public string Spartan_Format_Registration_Hour { get; set; }
        public int? Spartan_Format_Registration_User { get; set; }
        public string Spartan_Format_Registration_User_Name { get; set; }
        public string Spartan_Format_Format_Name { get; set; }
        public short? Spartan_Format_Format_Type { get; set; }
        public string Spartan_Format_Format_Type_Description { get; set; }
        public string Spartan_Format_Search { get; set; }
        public int? Spartan_Format_Object { get; set; }
        public string Spartan_Format_Object_Name { get; set; }
        public string Spartan_Format_Header { get; set; }
        public string Spartan_Format_Body { get; set; }
        public string Spartan_Format_Footer { get; set; }
        public string Spartan_Format_Filter { get; set; }
    }
}
