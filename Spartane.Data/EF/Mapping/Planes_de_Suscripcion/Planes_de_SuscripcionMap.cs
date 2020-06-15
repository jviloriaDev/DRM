using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Planes_de_Suscripcion
{
    public partial class Planes_de_SuscripcionMap : EntityTypeConfiguration<Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion>
    {
        public Planes_de_SuscripcionMap()
        {
            this.ToTable("Planes_de_Suscripcion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
