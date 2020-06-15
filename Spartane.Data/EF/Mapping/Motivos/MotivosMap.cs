using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Motivos
{
    public partial class MotivosMap : EntityTypeConfiguration<Spartane.Core.Classes.Motivos.Motivos>
    {
        public MotivosMap()
        {
            this.ToTable("Motivos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
