using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Consulta_Actividades_Registro_Evento
{
    public partial class Detalle_Consulta_Actividades_Registro_EventoMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento>
    {
        public Detalle_Consulta_Actividades_Registro_EventoMap()
        {
            this.ToTable("Detalle_Consulta_Actividades_Registro_Evento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
