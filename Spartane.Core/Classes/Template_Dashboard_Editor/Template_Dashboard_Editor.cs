using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Template_Dashboard_Editor
{
    /// <summary>
    /// Template_Dashboard_Editor table
    /// </summary>
    public class Template_Dashboard_Editor: BaseEntity
    {
        public int Template_Id { get; set; }
        public string Description { get; set; }
        public int? Template_Image_Thumbnail { get; set; }
        public string Path { get; set; }

        [ForeignKey("Template_Image_Thumbnail")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Template_Image_Thumbnail_Spartane_File { get; set; }

    }
}

