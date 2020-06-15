using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estado_Civil
{
    public partial class Estado_CivilMap : EntityTypeConfiguration<Spartane.Core.Classes.Estado_Civil.Estado_Civil>
    {
        public Estado_CivilMap()
        {
            this.ToTable("Estado_Civil");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
