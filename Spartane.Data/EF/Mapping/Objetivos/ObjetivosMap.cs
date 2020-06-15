using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Objetivos
{
    public partial class ObjetivosMap : EntityTypeConfiguration<Spartane.Core.Classes.Objetivos.Objetivos>
    {
        public ObjetivosMap()
        {
            this.ToTable("Objetivos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
