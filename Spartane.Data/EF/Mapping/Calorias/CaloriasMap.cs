using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Calorias
{
    public partial class CaloriasMap : EntityTypeConfiguration<Spartane.Core.Classes.Calorias.Calorias>
    {
        public CaloriasMap()
        {
            this.ToTable("Calorias");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
