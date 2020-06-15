using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartan_Function_Type_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Function_Type
{
    /// <summary>
    /// Spartan_Function_Type table
    /// </summary>
    public class Spartan_Function_Type: BaseEntity
    {
        public short Function_Type_Id { get; set; }
        public string Description { get; set; }
        public int? Image { get; set; }
        public short? Status { get; set; }

        [ForeignKey("Image")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Image_Spartane_File { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status Status_Spartan_Function_Type_Status { get; set; }

    }
}

