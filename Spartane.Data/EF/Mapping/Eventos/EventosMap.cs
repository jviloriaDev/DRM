using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Eventos
{
    public partial class EventosMap : EntityTypeConfiguration<Spartane.Core.Classes.Eventos.Eventos>
    {
        public EventosMap()
        {
            this.ToTable("Eventos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
