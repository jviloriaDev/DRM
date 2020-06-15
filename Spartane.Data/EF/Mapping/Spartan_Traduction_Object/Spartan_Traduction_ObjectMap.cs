using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Traduction_Object
{
    public partial class Spartan_Traduction_ObjectMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Traduction_Object.Spartan_Traduction_Object>
    {
        public Spartan_Traduction_ObjectMap()
        {
            this.ToTable("Spartan_Traduction_Object");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.IdObject);
        }
    }
}
