using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_por_Suscripcion
{
    public partial class Estatus_por_SuscripcionMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_por_Suscripcion.Estatus_por_Suscripcion>
    {
        public Estatus_por_SuscripcionMap()
        {
            this.ToTable("Estatus_por_Suscripcion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
