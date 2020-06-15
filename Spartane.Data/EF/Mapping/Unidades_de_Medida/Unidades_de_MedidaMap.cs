using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Unidades_de_Medida
{
    public partial class Unidades_de_MedidaMap : EntityTypeConfiguration<Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida>
    {
        public Unidades_de_MedidaMap()
        {
            this.ToTable("Unidades_de_Medida");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
