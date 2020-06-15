using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Planes_de_Rutinas
{
    public partial class Detalle_Planes_de_RutinasMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas>
    {
        public Detalle_Planes_de_RutinasMap()
        {
            this.ToTable("Detalle_Planes_de_Rutinas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
