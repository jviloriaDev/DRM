using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Registro_en_Evento
{
    public partial class Registro_en_EventoMap : EntityTypeConfiguration<Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento>
    {
        public Registro_en_EventoMap()
        {
            this.ToTable("Registro_en_Evento");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
