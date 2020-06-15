using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Business_Rule_Creation
{
    public partial class Business_Rule_CreationMap : EntityTypeConfiguration<Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation>
    {
        public Business_Rule_CreationMap()
        {
            this.ToTable("Business_Rule_Creation");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Key_Business_Rule_Creation);
        }
    }
}
