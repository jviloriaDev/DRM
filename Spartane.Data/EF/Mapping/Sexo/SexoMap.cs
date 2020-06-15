using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Sexo
{
    public partial class SexoMap : EntityTypeConfiguration<Spartane.Core.Classes.Sexo.Sexo>
    {
        public SexoMap()
        {
            this.ToTable("Sexo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
