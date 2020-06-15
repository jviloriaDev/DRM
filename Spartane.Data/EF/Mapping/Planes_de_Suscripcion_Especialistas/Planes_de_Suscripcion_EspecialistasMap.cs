using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Planes_de_Suscripcion_Especialistas
{
    public partial class Planes_de_Suscripcion_EspecialistasMap : EntityTypeConfiguration<Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas>
    {
        public Planes_de_Suscripcion_EspecialistasMap()
        {
            this.ToTable("Planes_de_Suscripcion_Especialistas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
