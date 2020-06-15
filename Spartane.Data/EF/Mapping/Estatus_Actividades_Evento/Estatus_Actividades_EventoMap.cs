using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Actividades_Evento
{
    public partial class Estatus_Actividades_EventoMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento>
    {
        public Estatus_Actividades_EventoMap()
        {
            this.ToTable("Estatus_Actividades_Evento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
