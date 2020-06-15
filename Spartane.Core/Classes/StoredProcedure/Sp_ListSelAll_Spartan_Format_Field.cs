using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Format_Field : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Format_Field_FormatFieldId { get; set; }
        public int? Spartan_Format_Field_Format { get; set; }
        public string Spartan_Format_Field_Format_Format_Name { get; set; }
        public string Spartan_Format_Field_Field_Path { get; set; }
        public string Spartan_Format_Field_Physical_Field_Name { get; set; }
        public string Spartan_Format_Field_Logical_Field_Name { get; set; }
        public DateTime? Spartan_Format_Field_Creation_Date { get; set; }
        public string Spartan_Format_Field_Creation_Hour { get; set; }
        public int? Spartan_Format_Field_Creation_User { get; set; }
        public string Spartan_Format_Field_Properties { get; set; }
        public string Spartan_Format_Field_Type_Html { get; set; }

    }
}
