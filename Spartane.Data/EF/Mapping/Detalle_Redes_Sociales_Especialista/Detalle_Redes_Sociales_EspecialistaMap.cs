using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Redes_Sociales_Especialista
{
    public partial class Detalle_Redes_Sociales_EspecialistaMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista>
    {
        public Detalle_Redes_Sociales_EspecialistaMap()
        {
            this.ToTable("Detalle_Redes_Sociales_Especialista");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
