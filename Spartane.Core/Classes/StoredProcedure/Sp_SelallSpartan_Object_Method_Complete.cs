using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Object_Method_Complete : BaseEntity
    {
        public short Module_Id { get; set; }
        public int? Object_Id { get; set; }
        public string Object_Id_Name { get; set; }
        public string Name { get; set; }
        public string Physical_Name { get; set; }
        public string URL { get; set; }
        public short? Method_Type { get; set; }
        public string Method_Type_Description { get; set; }
        public string Scope { get; set; }
        public string Tags { get; set; }
        public int? Image { get; set; }
        public string Image_Description { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }
        public int Object_Method_Id { get; set; }

    }
}
