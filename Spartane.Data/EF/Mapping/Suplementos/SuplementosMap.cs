using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Suplementos
{
    public partial class SuplementosMap : EntityTypeConfiguration<Spartane.Core.Classes.Suplementos.Suplementos>
    {
        public SuplementosMap()
        {
            this.ToTable("Suplementos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
