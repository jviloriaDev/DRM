using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Llamadas
{
    public partial class Estatus_LlamadasMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Llamadas.Estatus_Llamadas>
    {
        public Estatus_LlamadasMap()
        {
            this.ToTable("Estatus_Llamadas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
