using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estado_de_Animo
{
    public partial class Estado_de_AnimoMap : EntityTypeConfiguration<Spartane.Core.Classes.Estado_de_Animo.Estado_de_Animo>
    {
        public Estado_de_AnimoMap()
        {
            this.ToTable("Estado_de_Animo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
