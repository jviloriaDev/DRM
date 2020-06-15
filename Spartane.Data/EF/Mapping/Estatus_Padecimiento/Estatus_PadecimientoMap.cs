using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Padecimiento
{
    public partial class Estatus_PadecimientoMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento>
    {
        public Estatus_PadecimientoMap()
        {
            this.ToTable("Estatus_Padecimiento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
