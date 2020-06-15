using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Registro
{
    public partial class RegistroMap : EntityTypeConfiguration<Spartane.Core.Classes.Registro.Registro>
    {
        public RegistroMap()
        {
            this.ToTable("Registro");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
