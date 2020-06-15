using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Registro_en_Actividad_Evento
{
    public partial class Detalle_Registro_en_Actividad_EventoMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento>
    {
        public Detalle_Registro_en_Actividad_EventoMap()
        {
            this.ToTable("Detalle_Registro_en_Actividad_Evento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
