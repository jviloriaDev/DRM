using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Planes_de_Rutinas
{
    public partial class Planes_de_RutinasMap : EntityTypeConfiguration<Spartane.Core.Classes.Planes_de_Rutinas.Planes_de_Rutinas>
    {
        public Planes_de_RutinasMap()
        {
            this.ToTable("Planes_de_Rutinas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
