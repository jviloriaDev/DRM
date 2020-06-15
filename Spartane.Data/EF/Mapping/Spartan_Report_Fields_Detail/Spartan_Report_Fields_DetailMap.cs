using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Fields_Detail
{
    public partial class Spartan_Report_Fields_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail>
    {
        public Spartan_Report_Fields_DetailMap()
        {
            this.ToTable("Spartan_Report_Fields_Detail");
            this.HasKey(a => a.DesignDetailId);
            this.Ignore(a => a.Id);
        }
    }
}
