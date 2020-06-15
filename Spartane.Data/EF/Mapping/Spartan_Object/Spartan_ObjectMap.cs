using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Object
{
    public partial class Spartan_ObjectMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Object.Spartan_Object>
    {
        public Spartan_ObjectMap()
        {
            this.ToTable("Spartan_Object");
            this.HasKey(a => a.Object_Id);
            this.Ignore(a => a.Id);
        }
    }
}
