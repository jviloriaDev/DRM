using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Actividades_Evento
{
    public partial class Detalle_Actividades_EventoMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento>
    {
        public Detalle_Actividades_EventoMap()
        {
            this.ToTable("Detalle_Actividades_Evento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
