using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Template_Dashboard_Editor;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Template_Dashboard_Detail
{
    /// <summary>
    /// Template_Dashboard_Detail table
    /// </summary>
    public class Template_Dashboard_Detail: BaseEntity
    {
        public int Detail_Id { get; set; }
        public int? Template { get; set; }
        public short? Row_Number { get; set; }
        public short? Columns { get; set; }

        [ForeignKey("Template")]
        public virtual Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor Template_Template_Dashboard_Editor { get; set; }

    }
}

