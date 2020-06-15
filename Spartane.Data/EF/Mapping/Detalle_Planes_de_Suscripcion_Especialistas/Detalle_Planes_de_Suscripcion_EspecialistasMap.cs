using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Planes_de_Suscripcion_Especialistas
{
    public partial class Detalle_Planes_de_Suscripcion_EspecialistasMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>
    {
        public Detalle_Planes_de_Suscripcion_EspecialistasMap()
        {
            this.ToTable("Detalle_Planes_de_Suscripcion_Especialistas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
