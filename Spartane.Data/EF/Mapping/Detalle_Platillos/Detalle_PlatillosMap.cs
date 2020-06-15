using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Platillos
{
    public partial class Detalle_PlatillosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos>
    {
        public Detalle_PlatillosMap()
        {
            this.ToTable("Detalle_Platillos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
