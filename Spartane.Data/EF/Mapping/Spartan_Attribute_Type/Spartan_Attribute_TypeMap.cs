using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Attribute_Type
{
    public partial class Spartan_Attribute_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Attribute_Type.Spartan_Attribute_Type>
    {
        public Spartan_Attribute_TypeMap()
        {
            this.ToTable("Spartan_Attribute_Type");
            this.HasKey(a => a.Attribute_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
