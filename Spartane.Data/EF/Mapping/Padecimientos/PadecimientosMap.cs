using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Padecimientos
{
    public partial class PadecimientosMap : EntityTypeConfiguration<Spartane.Core.Classes.Padecimientos.Padecimientos>
    {
        public PadecimientosMap()
        {
            this.ToTable("Padecimientos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
