using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Platillos
{
    public partial class PlatillosMap : EntityTypeConfiguration<Spartane.Core.Classes.Platillos.Platillos>
    {
        public PlatillosMap()
        {
            this.ToTable("Platillos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
