using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_de_Suscripcion
{
    public partial class Estatus_de_SuscripcionMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_de_Suscripcion.Estatus_de_Suscripcion>
    {
        public Estatus_de_SuscripcionMap()
        {
            this.ToTable("Estatus_de_Suscripcion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
