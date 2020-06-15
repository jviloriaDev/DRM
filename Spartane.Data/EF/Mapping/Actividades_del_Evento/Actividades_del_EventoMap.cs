using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Actividades_del_Evento
{
    public partial class Actividades_del_EventoMap : EntityTypeConfiguration<Spartane.Core.Classes.Actividades_del_Evento.Actividades_del_Evento>
    {
        public Actividades_del_EventoMap()
        {
            this.ToTable("Actividades_del_Evento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
