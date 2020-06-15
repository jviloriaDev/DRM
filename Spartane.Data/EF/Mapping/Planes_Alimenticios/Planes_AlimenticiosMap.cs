using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Planes_Alimenticios
{
    public partial class Planes_AlimenticiosMap : EntityTypeConfiguration<Spartane.Core.Classes.Planes_Alimenticios.Planes_Alimenticios>
    {
        public Planes_AlimenticiosMap()
        {
            this.ToTable("Planes_Alimenticios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
