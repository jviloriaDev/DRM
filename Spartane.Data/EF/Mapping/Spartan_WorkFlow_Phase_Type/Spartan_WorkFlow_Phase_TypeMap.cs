using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Phase_Type
{
    public partial class Spartan_WorkFlow_Phase_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>
    {
        public Spartan_WorkFlow_Phase_TypeMap()
        {
            this.ToTable("Spartan_WorkFlow_Phase_Type");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Phase_TypeId);
        }
    }
}
