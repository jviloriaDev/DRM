using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Function_Type;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartan_Function_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Function
{
    /// <summary>
    /// Spartan_Function table
    /// </summary>
    public class Spartan_Function: BaseEntity
    {
        public short Function_Id { get; set; }
        public string Description { get; set; }
        public short? Function_Type_Id { get; set; }
        public int? Image { get; set; }
        public short? Order_Shown { get; set; }
        public short? Status { get; set; }

        [ForeignKey("Function_Type_Id")]
        public virtual Spartane.Core.Classes.Spartan_Function_Type.Spartan_Function_Type Function_Type_Id_Spartan_Function_Type { get; set; }
        [ForeignKey("Image")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Image_Spartane_File { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Classes.Spartan_Function_Status.Spartan_Function_Status Status_Spartan_Function_Status { get; set; }

    }
}

