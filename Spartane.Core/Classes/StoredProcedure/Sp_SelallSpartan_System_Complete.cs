using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_System_Complete : BaseEntity
    {
        public short System_Id { get; set; }
        public string Version { get; set; }
        public int? System_Image { get; set; }
        public string System_Image_Description { get; set; }
        public int? Customer_Image { get; set; }
        public string Customer_Image_Description { get; set; }
        public int? Developer_Image { get; set; }
        public string Developer_Image_Description { get; set; }

    }
}
