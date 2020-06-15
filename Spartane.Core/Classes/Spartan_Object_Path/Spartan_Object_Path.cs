using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Object;
using Spartane.Core.Classes.Spartan_Token_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Object_Path
{
    /// <summary>
    /// Spartan_Object_Path table
    /// </summary>
    public class Spartan_Object_Path: BaseEntity
    {
        public int Object_Path_Id { get; set; }
        public int? Object_Id { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public short? Token_Type { get; set; }
        public short? Order { get; set; }

        [ForeignKey("Object_Id")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Id_Spartan_Object { get; set; }
        [ForeignKey("Token_Type")]
        public virtual Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type Token_Type_Spartan_Token_Type { get; set; }

    }
}

