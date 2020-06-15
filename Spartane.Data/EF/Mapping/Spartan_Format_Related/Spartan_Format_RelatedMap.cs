using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Format_Related
{
    public partial class Spartan_Format_RelatedMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Format_Related.Spartan_Format_Related>
    {
        public Spartan_Format_RelatedMap()
        {
            this.ToTable("Spartan_Format_Related");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
