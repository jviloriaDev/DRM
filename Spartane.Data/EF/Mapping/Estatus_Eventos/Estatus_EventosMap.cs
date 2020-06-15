using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Eventos
{
    public partial class Estatus_EventosMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Eventos.Estatus_Eventos>
    {
        public Estatus_EventosMap()
        {
            this.ToTable("Estatus_Eventos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
