using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Template_Dashboard_Detail
{
    public partial class Template_Dashboard_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Template_Dashboard_Detail.Template_Dashboard_Detail>
    {
        public Template_Dashboard_DetailMap()
        {
            this.ToTable("Template_Dashboard_Detail");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Detail_Id);
        }
    }
}
