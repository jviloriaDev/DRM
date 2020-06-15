using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Format_Complete : BaseEntity
    {
        public int FormatId { get; set; }
        public DateTime? Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        public int? Registration_User { get; set; }
        public string Format_Name { get; set; }
        public short? Format_Type { get; set; }
        public string Format_Type_Description { get; set; }
        public string Search { get; set; }
        public int? Object { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public string Filter { get; set; }

    }
}
