using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Format_Field_Complete : BaseEntity
    {
        public int FormatFieldId { get; set; }
        public int? Format { get; set; }
        public string Format_Format_Name { get; set; }
        public string Field_Path { get; set; }
        public string Physical_Field_Name { get; set; }
        public string Logical_Field_Name { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Creation_Hour { get; set; }
        public int? Creation_User { get; set; }
        public string Properties { get; set; }

    }
}
