using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_de_Padecimientos
{
    public partial class Detalle_de_PadecimientosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_de_Padecimientos.Detalle_de_Padecimientos>
    {
        public Detalle_de_PadecimientosMap()
        {
            this.ToTable("Detalle_de_Padecimientos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
