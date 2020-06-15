using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.SpartanObject
{
    public partial class SpartanObjectMap : EntityTypeConfiguration<Spartane.Core.Classes.SpartanObject.SpartanObject>
    {
        public SpartanObjectMap()
        {
            this.ToTable("SpartanObject");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Object_Id);
        }
    }
}
