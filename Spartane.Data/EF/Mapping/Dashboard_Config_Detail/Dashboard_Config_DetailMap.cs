using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Dashboard_Config_Detail
{
    public partial class Dashboard_Config_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail>
    {
        public Dashboard_Config_DetailMap()
        {
            this.ToTable("Dashboard_Config_Detail");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Detail_Id);
        }
    }
}
