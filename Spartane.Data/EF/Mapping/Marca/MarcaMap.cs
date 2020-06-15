using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Marca
{
    public partial class MarcaMap : EntityTypeConfiguration<Spartane.Core.Classes.Marca.Marca>
    {
        public MarcaMap()
        {
            this.ToTable("Marca");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
