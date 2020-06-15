using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDashboard_Editor_Complete : BaseEntity
    {
        public int Dashboard_Id { get; set; }
        public DateTime? Registration_Date { get; set; }
        public int? Registration_User { get; set; }
        public string Registration_User_Name { get; set; }
        public string Name { get; set; }
        public int? Dashboard_Template { get; set; }
        public string Dashboard_Template_Description { get; set; }
        public bool? Show_in_Home { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }
        public int? Spartan_Object { get; set; }

    }
}
