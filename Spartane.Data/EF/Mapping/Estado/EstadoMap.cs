using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estado
{
    public partial class EstadoMap : EntityTypeConfiguration<Spartane.Core.Classes.Estado.Estado>
    {
        public EstadoMap()
        {
            this.ToTable("Estado");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
