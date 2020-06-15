using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Duracion_de_Planes_de_Suscripcion
{
    public partial class Duracion_de_Planes_de_SuscripcionMap : EntityTypeConfiguration<Spartane.Core.Classes.Duracion_de_Planes_de_Suscripcion.Duracion_de_Planes_de_Suscripcion>
    {
        public Duracion_de_Planes_de_SuscripcionMap()
        {
            this.ToTable("Duracion_de_Planes_de_Suscripcion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
