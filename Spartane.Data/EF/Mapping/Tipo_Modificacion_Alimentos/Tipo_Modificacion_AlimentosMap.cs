using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_Modificacion_Alimentos
{
    public partial class Tipo_Modificacion_AlimentosMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos>
    {
        public Tipo_Modificacion_AlimentosMap()
        {
            this.ToTable("Tipo_Modificacion_Alimentos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
