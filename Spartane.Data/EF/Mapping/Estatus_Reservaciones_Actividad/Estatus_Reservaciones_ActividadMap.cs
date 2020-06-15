using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Reservaciones_Actividad
{
    public partial class Estatus_Reservaciones_ActividadMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad>
    {
        public Estatus_Reservaciones_ActividadMap()
        {
            this.ToTable("Estatus_Reservaciones_Actividad");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
