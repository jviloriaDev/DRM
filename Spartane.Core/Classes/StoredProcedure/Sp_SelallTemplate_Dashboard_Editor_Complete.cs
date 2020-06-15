using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallTemplate_Dashboard_Editor_Complete : BaseEntity
    {
        public int Template_Id { get; set; }
        public string Description { get; set; }
        public int? Template_Image_Thumbnail { get; set; }

    }
}
