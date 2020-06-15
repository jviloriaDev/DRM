using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Actions_True_Detail
{
    public partial class Spartan_BR_Actions_True_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Actions_True_Detail.Spartan_BR_Actions_True_Detail>
    {
        public Spartan_BR_Actions_True_DetailMap()
        {
            this.ToTable("Spartan_BR_Actions_True_Detail");
            this.HasKey(a => a.ActionsTrueDetailId);
            this.Ignore(a => a.Id);
        }
    }
}
