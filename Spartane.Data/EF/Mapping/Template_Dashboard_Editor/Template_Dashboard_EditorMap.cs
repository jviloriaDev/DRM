using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Template_Dashboard_Editor
{
    public partial class Template_Dashboard_EditorMap : EntityTypeConfiguration<Spartane.Core.Classes.Template_Dashboard_Editor.Template_Dashboard_Editor>
    {
        public Template_Dashboard_EditorMap()
        {
            this.ToTable("Template_Dashboard_Editor");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Template_Id);
        }
    }
}
