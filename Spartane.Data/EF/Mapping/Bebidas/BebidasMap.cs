using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Bebidas
{
    public partial class BebidasMap : EntityTypeConfiguration<Spartane.Core.Classes.Bebidas.Bebidas>
    {
        public BebidasMap()
        {
            this.ToTable("Bebidas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
