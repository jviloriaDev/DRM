using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Horarios_Actividad
{
    public partial class Detalle_Horarios_ActividadMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad>
    {
        public Detalle_Horarios_ActividadMap()
        {
            this.ToTable("Detalle_Horarios_Actividad");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
