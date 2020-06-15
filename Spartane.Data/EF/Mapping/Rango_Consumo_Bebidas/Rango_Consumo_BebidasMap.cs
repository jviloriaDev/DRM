using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Rango_Consumo_Bebidas
{
    public partial class Rango_Consumo_BebidasMap : EntityTypeConfiguration<Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>
    {
        public Rango_Consumo_BebidasMap()
        {
            this.ToTable("Rango_Consumo_Bebidas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
