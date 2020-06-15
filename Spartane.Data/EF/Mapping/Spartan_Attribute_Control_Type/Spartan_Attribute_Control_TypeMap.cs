using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Attribute_Control_Type
{
    public partial class Spartan_Attribute_Control_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type>
    {
        public Spartan_Attribute_Control_TypeMap()
        {
            this.ToTable("Spartan_Attribute_Control_Type");
            this.HasKey(a => a.ControlTypeId);
            this.Ignore(a => a.Id);
        }
    }
}
