using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Pais
{
    public partial class PaisMap : EntityTypeConfiguration<Spartane.Core.Classes.Pais.Pais>
    {
        public PaisMap()
        {
            this.ToTable("Pais");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
