using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTemplate_Dashboard_Editor : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Template_Dashboard_Editor_Template_Id { get; set; }
        public string Template_Dashboard_Editor_Description { get; set; }
        public int? Template_Dashboard_Editor_Template_Image_Thumbnail { get; set; }
        public string Template_Dashboard_Editor_Template_Image_Thumbnail_Nombre { get; set; }

    }
}
