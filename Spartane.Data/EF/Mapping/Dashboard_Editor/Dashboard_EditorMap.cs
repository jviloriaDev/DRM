using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Dashboard_Editor
{
    public partial class Dashboard_EditorMap : EntityTypeConfiguration<Spartane.Core.Classes.Dashboard_Editor.Dashboard_Editor>
    {
        public Dashboard_EditorMap()
        {
            this.ToTable("Dashboard_Editor");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Dashboard_Id);
        }
    }
}
