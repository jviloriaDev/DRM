using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Preferencias_Sal
{
    public partial class Preferencias_SalMap : EntityTypeConfiguration<Spartane.Core.Classes.Preferencias_Sal.Preferencias_Sal>
    {
        public Preferencias_SalMap()
        {
            this.ToTable("Preferencias_Sal");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
