using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Type_Work_Distribution
{
    public partial class Spartan_WorkFlow_Type_Work_DistributionMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution>
    {
        public Spartan_WorkFlow_Type_Work_DistributionMap()
        {
            this.ToTable("Spartan_WorkFlow_Type_Work_Distribution");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Type_of_Work_DistributionId);
        }
    }
}
