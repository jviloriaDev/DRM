using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Presentacion
{
    public partial class PresentacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Presentacion.Presentacion>
    {
        public PresentacionMap()
        {
            this.ToTable("Presentacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
