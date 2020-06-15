using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Preferencias_Grasas
{
    public partial class Preferencias_GrasasMap : EntityTypeConfiguration<Spartane.Core.Classes.Preferencias_Grasas.Preferencias_Grasas>
    {
        public Preferencias_GrasasMap()
        {
            this.ToTable("Preferencias_Grasas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
