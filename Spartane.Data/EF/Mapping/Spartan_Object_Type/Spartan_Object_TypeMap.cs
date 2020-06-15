using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Object_Type
{
    public partial class Spartan_Object_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Object_Type.Spartan_Object_Type>
    {
        public Spartan_Object_TypeMap()
        {
            this.ToTable("Spartan_Object_Type");
            this.HasKey(a => a.Object_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
