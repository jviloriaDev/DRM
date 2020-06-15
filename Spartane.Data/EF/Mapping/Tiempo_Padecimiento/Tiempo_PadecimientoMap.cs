using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tiempo_Padecimiento
{
    public partial class Tiempo_PadecimientoMap : EntityTypeConfiguration<Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento>
    {
        public Tiempo_PadecimientoMap()
        {
            this.ToTable("Tiempo_Padecimiento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
