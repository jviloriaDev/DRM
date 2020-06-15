using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Parentesco
{
    public partial class ParentescoMap : EntityTypeConfiguration<Spartane.Core.Classes.Parentesco.Parentesco>
    {
        public ParentescoMap()
        {
            this.ToTable("Parentesco");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
