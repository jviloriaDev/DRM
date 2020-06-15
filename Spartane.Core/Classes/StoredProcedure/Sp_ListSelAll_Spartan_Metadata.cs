using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Metadata : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Metadata_AttributeId { get; set; }
        public int? Spartan_Metadata_Class_Id { get; set; }
        public string Spartan_Metadata_Class_Name { get; set; }
        public int? Spartan_Metadata_Object_Id { get; set; }
        public string Spartan_Metadata_Physical_Name { get; set; }
        public string Spartan_Metadata_Logical_Name { get; set; }
        public short? Spartan_Metadata_Identifier_Type { get; set; }
        public short? Spartan_Metadata_Attribute_Type { get; set; }
        public int? Spartan_Metadata_Length { get; set; }
        public short? Spartan_Metadata_Decimals_Length { get; set; }
        public short? Spartan_Metadata_Relation_Type { get; set; }
        public int? Spartan_Metadata_Related_Object_Id { get; set; }
        public int? Spartan_Metadata_Related_Class_Id { get; set; }
        public string Spartan_Metadata_Related_Class_Name { get; set; }
        public int? Spartan_Metadata_Related_Class_Identifier { get; set; }
        public string Spartan_Metadata_Related_Class_Description { get; set; }
        public bool? Spartan_Metadata_Required { get; set; }
        public string Spartan_Metadata_DefaultValue { get; set; }
        public bool? Spartan_Metadata_Visible { get; set; }
        public string Spartan_Metadata_Help_Text { get; set; }
        public bool? Spartan_Metadata_Read_Only { get; set; }
        public int? Spartan_Metadata_ScreenOrder { get; set; }
        public int? Spartan_Metadata_Control_Type { get; set; }
        public string Spartan_Metadata_Group_Name { get; set; }
        public string Spartan_Object_Name { get; set; }

    }
}
