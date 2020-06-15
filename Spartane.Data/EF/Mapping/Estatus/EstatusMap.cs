using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus
{
    public partial class EstatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus.Estatus>
    {
        public EstatusMap()
        {
            this.ToTable("Estatus");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
