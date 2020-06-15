using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_System_Layout_Complete : BaseEntity
    {
        public int System_Layout_Id { get; set; }
        public short? System_Id { get; set; }
        public string System_Id_Version { get; set; }
        public short? Menu_Style_Id { get; set; }
        public string Menu_Style_Id_Description { get; set; }
        public string Description { get; set; }
        public string Layout_URL { get; set; }
        public string Class_URL { get; set; }
        public short? Orientation { get; set; }
        public string Orientation_Description { get; set; }
        public short? Layout_Status { get; set; }
        public string Layout_Status_Description { get; set; }

    }
}
